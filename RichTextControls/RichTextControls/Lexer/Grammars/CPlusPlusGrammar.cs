using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class CPlusPlusGrammar : IGrammar
    {
        public CPlusPlusGrammar()
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
                    RegExpression = new Regex("^(\"(?:[^\"]|\"\")*\"|\"(?:\\.|[^\\\"])*(\"|\\b))", RegexOptions.IgnoreCase),
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
                        "NULL",
                        "nullptr"
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
                        "int",
                        "float",
                        "while",
                        "private",
                        "char",
                        "catch",
                        "import",
                        "module",
                        "export",
                        "virtual",
                        "operator",
                        "sizeof",
                        "dynamic_cast|10",
                        "typedef",
                        "const_cast|10",
                        "const",
                        "for",
                        "static_cast|10",
                        "union",
                        "namespace",
                        "unsigned",
                        "long",
                        "volatile",
                        "static",
                        "protected",
                        "bool",
                        "template",
                        "mutable",
                        "if",
                        "public",
                        "friend",
                        "do",
                        "goto",
                        "auto",
                        "void",
                        "enum",
                        "else",
                        "break",
                        "extern",
                        "using",
                        "asm",
                        "case",
                        "typeid",
                        "short",
                        "retinterpret_cast|10",
                        "default",
                        "double",
                        "register",
                        "explicit",
                        "signed",
                        "typename",
                        "try",
                        "this",
                        "switch",
                        "continue",
                        "inline",
                        "delete",
                        "alignof",
                        "constexpr",
                        "decltype",
                        "noexcept",
                        "static_assert",
                        "thread_local",
                        "restrict",
                        "_Bool",
                        "complex",
                        "_Complex",
                        "_Imaginary",
                        "atomic_bool",
                        "atomic_char",
                        "atomic_schar",
                        "atomic_uchar",
                        "atomic_short",
                        "atomic_ushort",
                        "atomic_int",
                        "atomic_uint",
                        "atomic_long",
                        "atomic_ulong",
                        "atomic_llong",
                        "atomic_ullong",
                        "new",
                        "throw",
                        "return",
                        "and",
                        "or",
                        "not"
                    ),
                },

                // Commonly-used classes (generally part of `System` namespace)
                new LexicalRule() {
                    Type = TokenType.Builtins,
                    RegExpression = LexicalRule.WordRegex(
                        "std",
                        "string",
                        "cin",
                        "cout",
                        "cerr",
                        "clog",
                        "stdin",
                        "stdout",
                        "stderr",
                        "stringstream",
                        "istringstream",
                        "ostringstream",
                        "auto_ptr",
                        "deque",
                        "list",
                        "queue",
                        "stack",
                        "vector",
                        "map",
                        "set",
                        "bitset",
                        "multiset",
                        "multimap",
                        "unordered_set",
                        "unordered_map",
                        "unordered_multiset",
                        "unordered_multimap",
                        "array",
                        "shared_ptr",
                        "abort",
                        "abs",
                        "acos",
                        "asin",
                        "atan2",
                        "atan",
                        "calloc",
                        "ceil",
                        "cost",
                        "cos",
                        "exit",
                        "exp",
                        "fabs",
                        "floor",
                        "fmod",
                        "fprintf",
                        "fputs",
                        "free",
                        "frexp",
                        "fscanf",
                        "isalnum",
                        "isalpha",
                        "iscntrl",
                        "isdigit",
                        "isgraph",
                        "islower",
                        "isprint",
                        "ispunct",
                        "isspace",
                        "isupper",
                        "isxdigit",
                        "tolower",
                        "toupper",
                        "labs",
                        "ldexp",
                        "log10",
                        "log",
                        "malloc",
                        "realloc",
                        "memchr",
                        "memcmp",
                        "memcpy",
                        "memset",
                        "modf",
                        "pow",
                        "printf",
                        "putchar",
                        "puts",
                        "scanf",
                        "sinh",
                        "sin",
                        "snprintf",
                        "sprintf",
                        "sqrt",
                        "sscanf",
                        "strcat",
                        "strchr",
                        "strcmp",
                        "strcpy",
                        "strcspn",
                        "strlen",
                        "strncat",
                        "strncmp",
                        "strncpy",
                        "strpbrk",
                        "strrchr",
                        "strspn",
                        "strstr",
                        "tanh",
                        "tan",
                        "vfprintf",
                        "vprintf",
                        "vsprintf",
                        "endl",
                        "initializer_list",
                        "unique_ptr"
                    ),
                },

                // Identifier
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
                return "C++";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
