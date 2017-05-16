using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class CSharpGrammar : IGrammar
    {
        public CSharpGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Single line comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^(\\/\\/\\/?[^\r\n]*)"),
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
                    RegExpression = new Regex("^([@|$]\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b))", RegexOptions.IgnoreCase),
                },

                // Char Marker
                new LexicalRule()
                {
                    Type = TokenType.String,
                    RegExpression = new Regex("^('(\\w\\d){1}')", RegexOptions.IgnoreCase),
                },

                // Numbers
                new LexicalRule()
                {
                    Type = TokenType.Number,
                    RegExpression = new Regex("^\\d+(((\\.)|(x))\\d*)?"),
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

                // Whitespace
                new LexicalRule()
                {
                    Type = TokenType.WhiteSpace,
                    RegExpression = new Regex("^\\s"),
                },

                // Single Char Operator
                new LexicalRule()
                {
                    Type = TokenType.Operator,
                    RegExpression = new Regex("^[\\+\\-\\*/%&|\\^~<>!]"),
                },

                // Double character comparison operators
                new LexicalRule()
                {
                    Type = TokenType.Operator,
                    RegExpression = new Regex("^((==)|(!=)|(<=)|(>=)|(<<)|(>>>?)|(//)|(\\*\\*))"),
                },

                // Single Delimiter
                new LexicalRule()
                {
                    Type = TokenType.Delimiter,
                    RegExpression = new Regex("^[\\(\\)\\[\\]\\{\\}@,:`=;\\.]"),
                },

                // Double Char Operator
                new LexicalRule()
                {
                    Type = TokenType.Delimiter,
                    RegExpression = new Regex("^((\\+=)|(\\-=)|(\\*=)|(%=)|(/=)|(\\++)|(\\--))"),
                },

                // Triple Delimiter
                new LexicalRule()
                {
                    Type = TokenType.Delimiter,
                    RegExpression = new Regex("^((//=)|(>>=)|(<<=)|(\\*\\*=))"),
                }, 

                // Keywords
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = LexicalRule.WordRegex(
                        "abstract",
                        "as",
                        "base",
                        "bool",
                        "break",
                        "byte",
                        "case",
                        "catch",
                        "char",
                        "checked",
                        "class",
                        "const",
                        "continue",
                        "decimal",
                        "default",
                        "delegate",
                        "do",
                        "double",
                        "else",
                        "enum",
                        "event",
                        "explicit",
                        "extern",
                        "finally",
                        "fixed",
                        "float",
                        "for",
                        "foreach",
                        "goto",
                        "if",
                        "implicit",
                        "in",
                        "int",
                        "interface",
                        "internal",
                        "is",
                        "lock",
                        "long",
                        "namespace",
                        "new",
                        "object",
                        "operator",
                        "out",
                        "override",
                        "params",
                        "private",
                        "protected",
                        "public",
                        "readonly",
                        "ref",
                        "return",
                        "sbyte",
                        "sealed",
                        "short",
                        "sizeof",
                        "stackalloc",
                        "static",
                        "string",
                        "struct",
                        "switch",
                        "this",
                        "throw",
                        "try",
                        "typeof",
                        "uint",
                        "ulong",
                        "unchecked",
                        "unsafe",
                        "ushort",
                        "using",
                        "void",
                        "volatile",
                        "while"
                    ),
                },

                // Commonly-used classes (usually part of `System` namespace)
                new LexicalRule() {
                    Type = TokenType.Builtins,
                    RegExpression = LexicalRule.WordRegex(
                        "Boolean",
                        "Byte",
                        "Console",
                        "SByte",
                        "Char",
                        "Decimal",
                        "Double",
                        "Enum",
                        "Single",
                        "Int32",
                        "UInt32",
                        "Int64",
                        "UInt64",
                        "Object",
                        "Int16",
                        "UInt16",
                        "String",
                        "StringBuilder",
                        "Exception",
                        "Guid",
                        "DateTime",
                        "DateTimeOffset",
                        "TimeSpan",
                        "Uri",
                        "UriKind",
                        "StringBuilder"
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
                return "C#";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
