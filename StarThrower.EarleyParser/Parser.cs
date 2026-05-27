using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// An Earley parser named after the inventor of the algorithm is implements.
    /// 
    /// Earley parsers are used to parse strings for conformance with a given
    /// context-free grammar.  Once instantiated with a grammar, an instance of 
    /// this class can be used to parse (or just recognize) strings (represented
    /// as a series of tokens).
    /// 
    /// This parser fills out a chart based on the specified tokens for a 
    /// specified seed catgory.  Because of this, it can be used to recognize
    /// strings that represent any rule in the grammar.  The Parse() method
    /// returns a Parse object that encapsulates teh completed chart, the tokens
    /// given and the seed category for that parse.
    /// 
    /// For example, if a grammar contains the following rules:
    ///     S -> NP VP
    ///     NP -> Det N
    ///     Det -> the
    ///     N -> boy
    ///     VP -> left
    /// parses can be requested for category S ("the boy left") but also for 
    /// category NP ("the boy").  For convenience, this class provides the
    /// Recognize method that just returns the status for a given parse (but not
    /// its completed chart, tokens, and seed category).
    /// </summary>
    public class Parser
    {
        public event EventHandler<EdgeEventArgs> OnEdgePredicted;
        public event EventHandler<EdgeEventArgs> OnEdgeScanned;
        public event EventHandler<EdgeEventArgs> OnEdgeCompleted;


        protected virtual void FireEdgePredicted(EdgeEventArgs e)
        {
            EventHandler<EdgeEventArgs> handler = OnEdgePredicted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void FireEdgeScanned(EdgeEventArgs e)
        {
            EventHandler<EdgeEventArgs> handler = OnEdgeScanned;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void FireEdgeCompleted(EdgeEventArgs e)
        {
            EventHandler<EdgeEventArgs> handler = OnEdgeCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #region [ Private Instance Variables ]

        private Grammar _grammar;
        private ParserOptions _options;

        #endregion


        #region [ Public Properties ]

        public Grammar Grammar
        {
            get { return _grammar; }
            set
            {
                if (value == null) throw new InvalidOperationException("null grammar");
                _grammar = value;
            }
        }

        #endregion


        #region [ Construction ]

        public Parser(Grammar grammar) : this(grammar, new ParserOptions()) { }

        public Parser(Grammar grammar, ParserOptions options)
        {
            this.Grammar = grammar;
            _options = options;
        }

        #endregion


        #region [ Public Methods ]

        /// <summary>
        /// Tests whether this parser recognizeds a given string (list of tokens)
        /// for the specified seed category.
        /// </summary>
        /// <param name="tokens">The tokens to parse.</param>
        /// <param name="seed">The seed category to attempt to recognize for the given tokens.</param>
        /// <returns>Returns Status.Accept if the string is recognized, Status.Reject if the string 
        /// is rejected, and Status.Error if an error occurred during parsing.</returns>
        public Status Recognize(string[] tokens, Category seed)
        {
            return this.Parse(tokens, seed).Status;
        }

        /// <summary>
        /// Gets a parse for the specified string (iterable series of tokens) and seed
        /// category.
        /// </summary>
        /// <param name="tokens">The tokens to parse.</param>
        /// <param name="seed">The seed category to attempt to find for the given tokens.</param>
        /// <returns>A parse for the specified tokens and seed, containing a completed chart.</returns>
        /// <exception cref="ArgumentNullException">Thrown if seed is null or tokens is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if tokens is empty.</exception>
        public Parse Parse(string[] tokens, Category seed)
        {
            if (seed == null) throw new ArgumentNullException("seed");
            if (tokens == null) throw new ArgumentNullException("tokens");
            if (tokens.Length == 0) throw new InvalidOperationException("tokens is empty");

            Chart chart = new Chart();
            Parse parse = new Parse(seed, chart);
            int index = 0;

            if (!_options.PredictPreterminals)
            {
                //check for rules that don't work if not predicting preterms
                foreach (Rule r in _grammar.GetAllRules())
                {
                    if (r.IsPreterminal && r.Right.Count > 1)
                    {
                        _options.PredictPreterminals = true; //set predictPreterm = true because grammar contains an incompatible rule: (r)
                        break;
                    }
                }
            }

            Edge seedEdge = new Edge(DottedRule.CreateStartRule(seed), index);
            chart.AddEdge(index, seedEdge); //seed parser
            foreach (string token in tokens)
            {
                try
                {
                    Predict(chart, index); //make predictions at this index
                    parse.AddToken(token); //add to tokens in parse
                    Scan(chart, index++, token); //scan and increment index
                    Complete(chart, index); //complete for next index
                    Predict(chart, index); //finish filling chart by predicting for final index
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return parse;
        }

        /// <summary>
        /// Makes predictions in the specified chart at the given index.
        /// </summary>
        /// <param name="chart">The chart to fill with predictions at index.</param>
        /// <param name="index">The string index to make predictions at.</param>
        private void Predict(Chart chart, int index)
        {
            if (chart.ContainsEdgesAt(index)) //if there are any edges at this index
            {
                //get a separate list  to avoid concurrently modifying chart
                List<Edge> l = new List<Edge>();
                foreach (Edge edge in chart.GetEdgesAt(index))
                {
                    l.Add(edge);
                }
                ReadOnlyCollection<Edge> edges = new ReadOnlyCollection<Edge>(l);

                foreach (Edge edge in edges)
                {
                    PredictForEdge(chart, edge, index);
                }
            }
        }

        /// <summary>
        /// Makes predictions (adds edges) in the specified chart fo a given edge
        /// at a given index.  This method is recursively called whenever an edge
        /// is added to also make predictions for the newly added edge.
        /// </summary>
        /// <param name="chart">The chart to fill.</param>
        /// <param name="edge">The edge to make predictions for.</param>
        /// <param name="index">The index in the string under consideration.</param>
        private void PredictForEdge(Chart chart, Edge edge, int index)
        {
            Category active = edge.DottedRule.ActiveCategory; //null, if passive

            if (active != null && _grammar.ContainsRules(active))
            {
                //get all rules with the active category on the left
                foreach (Rule rule in _grammar.GetRules(active))
                {
                    if (!_options.PredictPreterminals && rule.IsPreterminal)
                    {
                        //only predict for rules that aren't preterminals to avoid
                        //villing up the chart with entries for every terminal
                        continue;
                    }

                    //make new edge at index with dotted rule at position 0
                    Edge newEdge = Edge.PredictFor(rule, index);

                    //only predict for edges that the chart did not already contain
                    if (chart.AddEdge(index, newEdge))
                    {
                        FireEdgePredicted(new EdgeEventArgs(index, newEdge));
                        //recursively predict for the new edge
                        PredictForEdge(chart, newEdge, index);
                    }
                }
            }
        }

        /// <summary>
        /// Handles a token scanned from the input string, making completions (and
        /// adding edges to the chart) as needed.
        /// </summary>
        /// <param name="chart">The chart to fill.</param>
        /// <param name="index">The start index of the scan</param>
        /// <param name="token">The token that was scanned.</param>
        /// <exception cref="ArgumentNullException">Thrown if chart or token are null.</exception>
        private void Scan(Chart chart, int index, string token)
        {
            if (token == null) throw new ArgumentNullException("token");
            if (chart == null) throw new ArgumentNullException("chart");

            if (chart.ContainsEdgesAt(index)) //any predictions at this index?
            {
                ReadOnlyCollection<Edge> tempEdges = chart.GetEdgesAt(index);
                //get a separate list to avoid concurrently modifying chart
                List<Edge> l = new List<Edge>();
                foreach (Edge edge in tempEdges)
                {
                    l.Add(edge);
                }
                ReadOnlyCollection<Edge> edges = new ReadOnlyCollection<Edge>(l);

                //just-in-time prediction
                if (!_options.PredictPreterminals)
                {
                    foreach (Edge edge in edges)
                    {
                        if (!edge.IsPassive)
                        {
                            Rule r = _grammar.SingletonPreterminal(edge.DottedRule.ActiveCategory, token, _options.IgnoreCase);
                            if (r != null)
                            {
                                Edge pt = Edge.PredictFor(r, index);
                                if (chart.AddEdge(index, pt))
                                {
                                    FireEdgePredicted(new EdgeEventArgs(index, pt));
                                }
                            }
                        }
                    }
                }

                foreach (Edge edge in edges)
                {
                    //completions for active edges only
                    if (!edge.IsPassive)
                    {
                        DottedRule dr = edge.DottedRule;

                        StringComparison sc = (_options.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                        if (dr.ActiveCategory.IsTerminal &&
                            (String.Compare(dr.ActiveCategory.Name, token, sc) == 0))
                        {
                            Edge newEdge = Edge.Scan(edge, token);
                            int successor = index + 1; //save next index
                            if (chart.AddEdge(successor, newEdge))
                            {
                                FireEdgeScanned(new EdgeEventArgs(successor, newEdge));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Makes completions in the specified chart at the given index.
        /// </summary>
        /// <param name="chart">The chart to fill.</param>
        /// <param name="index">The index to make completions at.</param>
        private void Complete(Chart chart, int index)
        {
            if (chart.ContainsEdgesAt(index)) //any edges at this index?
            {
                //get a separate list to avoid concurrently modifying chart
                List<Edge> l = new List<Edge>();
                foreach (Edge edge in chart.GetEdgesAt(index))
                {
                    l.Add(edge);
                }
                ReadOnlyCollection<Edge> edges = new ReadOnlyCollection<Edge>(l);

                foreach (Edge edge in edges)
                {
                    CompleteForEdge(chart, edge, index); //complete for each edge
                }
            }
        }

        /// <summary>
        /// Makes completions in the specified chart based on the given edge at
        /// the given index.  This method is recursively called whenever a new
        /// edge is added in order to make completions based on the newly-added
        /// edge.
        /// </summary>
        /// <param name="chart">The chart to fill.</param>
        /// <param name="edge">The edge to complete for.</param>
        /// <param name="index">The index to make completions at.</param>
        private void CompleteForEdge(Chart chart, Edge edge, int index)
        {
            int eo = edge.Origin;

            //can only make completions based on passive edges
            if (edge.IsPassive && chart.ContainsEdgesAt(eo))
            {
                //get all edges at this edge's origin
                foreach (Edge originEdge in chart.GetEdgesAt(eo))
                {

                    //compare each non-passive edge's active category with
                    //the left side of the edge used to complete
                    if (!originEdge.IsPassive && originEdge.DottedRule.ActiveCategory.Equals(edge.DottedRule.Left))
                    {

                        //add new edge with dot advanced by one if same
                        Edge newEdge = Edge.Complete(originEdge, edge);

                        if (chart.AddEdge(index, newEdge))
                        {
                            FireEdgeCompleted(new EdgeEventArgs(index, newEdge));
                            //only recursively complete if the chart did not already contain this edge.
                            CompleteForEdge(chart, newEdge, index);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
