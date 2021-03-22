using System;
using NUnit.Framework;
using ShannonFano;

namespace ShannonFanoTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Code_PlainText_GetCode()
        {
            var shannonFanoCoding = new ShannonFanoCoding();
            
            var text = "My name is Maksim!";

            var expected = "01101100001111001111011110001000100001100111110101010010111111";

            var (symbols, code) = shannonFanoCoding.Code(text);
            
            Assert.AreEqual(code,expected);
        }

        [Test]
        public void Decode_PlainText_GetSourceText()
        {
            var shannonFanoCoding = new ShannonFanoCoding();
            
            var text = "It is real cool.)))";
            
            var (symbols, code) = shannonFanoCoding.Code(text);

            var encodedMessage = "0111110101100101011001000101100010111101111010001";

            var sourceText = " Icoco) teea)";

            var actual = shannonFanoCoding.Decode(encodedMessage);
            
            Assert.AreEqual(sourceText,actual);
        }

        [Test]
        public void Code_EmptyText_Exception()
        {
            var shannonFanoCoding = new ShannonFanoCoding();
            
            var text = "";

            Assert.Throws<Exception>(() => shannonFanoCoding.Code(text));
        }
    }
}