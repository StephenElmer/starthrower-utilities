/***********************************************************************************
    StarThrower Utilities / EarleyParser
    Copyright (C) 2005-2026  Stephen Elmer

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
***********************************************************************************/

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
