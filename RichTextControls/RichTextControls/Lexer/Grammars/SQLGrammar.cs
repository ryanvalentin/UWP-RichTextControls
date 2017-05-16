using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RichTextControls.Lexer.Grammars
{
    public class SQLGrammar : IGrammar
    {
        public SQLGrammar()
        {
            Rules = new List<LexicalRule>()
            {
                // Single-line Comment
                new LexicalRule()
                {
                    Type = TokenType.Comment,
                    RegExpression = new Regex("^(--|#)[^\r\n]*"),
                },

                // Whitespace
                new LexicalRule ()
                {
                    Type = TokenType.WhiteSpace,
                    RegExpression = new Regex("^\\s")
                },

                // Multi-line comment
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

                // Keywords
                new LexicalRule()
                {
                    Type = TokenType.Keyword,
                    RegExpression = LexicalRule.WordRegexCaseInsensitive(
                        "abort",
                        "action",
                        "add",
                        "after",
                        "all",
                        "alter",
                        "analyze",
                        "and",
                        "as",
                        "asc",
                        "attach",
                        "autoincrement",
                        "before",
                        "begin",
                        "between",
                        "by",
                        "cascade",
                        "case",
                        "cast",
                        "check",
                        "collate",
                        "column",
                        "commit",
                        "conflict",
                        "constraint",
                        "create",
                        "cross",
                        "current_date",
                        "current_time",
                        "current_timestamp",
                        "database",
                        "default",
                        "deferrable",
                        "deferred",
                        "delete",
                        "desc",
                        "detach",
                        "distinct",
                        "drop",
                        "each",
                        "else",
                        "end",
                        "escape",
                        "except",
                        "exclusive",
                        "exists",
                        "explain",
                        "fail",
                        "for",
                        "foreign",
                        "from",
                        "full",
                        "glob",
                        "group",
                        "having",
                        "if",
                        "ignore",
                        "immediate",
                        "in",
                        "index",
                        "indexed",
                        "initially",
                        "inner",
                        "insert",
                        "instead",
                        "intersect",
                        "into",
                        "is",
                        "isnull",
                        "join",
                        "key",
                        "left",
                        "like",
                        "limit",
                        "match",
                        "natural",
                        "no",
                        "not",
                        "notnull",
                        "null",
                        "of",
                        "offset",
                        "on",
                        "or",
                        "order",
                        "outer",
                        "plan",
                        "pragma",
                        "primary",
                        "query",
                        "raise",
                        "recursive",
                        "references",
                        "regexp",
                        "reindex",
                        "release",
                        "rename",
                        "replace",
                        "restrict",
                        "right",
                        "rollback",
                        "row",
                        "savepoint",
                        "select",
                        "set",
                        "table",
                        "temp",
                        "temporary",
                        "then",
                        "to",
                        "transaction",
                        "trigger",
                        "union",
                        "unique",
                        "update",
                        "using",
                        "vacuum",
                        "values",
                        "view",
                        "virtual",
                        "when",
                        "where",
                        "with",
                        "without"
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
                return "SQL";
            }
        }

        public List<LexicalRule> Rules { get; private set; }
    }
}
