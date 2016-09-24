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
        [TestMethod()]
        public void GetStringWithLineBreaksTest_WhenInputStringIsNull()
        {
            string input = null;
            string expectedResult = string.Empty;
            int column = 15;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void GetStringWithLineBreaksTest_WhenInputStringIsEmpty()
        {
            string input = string.Empty;
            string expectedResult = string.Empty;
            int column = 15;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),"column")]
        public void GetStringWithLineBreaksTest_WhenColumnValueIsZero()
        {
            string input = "The quick brown fox jumped over the lazy dog.";
            int column = 0;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "column")]
        public void GetStringWithLineBreaksTest_WhenColumnValueIsNegetiveNumber()
        {
            string input = "The quick brown fox jumped over the lazy dog.";
            int column = -10;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "column")]
        public void GetStringWithLineBreaksTest_WhenColumnValueIsGreaterThanInputStringLength()
        {
            string input = "The quick brown fox jumped over the lazy dog.";
            int column = 100;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);
        }

        [TestMethod()]
        public void GetStringWithLineBreaksTest_WhenInputStringIsABigBank()
        {
            string input = "                              ";
            int column = 5;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);
            Assert.AreEqual(string.Empty, actualResult);
        }

        [TestMethod()]
        public void GetStringWithLineBreaksTest_WhenInputStringIsSingleWordWithLengthGreaterThanColumnValue()
        {
            string input = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            int column = 5;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);
            Assert.AreEqual(input, actualResult);
        }
        [TestMethod()]
        public void GetStringWithLineBreaksTest_WhenInputStringContainsWordsWithLengthGreaterThanColumnLength()
        {
            string input = "bbbb aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa ccccc";
            string expectedResult = "bbbb\naaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\nccccc";
            int column = 5;
            AwesomeTextEditor obj = new Problems.AwesomeTextEditor();
            string actualResult = obj.GetStringWithLineBreaks(input, column);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}