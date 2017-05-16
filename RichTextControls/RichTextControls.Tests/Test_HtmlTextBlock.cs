using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting.AppContainer;

namespace RichTextControls.Tests
{
    [TestClass]
    public class Test_HtmlTextBlock
    {
        [UITestMethod]
        public void Test_HtmlTextBlock_Basic()
        {
            try
            {
                var htmlTextBlock = new HtmlTextBlock();
            }
            catch (Exception ex)
            {
                Assert.Fail("Generator should work with an empty html string. Exception was: " + ex.Message);
            }
        }
    }
}
