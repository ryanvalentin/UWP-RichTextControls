using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;
using RichTextControls.Generators;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;

namespace RichTextControls.Tests.Test_Generators
{
    [TestClass]
    public class Test_HtmlXamlGenerator
    {
        [UITestMethod]
        public void Test_HtmlXamlGenerator_Basic()
        {
            var generator = new HtmlXamlGenerator("<p>test</p>");
            var generatedElement = generator.Generate();

            Assert.IsInstanceOfType(generatedElement, typeof(StackPanel));

            var inlinePanel = generatedElement as StackPanel;

            Assert.AreEqual(1, inlinePanel.Children.Count);
            Assert.IsInstanceOfType(inlinePanel.Children[0], typeof(RichTextBlock));

            var richTextBlock = inlinePanel.Children[0] as RichTextBlock;

            Assert.AreEqual(1, richTextBlock.Blocks.Count);
            Assert.IsInstanceOfType(richTextBlock.Blocks[0], typeof(Paragraph));

            var paragraph = richTextBlock.Blocks[0] as Paragraph;

            Assert.AreEqual((paragraph.Inlines[0] as Run)?.Text, "test");
        }

        [UITestMethod]
        public void Test_HtmlXamlGenerator_EmptyHtml()
        {
            try
            {
                var emptyGenerator = new HtmlXamlGenerator("");
                var emptyGeneratedElement = emptyGenerator.Generate();
            }
            catch (Exception ex)
            {
                Assert.Fail("Generator should work with an empty html string. Exception was: " + ex.Message);
            }
        }

        [UITestMethod]
        public void Test_HtmlXamlGenerator_NullHtml()
        {
            try
            {
                var nullGenerator = new HtmlXamlGenerator(null);
                var nullGeneratedElement = nullGenerator.Generate();
            }
            catch (Exception ex)
            {
                Assert.Fail("Generator should work with an null html string. Exception was: " + ex.Message);
            }
        }

        [UITestMethod]
        public void Test_HtmlXamlGenerator_NestedInlines()
        {
            var generator = new HtmlXamlGenerator("<b><i>test</i></b>");
            var generatedElement = generator.Generate() as StackPanel;
            var firstRichTextBlock = generatedElement.Children[0] as RichTextBlock;

            Assert.AreEqual(1, firstRichTextBlock.Blocks.Count, "Nested inline tags should only produce a single Paragraph block.");

            var paragraph = firstRichTextBlock.Blocks[0] as Paragraph;

            Assert.AreEqual(1, paragraph.Inlines.Count, "Nested inline tags should only produce 1 parent inline.");
            Assert.IsInstanceOfType(paragraph.Inlines[0], typeof(Bold), "Outer <b> inline should generate a Bold.");

            var outerBold = paragraph.Inlines[0] as Bold;

            Assert.AreEqual(1, outerBold.Inlines.Count, "Outer bold tag should have 1 inline child.");
            Assert.IsInstanceOfType(outerBold.Inlines[0], typeof(Italic), "Inner <i> inline should generate an Italic.");

            var innerItalic = outerBold.Inlines[0] as Italic;

            Assert.AreEqual((paragraph.Inlines[0] as Run)?.Text, "test");
        }
    }
}
