// Copyright (c) Adnan Umer. All rights reserved. Follow me @aztnan
// Email: aztnan@outlook.com
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

// Lexer implementation built from this post/source code: 
// https://social.technet.microsoft.com/wiki/contents/articles/26853.winrt-c-developing-lexer-for-syntax-highlighting.aspx

namespace RichTextControls.Lexer
{
    public class Tokenizer
    {
        public Tokenizer(IGrammar grammar)
        {
            Grammar = grammar;
        }

        public IGrammar Grammar { get; private set; }

        public IEnumerable<Token> Tokenize(string script)
        {
            int i = 0;
            int length = script.Length;

            Match match;
            var builder = new StringBuilder(script);

            string str = script;

            while (i < length)
            {
                foreach (var rule in Grammar.Rules)
                {
                    match = rule.RegExpression.Match(str);
                    
                    if (match.Success)
                    {
                        if (match.Length == 0)
                        {
                            throw new Exception(string.Format("Regex match length is zero. This can lead to infinite loop. Please modify your regex {0} for {1} so that it can't match character of zero length", rule.RegExpression, rule.Type));
                        }

                        yield return new Token(i, match.Length, rule.Type);
                        i += match.Length;

                        builder.Remove(0, match.Length);
                        break;
                    }
                }

                str = builder.ToString();
            }
        }
    }
}