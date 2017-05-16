using Windows.UI.Xaml;

namespace RichTextControls.Generators
{
    public interface IHtmlXamlGenerator
    {
        UIElement Generate();

        Style BlockquoteBorderStyle { get; set; }

        Style PreformattedBorderStyle { get; set; }
    }
}
