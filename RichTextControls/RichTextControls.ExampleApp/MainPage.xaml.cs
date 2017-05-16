using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RichTextControls.ExampleApp
{
    public sealed partial class MainPage : Page
    {
        Debouncer _debouncedParseHtml = new Debouncer(TimeSpan.FromMilliseconds(500));

        public MainPage()
        {
            InitializeComponent();
        }

        // prevent check
        private void DontCheck(object s, RoutedEventArgs e)
        {
            // don't let the radiobutton check
            (s as RadioButton).IsChecked = false;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainPageSplitView.DisplayMode == SplitViewDisplayMode.Inline)
                MainPageSplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
            else
                MainPageSplitView.DisplayMode = SplitViewDisplayMode.Inline;
        }

        private void HtmlTextBlockRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainPageSplitView.Content = new HtmlControlTestView();
        }

        private void CodeTextBlockRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MainPageSplitView.Content = new CodeControlTestView();
        }
    }
}
