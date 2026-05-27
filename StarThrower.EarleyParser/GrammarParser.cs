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

            XmlElement grammarNode = _doc.DocumentElement;
            string name = grammarNode.Attributes.GetNamedItem("name").Value;
            Grammar g = new Grammar(name);
            foreach (XmlNode ruleNode in grammarNode.SelectNodes("rule"))
            {
                string leftName = ruleNode.Attributes.GetNamedItem("category").Value;
                Category left = new Category(leftName);

                List<Category> l = new List<Category>();
                foreach (XmlNode catNode in ruleNode.SelectNodes("category"))
                {
                    string rightName = catNode.Attributes.GetNamedItem("name").Value;
                    bool isTerminal = false;
                    if (catNode.Attributes.GetNamedItem("terminal") != null)
                    {
                        string terminalAsString = catNode.Attributes.GetNamedItem("terminal").Value;
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
