using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RichTextControls.Lexer.Grammars
{
    class JavaGrammar : IGrammar
    {
        public JavaGrammar()
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
                        "assert",
                        "boolean",
                        "break",
                        "byte",
                        "case",
                        "catch",
                        "char",
                        "class",
                        "const",
                        "continue",
                        "default",
                        "do",
                        "double",
                        "else",
                        "enum",
                        "extends",
                        "final",
                        "finally",
                        "float",
                        "for",
                        "if",
                        "goto",
                        "implements",
                        "import",
                        "instanceof",
                        "int",
                        "interface",
                        "long",
                        "native",
                        "new",
                        "package",
                        "private",
                        "protected",
                        "public",
                        "return",
                        "short",
                        "static",
                        "strictfp",
                        "super",
                        "switch",
                        "synchronized",
                        "this",
                        "throw",
                        "throws",
                        "transient",
                        "try",
                        "void",
                        "volatile",
                        "while"
                    ),
                },

                // Commonly-used classes (generally part of `Java.lang` namespace)
                new LexicalRule() {
                    Type = TokenType.Builtins,
                    RegExpression = LexicalRule.WordRegex(
                        "Boolean",
                        "Byte",
                        "Character",
                        "Class",
                        "Enum",
                        "Double",
                        "Package",
                        "Process",
                        "ProcessBuilder",
                        "Runtime",
                        "RuntimePermission",
                        "Short",
                        "StackTraceElement",
                        "StrictMath",
                        "String",
                        "StringBuffer",
                        "StringBuilder",
                        "System",
                        "Thread",
                        "ThreadGroup",
                        "ThreadLocal",
                        "Throwable",
                        "Void"
                    ),
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
                return "Java";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
