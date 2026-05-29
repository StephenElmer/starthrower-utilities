using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace StarThrower.EarleyParser
{
    public class GrammarParser
    {
        #region [ Private Instance Variables ]

        private XmlDocument _doc;

        #endregion


        #region [ Construction ]

        public GrammarParser(XmlDocument doc)
        {
            _doc = doc;
        }

        public GrammarParser(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException("file not found", fileName);

            _doc = new XmlDocument();

            try
            {
                _doc.Load(fileName);
            }
            catch
            {
                throw;
            }
        }

        #endregion


        #region [ Public Methods ]

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
