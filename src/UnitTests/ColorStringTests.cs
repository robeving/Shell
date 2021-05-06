﻿using Dotnet.Shell.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ColorStringTests
    {
        [TestMethod]
        public void ConvertANSI()
        {
            byte[] ansiStrBytes = new byte[] {
                0x1B, 0x5B, 0x30, 0x3B, 0x33, 0x38, 0x3B, 0x35,
                0x3B, 0x32, 0x33, 0x31, 0x3B, 0x34, 0x38, 0x3B,
                0x35, 0x3B, 0x33, 0x31, 0x3B, 0x31, 0x6D, 0xC2,
                0xA0, 0x75, 0x73, 0x65, 0x72, 0xC2, 0xA0, 0x1B,
                0x5B, 0x30, 0x3B, 0x33, 0x38, 0x3B, 0x35, 0x3B,
                0x33, 0x31, 0x3B, 0x34, 0x38, 0x3B, 0x35, 0x3B,
                0x32, 0x34, 0x30, 0x3B, 0x32, 0x32, 0x6D, 0xEE,
                0x82, 0xB0, 0xC2, 0xA0, 0x1B, 0x5B, 0x30, 0x3B,
                0x33, 0x38, 0x3B, 0x35, 0x3B, 0x32, 0x35, 0x30,
                0x3B, 0x34, 0x38, 0x3B, 0x35, 0x3B, 0x32, 0x34,
                0x30, 0x6D, 0xE2, 0x80, 0xA6, 0xC2, 0xA0, 0x1B,
                0x5B, 0x30, 0x3B, 0x33, 0x38, 0x3B, 0x35, 0x3B,
                0x32, 0x34, 0x35, 0x3B, 0x34, 0x38, 0x3B, 0x35,
                0x3B, 0x32, 0x34, 0x30, 0x3B, 0x32, 0x32, 0x6D,
                0xEE, 0x82, 0xB1, 0xC2, 0xA0, 0x1B, 0x5B, 0x30,
                0x3B, 0x33, 0x38, 0x3B, 0x35, 0x3B, 0x32, 0x35,
                0x30, 0x3B, 0x34, 0x38, 0x3B, 0x35, 0x3B, 0x32,
                0x34, 0x30, 0x6D, 0x62, 0x69, 0x6E, 0xC2, 0xA0,
                0x1B, 0x5B, 0x30, 0x3B, 0x33, 0x38, 0x3B, 0x35,
                0x3B, 0x32, 0x34, 0x35, 0x3B, 0x34, 0x38, 0x3B,
                0x35, 0x3B, 0x32, 0x34, 0x30, 0x3B, 0x32, 0x32,
                0x6D, 0xEE, 0x82, 0xB1, 0xC2, 0xA0, 0x1B, 0x5B,
                0x30, 0x3B, 0x33, 0x38, 0x3B, 0x35, 0x3B, 0x32,
                0x35, 0x30, 0x3B, 0x34, 0x38, 0x3B, 0x35, 0x3B,
                0x32, 0x34, 0x30, 0x6D, 0x44, 0x65, 0x62, 0x75,
                0x67, 0xC2, 0xA0, 0x1B, 0x5B, 0x30, 0x3B, 0x33,
                0x38, 0x3B, 0x35, 0x3B, 0x32, 0x34, 0x35, 0x3B,
                0x34, 0x38, 0x3B, 0x35, 0x3B, 0x32, 0x34, 0x30,
                0x3B, 0x32, 0x32, 0x6D, 0xEE, 0x82, 0xB1, 0xC2,
                0xA0, 0x1B, 0x5B, 0x30, 0x3B, 0x33, 0x38, 0x3B,
                0x35, 0x3B, 0x32, 0x35, 0x32, 0x3B, 0x34, 0x38,
                0x3B, 0x35, 0x3B, 0x32, 0x34, 0x30, 0x3B, 0x31,
                0x6D, 0x6E, 0x65, 0x74, 0x63, 0x6F, 0x72, 0x65,
                0x61, 0x70, 0x70, 0x33, 0x2E, 0x31, 0xC2, 0xA0,
                0x1B, 0x5B, 0x30, 0x3B, 0x33, 0x38, 0x3B, 0x35,
                0x3B, 0x32, 0x34, 0x30, 0x3B, 0x34, 0x39, 0x3B,
                0x32, 0x32, 0x6D, 0xEE, 0x82, 0xB0, 0xC2, 0xA0,
                0x1B, 0x5B, 0x30, 0x6D, 0x0A
            };

            var strData = Encoding.UTF8.GetString(ansiStrBytes);

            var cString = ColorString.FromRawANSI(strData);

            Assert.AreEqual(43, cString.Length);
            Assert.AreEqual(43, cString.Text.Length);
            Assert.AreNotEqual(43, cString.TextWithFormattingCharacters.Length);
        }

        [TestMethod]
        public void Construct()
        {
            ColorString a = new ColorString("hello", Color.Red);
            ColorString b = new ColorString("hello", Color.Green, Color.Blue);

            Assert.AreEqual(5, a.Length);
            Assert.AreEqual(5, b.Length);
            Assert.AreEqual(5, a.Text.Length);
            Assert.AreEqual(5, b.Text.Length);
            Assert.AreNotEqual(5, a.TextWithFormattingCharacters);
            Assert.AreNotEqual(5, b.TextWithFormattingCharacters);

            Assert.IsTrue(a.Equals("hello"));
            Assert.IsFalse(a.Equals("goodbye"));
        }

        [TestMethod]
        public void StringFunctions()
        {
            ColorString a = new ColorString("hello", Color.Red);
            ColorString b = new ColorString("goodbye", Color.Green, Color.Blue);

            var c = a + b;

            Assert.AreEqual("hellogoodbye", c.Text);
        }
    }
}