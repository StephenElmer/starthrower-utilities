// Copyright © 2005-2026 Stephen Elmer. Licensed under the MIT License.

using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    /// <summary>
    /// Parses a <see cref="Grammar"/> from an XML grammar definition (see <c>grammar.xsd</c> for
    /// the expected schema). The grammar's root element must have a "name" attribute and a "rule"
    /// child element for each production rule. Each "rule" element must have a "category" attribute
    /// naming its left-hand-side category and a "category" child element for each category on its
    /// right-hand side; each right-hand-side "category" element must have a "name" attribute and
    /// may have an optional "terminal" attribute (parsed as a boolean; defaults to false/non-terminal
    /// if omitted).
    /// </summary>
    public class GrammarParser
    {
        #region [ Private Instance Variables ]

        private XmlDocument _doc;

        #endregion


        #region [ Construction ]

        /// <summary>
        /// Creates a new grammar parser for the specified, already-loaded XML document.
        /// </summary>
        /// <param name="doc">The XML document containing the grammar definition.</param>
        public GrammarParser(XmlDocument doc)
        {
            _doc = doc;
        }

        /// <summary>
        /// Creates a new grammar parser that loads its XML document from the specified file.
        /// </summary>
        /// <param name="fileName">The path of the XML file containing the grammar definition.</param>
        /// <exception cref="FileNotFoundException">Thrown if fileName does not exist.</exception>
        public GrammarParser(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException("file not found", fileName);

            _doc = new XmlDocument();
            _doc.Load(fileName);
        }

        #endregion


        #region [ Public Methods ]

        /// <summary>
        /// Parses this instance's XML document into a <see cref="Grammar"/>.
        /// </summary>
        /// <returns>The grammar described by the XML document.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the XML document does not conform
        /// to the expected grammar schema: a missing root element, a missing "name" attribute on the
        /// root element, a missing "category" attribute on a "rule" element, a missing "name"
        /// attribute on a "category" element, or a "terminal" attribute with no value.</exception>
        /// <exception cref="FormatException">Thrown if a "terminal" attribute's value is not a valid boolean.</exception>
        public Grammar Parse()
        {

            XmlElement grammarNode = _doc.DocumentElement
                ?? throw new InvalidOperationException("Grammar XML has no root element.");
            string name = grammarNode.Attributes?.GetNamedItem("name")?.Value
                ?? throw new InvalidOperationException("Grammar XML has no 'name' attribute.");
            Grammar g = new Grammar(name);
            foreach (XmlNode ruleNode in grammarNode.SelectNodes("rule")
                ?? throw new InvalidOperationException("Grammar XML 'rule' SelectNodes returned null."))
            {
                string leftName = ruleNode.Attributes?.GetNamedItem("category")?.Value
                    ?? throw new InvalidOperationException("Rule XML has no 'category' attribute.");
                Category left = new Category(leftName);

                List<Category> l = new List<Category>();
                foreach (XmlNode catNode in ruleNode.SelectNodes("category")
                    ?? throw new InvalidOperationException("Rule XML 'category' SelectNodes returned null."))
                {
                    string rightName = catNode.Attributes?.GetNamedItem("name")?.Value
                        ?? throw new InvalidOperationException("Category XML has no 'name' attribute.");
                    bool isTerminal = false;
                    XmlNode? terminalNode = catNode.Attributes?.GetNamedItem("terminal");
                    if (terminalNode != null)
                    {
                        string terminalAsString = terminalNode.Value
                            ?? throw new InvalidOperationException("'terminal' attribute has no value.");
                        isTerminal = bool.Parse(terminalAsString);
                    }
                    Category c = new Category(rightName, isTerminal);
                    l.Add(c);
                }

                ReadOnlyCollection<Category> right = new ReadOnlyCollection<Category>(l);
                Rule r = new Rule(left, right);
                g.AddRule(r);
            }

            return g;
        }

        #endregion
    }
}
