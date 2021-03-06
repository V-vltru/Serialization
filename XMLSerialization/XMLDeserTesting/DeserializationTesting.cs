﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLSerializationLibrary;

namespace XMLDeserTesting
{
    [TestClass]
    public class DeserializationTesting
    {
        [TestMethod]
        public void TestGetMainTag()
        {
            string xml = "<a type = \"open\">123</a>";
            string expected = "a";
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);
            string fact = deserialization.GetMainTag(deserialization.XML_String);

            Assert.AreEqual(expected, fact);
        }
        [TestMethod]
        public void TestGetMainTag2()
        {
            string xml = "<a>123</a>";
            string expected = "a";
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);
            string fact = deserialization.GetMainTag(deserialization.XML_String);

            Assert.AreEqual(expected, fact);
        }
        [TestMethod]
        public void TestContentDefinition()
        {
            string xml = "<a>123</a>";
            TagContent content = TagContent.Content;
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);
            TagContent factContent = deserialization.DefineTagContent(deserialization.XML_String);

            Assert.AreEqual(content, factContent);
        }
        [TestMethod]
        public void TestContentDefinition2()
        {
            string xml = "<a><b>123</b></a>";
            TagContent content = TagContent.Tree;
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);
            TagContent factContent = deserialization.DefineTagContent(deserialization.XML_String);

            Assert.AreEqual(content, factContent);
        }

        [TestMethod]
        public void TestGettingContent()
        {
            string xml = "<a>123</a>";
            string expected = "123";
            string expectedOutStr = "";
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);
            string outStr;

            string fact = deserialization.GetContent(deserialization.XML_String, out outStr);

            Assert.AreEqual(expected, fact);
            Assert.AreEqual(expectedOutStr, outStr);
        }

        [TestMethod]
        public void TestGettingContent2()
        {
            string xml = "<a type = \"open\">123</a><b>1</b>";
            string expected = "123";
            string expectedOutStr = "<b>1</b>";
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);
            string outStr;

            string fact = deserialization.GetContent(deserialization.XML_String, out outStr);

            Assert.AreEqual(expected, fact);
            Assert.AreEqual(expectedOutStr, outStr);
        }

        [TestMethod]
        public void TestIsClosingTagNext()
        {
            string xml = "</a><b>1</b>";
            bool expected = true;
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);

            bool fact = deserialization.isClosingTagNext("a", deserialization.XML_String);
            Assert.AreEqual(expected, fact);

            fact = deserialization.isClosingTagNext("b", deserialization.XML_String);
            Assert.AreNotEqual(expected, fact);
        }

        [TestMethod]
        public void TestIsClosingTagNext2()
        {
            string xml = "<a><b>1</b>";
            bool expected = false;
            _XMLDeserialization deserialization = new _XMLDeserialization(xml);

            bool fact = deserialization.isClosingTagNext("a", deserialization.XML_String);
            Assert.AreEqual(expected, fact, "Attempt 1");

            fact = deserialization.isClosingTagNext("b", deserialization.XML_String);
            Assert.AreEqual(expected, fact, "Attempt 2");
        }
    }
}
