using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace RichTextControls.ExampleApp
{
    public sealed partial class HtmlControlTestView : UserControl
    {
        Debouncer _debouncedParseHtml = new Debouncer(TimeSpan.FromMilliseconds(500));

        public HtmlControlTestView()
        {
            InitializeComponent();

            _debouncedParseHtml.Action += (sender, e) =>
            {
                HtmlPreviewTextBlock.Html = HtmlSourceTextBox.Text;
            };

            Loaded += HtmlControlTestView_Loaded;
        }

        private async void HtmlControlTestView_Loaded(object sender, RoutedEventArgs e)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return;

            Loaded -= HtmlControlTestView_Loaded;

            var exampleFile = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\Code\example.html");

            await LoadFromFile(exampleFile);
        }

        private async void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.List,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".html");

            var file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                await LoadFromFile(file);
            }
        }

        private async Task LoadFromFile(StorageFile file)
        {
            try
            {
                var text = await FileIO.ReadTextAsync(file);
                HtmlSourceTextBox.Text = text;
            }
            catch (Exception ex)
            {
                HtmlSourceTextBox.Text = $"Unable to read the file: <em>{ex.Message}</em>";
            }
        }

        private void HtmlSourceTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _debouncedParseHtml.Hit();
        }
    }
}
