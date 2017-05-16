using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RichTextControls.Lexer.Grammars
{
    public class CSSGrammar : IGrammar
    {
        public CSSGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Multi line comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^\\/\\*(\\*(?!\\/)|[^*])*\\*\\/"),
                },

                // String Marker
                new LexicalRule()
                {
                    Type = TokenType.String,
                    RegExpression = new Regex("^(('(?:[^']|'')*'|'(?:\\.|[^\\']|)*('|\\b))|(\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b)))", RegexOptions.IgnoreCase),
                },

                // Keywords
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = LexicalRule.WordRegex(
                        "@import",
                        "@media"
                    ),
                },
                
                // Selectors
                new LexicalRule()
                {
                    Type = TokenType.Builtins,
                    RegExpression = new Regex("^([^\r\n,{}]+)(,(?=[^}]*{)|\\s*(?={))"),
                },

                // Attributes
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = new Regex("^[\\w\\d#:\\s,-\\.]*-?[\\w\\d#:\\s,-\\.]+(?=;)"),
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
                return "CSS";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
