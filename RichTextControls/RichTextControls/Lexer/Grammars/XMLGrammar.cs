using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class XMLGrammar : IGrammar
    {
        public XMLGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^(?=<!--)([\\s\\S]*?)-->"),
                },

                // String Marker
                new LexicalRule()
                {
                    Type = TokenType.String,
                    RegExpression = new Regex("^\"[^\"]*(?:\\.[^\"]*)*\"", RegexOptions.IgnoreCase),
                },

                // XML Tag
                new LexicalRule()
                {
                    Type = TokenType.Builtins,
                    RegExpression = new Regex("^<\\/?(\\w|\\.|:)+\\/*>?"),
                },

                // XML Terminating Tags
                new LexicalRule()
                {
                    Type = TokenType.Builtins,
                    RegExpression = new Regex("^(/?>)"),
                },

                // Attribute names
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = new Regex("^[A-Za-z0-9\\._:-]+"),
                },

                // Identifiers
                new LexicalRule ()
                {
                    Type = TokenType.Identifier,
                    RegExpression = new Regex("^[_A-Za-z][_A-Za-z0-9]*")
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
                return "XML";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
