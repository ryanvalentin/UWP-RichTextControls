using RichTextControls.Lexer;
using RichTextControls.Lexer.Grammars;
using System;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;

namespace RichTextControls
{
    public class CodeHighlightedTextBlock : Control
    {
        private Border _rootElement;

        /// <summary>
        /// Gets or sets the color of code comments.
        /// </summary>
        public SolidColorBrush CommentBrush
        {
            get { return (SolidColorBrush)GetValue(CommentBrushProperty); }
            set { SetValue(CommentBrushProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="CommentBrush"/>.
        /// </summary>
        public static readonly DependencyProperty CommentBrushProperty = DependencyProperty.Register(
            nameof(CommentBrush),
            typeof(SolidColorBrush),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(new SolidColorBrush(Colors.DarkGreen))
        );

        /// <summary>
        /// Gets or sets the color of code identifiers.
        /// </summary>
        public SolidColorBrush IdentifierBrush
        {
            get { return (SolidColorBrush)GetValue(IdentifierBrushProperty); }
            set { SetValue(IdentifierBrushProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="IdentifierBrush"/>.
        /// </summary>
        public static readonly DependencyProperty IdentifierBrushProperty = DependencyProperty.Register(
            nameof(IdentifierBrush),
            typeof(SolidColorBrush),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the color of code strings.
        /// </summary>
        public SolidColorBrush StringBrush
        {
            get { return (SolidColorBrush)GetValue(StringBrushProperty); }
            set { SetValue(StringBrushProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="StringBrush"/>.
        /// </summary>
        public static readonly DependencyProperty StringBrushProperty = DependencyProperty.Register(
            nameof(StringBrush),
            typeof(SolidColorBrush),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(new SolidColorBrush(Colors.DarkRed))
        );

        /// <summary>
        /// Gets or sets the color of code builtins.
        /// </summary>
        public SolidColorBrush BuiltinBrush
        {
            get { return (SolidColorBrush)GetValue(BuiltinBrushProperty); }
            set { SetValue(BuiltinBrushProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="BuiltinBrush"/>.
        /// </summary>
        public static readonly DependencyProperty BuiltinBrushProperty = DependencyProperty.Register(
            nameof(BuiltinBrush),
            typeof(SolidColorBrush),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(new SolidColorBrush(Colors.DarkSeaGreen))
        );

        /// <summary>
        /// Gets or sets the color of code keywords.
        /// </summary>
        public SolidColorBrush KeywordBrush
        {
            get { return (SolidColorBrush)GetValue(KeywordBrushProperty); }
            set { SetValue(KeywordBrushProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="KeywordBrush"/>.
        /// </summary>
        public static readonly DependencyProperty KeywordBrushProperty = DependencyProperty.Register(
            nameof(KeywordBrush),
            typeof(SolidColorBrush),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(new SolidColorBrush(Colors.Blue))
        );

        /// <summary>
        /// Gets or sets the color of code numerics.
        /// </summary>
        public SolidColorBrush NumberBrush
        {
            get { return (SolidColorBrush)GetValue(NumberBrushProperty); }
            set { SetValue(NumberBrushProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="NumberBrush"/>.
        /// </summary>
        public static readonly DependencyProperty NumberBrushProperty = DependencyProperty.Register(
            nameof(NumberBrush),
            typeof(SolidColorBrush),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(new SolidColorBrush(Colors.Purple))
        );

        /// <summary>
        /// Gets or sets the language of the code for syntax highlighting.
        /// </summary>
        public HighlightLanguage HighlightLanguage
        {
            get { return (HighlightLanguage)GetValue(HighlightLanguageProperty); }
            set { SetValue(HighlightLanguageProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="HighlightLanguage"/>.
        /// </summary>
        public static readonly DependencyProperty HighlightLanguageProperty = DependencyProperty.Register(
            nameof(HighlightLanguage),
            typeof(HighlightLanguage),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata(HighlightLanguage.PlainText, OnCodeChanged)
        );

        /// <summary>
        /// Gets or sets the code body to highlight.
        /// </summary>
        public string Code
        {
            get { return (string)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        /// <summary>
        /// Gets the dependency property for <see cref="Code"/>.
        /// </summary>
        public static readonly DependencyProperty CodeProperty = DependencyProperty.Register(
            nameof(Code),
            typeof(string),
            typeof(CodeHighlightedTextBlock),
            new PropertyMetadata("", OnCodeChanged)
        );

        private static void OnCodeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as CodeHighlightedTextBlock;
            if (control == null)
                return;

            control.RenderCode();
        }

        public CodeHighlightedTextBlock()
        {
            DefaultStyleKey = typeof(CodeHighlightedTextBlock);
        }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _rootElement = GetTemplateChild("RootElement") as Border;

            RenderCode();
        }

        private void RenderCode()
        {
            if (_rootElement == null || String.IsNullOrEmpty(Code))
                return;

            try
            {
                IGrammar grammar = null;

                switch (HighlightLanguage)
                {
                    case HighlightLanguage.Python:
                        grammar = new PythonGrammar();
                        break;
                    case HighlightLanguage.JavaScript:
                        grammar = new JavascriptGrammar();
                        break;
                    case HighlightLanguage.CSharp:
                        grammar = new CSharpGrammar();
                        break;
                    case HighlightLanguage.XML:
                        grammar = new XMLGrammar();
                        break;
                    case HighlightLanguage.JSON:
                        grammar = new JSONGrammar();
                        break;
                    case HighlightLanguage.SQL:
                        grammar = new SQLGrammar();
                        break;
                    case HighlightLanguage.PHP:
                        grammar = new PHPGrammar();
                        break;
                    case HighlightLanguage.Ruby:
                        grammar = new RubyGrammar();
                        break;
                    case HighlightLanguage.CPlusPlus:
                        grammar = new CPlusPlusGrammar();
                        break;
                    case HighlightLanguage.CSS:
                        grammar = new CSSGrammar();
                        break;
                    case HighlightLanguage.Java:
                        grammar = new JavaGrammar();
                        break;
                    default:
                        break;
                }
                
                var textBlock = new RichTextBlock();
                var paragraph = new Paragraph()
                {
                    FontFamily = new FontFamily("Consolas"),
                };
                
                if (grammar != null)
                {
                    Tokenizer lexer = new Tokenizer(grammar);

                    StringBuilder builder = new StringBuilder();

                    foreach (var token in lexer.Tokenize(Code))
                    {
                        var brush = BrushForTokenType(token.Type);
                        if (brush != null)
                        {
                            if (builder.Length > 0)
                            {
                                paragraph.Inlines.Add(new Run() { Text = builder.ToString() });
                                builder.Clear();
                            }

                            paragraph.Inlines.Add(new Run()
                            {
                                Text = Code.Substring(token.StartIndex, token.Length),
                                Foreground = brush,
                            });
                        }
                        else
                        {
                            builder.Append(Code.Substring(token.StartIndex, token.Length));
                        }
                    }

                    if (builder.Length > 0)
                    {
                        paragraph.Inlines.Add(new Run() { Text = builder.ToString() });
                        builder.Clear();
                    }
                }
                else
                {
                    var run = new Run()
                    {
                        Text = Code,
                    };
                    paragraph.Inlines.Add(run);
                }

                textBlock.Blocks.Add(paragraph);
                _rootElement.Child = textBlock;
            }
            catch (Exception ex)
            {
                _rootElement.Child = new TextBlock() { Text = $"Unable to display this code. The error was: {ex.Message}" };
            }
        }

        private SolidColorBrush BrushForTokenType(TokenType tokenType)
        {
            switch (tokenType)
            {
                case TokenType.Builtins:
                    return BuiltinBrush;
                case TokenType.Comment:
                    return CommentBrush;
                case TokenType.Identifier:
                    return IdentifierBrush;
                case TokenType.Keyword:
                    return KeywordBrush;
                case TokenType.Number:
                    return NumberBrush;
                case TokenType.String:
                    return StringBrush;
                default:
                    return null;
            }
        }
    }
}
