using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class RubyGrammar : IGrammar
    {
        public RubyGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Single line comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^(#[^\r\n]*)"),
                },

                // Multi line comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^=begin([^*])*\\=end"),
                },

                // String Marker
                new LexicalRule()
                {
                    Type = TokenType.String,
                    RegExpression = new Regex("^(('(?:[^']|'')*'|'(?:\\.|[^\\']|)*('|\\b))|(\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b)))", RegexOptions.IgnoreCase),
                },

                // Function/class signatures
                new LexicalRule()
                {
                    Type = TokenType.Builtins,

                    // TODO: Get this working as expected
                    RegExpression = new Regex(@"^(?<=(def|class)\s*)([\w\d\:]+)(?=[\s])", RegexOptions.IgnoreCase),
                },

                // Literals
                new LexicalRule()
                {
                    Type = TokenType.Number,
                    RegExpression = LexicalRule.WordRegex(
                        "true",
                        "false",
                        "nil"
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

                // Keywords
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = LexicalRule.WordRegex(
                        "and",
                        "then",
                        "def",
                        "defined",
                        "module",
                        "in",
                        "return",
                        "redo",
                        "if",
                        "BEGIN",
                        "retry",
                        "end",
                        "for",
                        "self",
                        "when",
                        "next",
                        "until",
                        "do",
                        "begin",
                        "unless",
                        "END",
                        "rescue",
                        "else",
                        "break",
                        "undef",
                        "not",
                        "super",
                        "class",
                        "case",
                        "require",
                        "raise",
                        "yield",
                        "alias",
                        "while",
                        "ensure",
                        "elsif",
                        "or",
                        "include",
                        "attr_reader",
                        "attr_writer",
                        "attr_accessor"
                    ),
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
                return "Ruby";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
