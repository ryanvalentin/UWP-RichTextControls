using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class JSONGrammar : IGrammar
    {
        public JSONGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Key marker
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = new Regex("^\"[^\"]*(?:\\.[^\"]*)*\"(?=\\:)", RegexOptions.IgnoreCase),
                },

                // String Marker
                new LexicalRule()
                {
                    Type = TokenType.String,
                    RegExpression = new Regex("^\"[^\"]*(?:\\.[^\"]*)*\"", RegexOptions.IgnoreCase),
                },

                // Literals
                new LexicalRule()
                {
                    Type = TokenType.Number,
                    RegExpression = LexicalRule.WordRegex(
                        "true",
                        "false",
                        "null"
                    ),
                },

                // Numbers
                new LexicalRule()
                {
                    Type = TokenType.Number,
                    RegExpression = new Regex("^\\d+(((\\.)|(x))\\d*)?"),
                },

                // Whitespace
                new LexicalRule()
                {
                    Type = TokenType.WhiteSpace,
                    RegExpression = new Regex("^\\s"),
                }, 
                
                // Any
                new LexicalRule()
                {
                    Type = TokenType.Unknown,
                    RegExpression = new Regex("^."),
                },
            };

        }

        public string Name
        {
            get
            {
                return "JSON";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
