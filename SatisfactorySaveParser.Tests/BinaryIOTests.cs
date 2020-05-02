using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SatisfactorySaveParser.Tests
{
    [TestClass]
    public class BinaryIOTests
    {
        private const string PersistentLevelString = "Persistent_Level";
        private static readonly byte[] PersistentLevelStringBytes = new byte[] { 0x11, 0x00, 0x00, 0x00, 0x50, 0x65, 0x72, 0x73, 0x69, 0x73, 0x74, 0x65, 0x6E, 0x74, 0x5F, 0x4C, 0x65, 0x76, 0x65, 0x6C, 0x00 };
        private const string UnicodeTestString = "unicodetest��ߵ";
        private static readonly byte[] UnicodeTestStringBytes = new byte[] { 0xF0, 0xFF, 0xFF, 0xFF, 0x75, 0x00, 0x6E, 0x00, 0x69, 0x00, 0x63, 0x00, 0x6F, 0x00, 0x64, 0x00, 0x65, 0x00, 0x74, 0x00, 0x65, 0x00, 0x73, 0x00, 0x74, 0x00, 0xF6, 0x00, 0xE4, 0x00, 0xDF, 0x00, 0xB5, 0x00, 0x00, 0x00 };
        private static readonly byte[] EmptyStringBytes = new byte[] { 0x00, 0x00, 0x00, 0x00 };

        [TestMethod]
        public void LengthPrefixedASCIIReading()
        {
            using var stream = new MemoryStream(PersistentLevelStringBytes);
            using var reader = new BinaryReader(stream);

            var str = reader.ReadLengthPrefixedString();
            Assert.AreEqual(PersistentLevelString, str);
            Assert.AreEqual(reader.BaseStream.Length, reader.BaseStream.Position);
        }

        [TestMethod]
        public void LengthPrefixedASCIIWriting()
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);

            writer.WriteLengthPrefixedString(PersistentLevelString);
            CollectionAssert.AreEqual(PersistentLevelStringBytes, stream.ToArray());
        }

        [TestMethod]
        public void SerializedASCIILength()
        {
            Assert.AreEqual(PersistentLevelStringBytes.Length, PersistentLevelString.GetSerializedLength());
        }

        [TestMethod]
        public void LengthPrefixedUnicodeReading()
        {
            using var stream = new MemoryStream(UnicodeTestStringBytes);
            using var reader = new BinaryReader(stream);

            var str = reader.ReadLengthPrefixedString();
            Assert.AreEqual(UnicodeTestString, str);
            Assert.AreEqual(reader.BaseStream.Length, reader.BaseStream.Position);
        }

        [TestMethod]
        public void LengthPrefixedUnicodeWriting()
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);

            writer.WriteLengthPrefixedString(UnicodeTestString);
            CollectionAssert.AreEqual(UnicodeTestStringBytes, stream.ToArray());
        }

        [TestMethod]
        public void SerializedUnicodeLength()
        {
            Assert.AreEqual(UnicodeTestStringBytes.Length, UnicodeTestString.GetSerializedLength());
        }

        [TestMethod]
        public void EmptyStringReading()
        {
            using var stream = new MemoryStream(EmptyStringBytes);
            using var reader = new BinaryReader(stream);

            var str = reader.ReadLengthPrefixedString();
            Assert.AreEqual(string.Empty, str);
            Assert.AreEqual(reader.BaseStream.Length, reader.BaseStream.Position);
        }

        [TestMethod]
        public void EmptyStringWriting()
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream);

            writer.WriteLengthPrefixedString(string.Empty);
            CollectionAssert.AreEqual(EmptyStringBytes, stream.ToArray());
        }
    }
}
