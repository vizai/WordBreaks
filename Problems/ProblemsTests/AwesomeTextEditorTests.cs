using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems.Tests
{
    [TestClass()]
    public class AwesomeTextEditorTests
    {
        [TestMethod()]
        public void GetStringWithLineBreaksTest()
        {
            string input = "The quick brown fox jumped over the lazy dog.";
            string expectedResult = "The quick brown\nfox jumped over\nthe lazy dog.";
            int column = 15;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult=obj.GetStringWithLineBreaks(input, column);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}