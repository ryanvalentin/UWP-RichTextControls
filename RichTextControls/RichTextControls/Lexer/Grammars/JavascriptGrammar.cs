using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class JavascriptGrammar : IGrammar
    {
        public JavascriptGrammar()
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
                    RegExpression = new Regex("^((@'(?:[^']|'')*'|'(?:\\.|[^\\']|)*('|\\b))|(@\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b)))", RegexOptions.IgnoreCase),
                },

                // Literals
                new LexicalRule()
                {
                    Type = TokenType.Number,
                    RegExpression = LexicalRule.WordRegex(
                        "true",
                        "false",
                        "undefined",
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

                // Single Char Operator
                new LexicalRule()
                {
                    Type = TokenType.Operator,
                    RegExpression = new Regex("^[\\+\\-\\*/%&|\\^~<>!]"),
                },

                // Double/Triple character comparison operators
                new LexicalRule()
                {
                    Type = TokenType.Operator,
                    RegExpression = new Regex("^((===?)|(!==?)|(<==?)|(>==?)|(<<)|(>>>?)|(//)|(\\*\\*))"),
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
                        "arguments", 
                        "break", 
                        "case", 
                        "catch", 
                        "class", 
                        "const", 
                        "continue", 
                        "debugger", 
                        "default", 
                        "delete", 
                        "do", 
                        "else", 
                        "export", 
                        "extends", 
                        "finally", 
                        "for", 
                        "function", 
                        "if", 
                        "import", 
                        "in", 
                        "instanceof", 
                        "new", 
                        "return",
                        "super", 
                        "switch", 
                        "this", 
                        "throw", 
                        "try", 
                        "typeof", 
                        "var", 
                        "void", 
                        "while", 
                        "with", 
                        "yield",
                        "enum", 
                        "implements", 
                        "interface", 
                        "let", 
                        "package", 
                        "await", 
                        "private", 
                        "protected", 
                        "public", 
                        "static", 
                        "console"
                    ),
                },

                // Built in objects
                new LexicalRule() {
                    Type = TokenType.Builtins,
                    RegExpression = LexicalRule.WordRegex(
                        "Infinity", 
                        "NaN", 
                        "Object", 
                        "Function", 
                        "Boolean", 
                        "Symbol", 
                        "Error",
                        "EvalError", 
                        "InternalError", 
                        "RangeError", 
                        "ReferenceError", 
                        "SyntaxError",
                        "TypeError", 
                        "URIError", 
                        "Number", 
                        "Math", 
                        "Date",
                        "String", 
                        "RegExp", 
                        "Array", 
                        "Int8Array", 
                        "Uint8Array",
                        "Uint8ClampedArray", 
                        "Int16Array", 
                        "Uint16Array", 
                        "Int32Array", 
                        "Uint32Array",
                        "Float32Array", 
                        "Float64Array", 
                        "Map", 
                        "Set",
                        "WeakMap", 
                        "WeakSet", 
                        "ArrayBuffer", 
                        "DataView",
                        "JSON", 
                        "Promise", 
                        "Generator", 
                        "GeneratorFunction", 
                        "Reflect",
                        "Proxy",
                        "Intl", 
                        "WebAssembly"
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
                return "Javascript";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
