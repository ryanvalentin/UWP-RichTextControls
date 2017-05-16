using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RichTextControls.Lexer.Grammars
{
    public class PHPGrammar : IGrammar
    {
        public PHPGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Single line comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^(\\/\\/[^\r\n]*)"),
                },

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

                // Literals
                new LexicalRule()
                {
                    Type = TokenType.Number,
                    RegExpression = LexicalRule.WordRegex(
                        "FALSE",
                        "TRUE",
                        "NULL"
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
                        "include_once",
                        "list",
                        "abstract",
                        "global",
                        "private",
                        "echo",
                        "interface",
                        "as",
                        "static",
                        "endswith",
                        "array",
                        "null",
                        "if",
                        "endwhile",
                        "or",
                        "const",
                        "for",
                        "endforeach",
                        "self",
                        "var",
                        "while",
                        "isset",
                        "public",
                        "protected",
                        "exit",
                        "foreach",
                        "throw",
                        "elseif",
                        "include",
                        "__FILE__",
                        "empty",
                        "require_once",
                        "do",
                        "xor",
                        "return",
                        "parent",
                        "clone",
                        "use",
                        "__CLASS__",
                        "__LINE__",
                        "else",
                        "break",
                        "print",
                        "eval",
                        "new",
                        "catch",
                        "__METHOD__",
                        "case",
                        "exception",
                        "default",
                        "die",
                        "require",
                        "__FUNCTION__",
                        "enddeclare",
                        "final",
                        "try",
                        "switch",
                        "continue",
                        "endfor",
                        "endif",
                        "declare",
                        "unset",
                        "true",
                        "false",
                        "trait",
                        "goto",
                        "instanceof",
                        "insteadof",
                        "__DIR__",
                        "__NAMESPACE__",
                        "yield",
                        "finally"
                    ),
                },

                new LexicalRule()
                {
                    Type = TokenType.Builtins,
                    RegExpression = LexicalRule.WordRegex(
                        "\\$GLOBALS",
                        "\\$_SERVER",
                        "\\$_REQUEST",
                        "\\$_POST",
                        "\\$_GET",
                        "\\$_FILES",
                        "\\$_ENV",
                        "\\$_COOKIE",
                        "\\$_SESSION"
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
                return "PHP";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
