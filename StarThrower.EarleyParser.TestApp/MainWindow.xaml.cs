using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using StarThrower.EarleyParser;

namespace StarThrower.EarleyParser.TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region [ Construction ]

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion


        #region [ Control Event Handlers ]

        private void btnParseGrammar_Click(object sender, RoutedEventArgs e)
        {
            string grammarFile = txtGrammar.Text.Trim();
            if (!File.Exists(grammarFile))
            {
                MessageBox.Show("Grammar file not found.");
                return;
            }

            GrammarParser parser = new GrammarParser(grammarFile);
            Grammar grammar = parser.Parse();
            MessageBox.Show(grammar.ToString());
        }

        private void btnParseInput_Click(object sender, RoutedEventArgs e)
        {
            string grammarFile = txtGrammar.Text.Trim();
            if (!File.Exists(grammarFile))
            {
                MessageBox.Show("Grammar file not found.");
                return;
            }

            string inputFile = txtInput.Text.Trim();
            if (!File.Exists(inputFile))
            {
                MessageBox.Show("Input file not found.");
                return;
            }

            GrammarParser grammarParser = new GrammarParser(grammarFile);
            Grammar grammar = grammarParser.Parse();

            string input = File.ReadAllText(inputFile);
            string[]? tokens = null;
            if (rbLex.IsChecked.HasValue && rbLex.IsChecked.Value)
            {
                bool ignoreWhitespace = (chkIgnoreWhitespace.IsChecked.HasValue && chkIgnoreWhitespace.IsChecked.Value);
                tokens = Lex(input, ignoreWhitespace);
            }
            else
            {
                tokens = Tokenize(input);
            }

            Category seed = new Category("S");

            ParserOptions options = new ParserOptions();
            options.IgnoreCase = (rbIgnoreCaseYes.IsChecked.HasValue && rbIgnoreCaseYes.IsChecked.Value);
            options.PredictPreterminals = (rbPredictPreterminalsYes.IsChecked.HasValue && rbPredictPreterminalsYes.IsChecked.Value);
            Parser inputParser = new Parser(grammar, options);
            Parse parse = inputParser.Parse(tokens, seed);


            StringBuilder b = new StringBuilder();
            b.AppendLine(grammar.ToString());
            b.AppendLine();
            b.AppendLine(input);
            b.AppendLine();
            b.AppendLine(parse.ToString());
            MessageBox.Show(b.ToString());
        }

        private void btnBrowseGrammar_Click(object sender, RoutedEventArgs e)
        {
            string oldFileName = txtGrammar.Text.Trim();

            string? folder = System.IO.Path.GetDirectoryName(oldFileName);
            string file = System.IO.Path.GetFileName(oldFileName);

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = folder ?? string.Empty;
            dlg.FileName = file;
            dlg.Multiselect = false;
            dlg.Filter = "XML Files (*.xml)|*.xml";
            var result = dlg.ShowDialog(this);
            if (result.HasValue && result.Value)
            {
                txtGrammar.Text = dlg.FileName;
            }
        }

        private void btnBrowseInput_Click(object sender, RoutedEventArgs e)
        {
            string oldFileName = txtInput.Text.Trim();

            string? folder = System.IO.Path.GetDirectoryName(oldFileName);
            string file = System.IO.Path.GetFileName(oldFileName);

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = folder ?? string.Empty;
            dlg.FileName = file;
            dlg.Multiselect = false;
            dlg.Filter = "Text Files (*.txt)|*.txt";
            var result = dlg.ShowDialog(this);
            if (result.HasValue && result.Value)
            {
                txtInput.Text = dlg.FileName;
            }
        }

        private void rbLex_Checked(object sender, RoutedEventArgs e)
        {
            chkIgnoreWhitespace.IsEnabled = true;
        }

        private void rbTokenize_Checked(object sender, RoutedEventArgs e)
        {
            chkIgnoreWhitespace.IsEnabled = false;
        }

        #endregion


        #region [ Private Methods ]

        private string[] Lex(string text, bool ignoreWhitespace)
        {
            List<string> r = new List<string>();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (ignoreWhitespace && Char.IsWhiteSpace(c))
                {
                    continue;
                }

                if (i == 0)
                {
                    r.Add(c.ToString());
                }
                else
                {
                    r.Add(c.ToString());
                }
            }
            return r.ToArray();
        }

        private string[] Tokenize(string text)
        {
            return text.Split(new char[] { ' ' });
        }

        #endregion


        private void test()
        {

        }

    }
}
