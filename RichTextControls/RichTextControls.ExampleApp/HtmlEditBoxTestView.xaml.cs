using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RichTextControls.ExampleApp
{
    public sealed partial class HtmlEditBoxTestView : Page
    {
        Debouncer _debouncedParseRtf = new Debouncer(TimeSpan.FromMilliseconds(500));

        public HtmlEditBoxTestView()
        {
            InitializeComponent();

            _debouncedParseRtf.Action += (sender, e) =>
            {
                try
                {
                    HtmlSourceEditBox.Document.
                    HtmlSourceEditBox.Document.GetText(Windows.UI.Text.TextGetOptions.FormatRtf, out string formattedRtf);
                    var html = RtfPipe.Rtf.ToHtml(formattedRtf);

                    HtmlPreviewTextBox.Text = html;
                }
                catch (NullReferenceException)
                {
                    return;
                }
            };
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = HtmlSourceEditBox.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Bold = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = HtmlSourceEditBox.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                charFormatting.Italic = Windows.UI.Text.FormatEffect.Toggle;
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.UI.Text.ITextSelection selectedText = HtmlSourceEditBox.Document.Selection;
            if (selectedText != null)
            {
                Windows.UI.Text.ITextCharacterFormat charFormatting = selectedText.CharacterFormat;
                if (charFormatting.Underline == Windows.UI.Text.UnderlineType.None)
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.Single;
                }
                else
                {
                    charFormatting.Underline = Windows.UI.Text.UnderlineType.None;
                }
                selectedText.CharacterFormat = charFormatting;
            }
        }

        private void HtmlSourceEditBox_TextChanged(object sender, RoutedEventArgs e)
        {
            _debouncedParseRtf.Hit();
        }
    }
}
