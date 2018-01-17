[![Build status](https://ci.appveyor.com/api/projects/status/u8m0ml7sxhiu35sv?svg=true)](https://ci.appveyor.com/project/ryanvalentin/uwp-richtextcontrols)

# UWP-RichTextControls

A set of controls for displaying text formats like HTML on the Universal Windows Platform (UWP). Originally ported from the [Disqus app for Windows](https://www.microsoft.com/store/p/disqus/9wzdncrdgctr).

## Controls

### HtmlTextBlock

A control for displaying basic HTML as a native UI.

![HtmlTextBlock screenshot](/screenshots/HtmlTextBlock.png)

#### Basic Usage

Add a reference to the `RichTextControls` namespace in your XAML file.
```xml
xmlns:richText="using:RichTextControls"
```

Now you can use the control in your xaml
```xml
<richText:HtmlTextBlock Html="<p>My <b>HTML</b> test</p>" />
```

#### Limitations

This control was designed for simple HTML markup only (often returned as fragments from a web service), and won't evaluate any kind of styling. Complex HTML documents are better handled using a WebView.

### CodeHighlightedTextBlock

A control for displaying code with basic syntax highlighting.

![CodeHighlightedTextBlock screenshot](/screenshots/CodeHighlightedTextBlock.png)

#### Basic Usage
Add a reference to the `RichTextControls` namespace in your XAML file.
```xml
xmlns:richText="using:RichTextControls"
```

Now you can use the control in your xaml
```xml
<richText:CodeHighlightedTextBlock HighlightLanguage="CSharp" Code="Console.WriteLine(999);"  />
```

#### Supported Languages

- C++
- C#
- CSS
- Java
- JavaScript
- JSON
- PHP
- Python
- Ruby
- SQL
- XML
