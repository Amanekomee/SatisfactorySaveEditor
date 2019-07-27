﻿using System.IO;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SatisfactorySaveParser.Save.Properties;
using SatisfactorySaveParser.Save.Serialization;

namespace SatisfactorySaveParser.Tests.PropertyTypes
{
    [TestClass]
    public class FloatPropertyTests
    {
        private const string FloatName = "mCurrentFuelAmount";
        private const float FloatValue = 141.302673339844f;
        private static readonly byte[] FloatBytes = new byte[] { 0x13, 0x00, 0x00, 0x00, 0x6D, 0x43, 0x75, 0x72, 0x72, 0x65, 0x6E, 0x74, 0x46, 0x75, 0x65, 0x6C, 0x41, 0x6D, 0x6F, 0x75, 0x6E, 0x74, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x46, 0x6C, 0x6F, 0x61, 0x74, 0x50, 0x72, 0x6F, 0x70, 0x65, 0x72, 0x74, 0x79, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7C, 0x4D, 0x0D, 0x43 };

        [TestMethod]
        public void FloatPropertyRead()
        {
            using (var stream = new MemoryStream(FloatBytes))
            using (var reader = new BinaryReader(stream))
            {
                var prop = SatisfactorySaveSerializer.DeserializeProperty(reader) as FloatProperty;

                Assert.AreNotEqual(null, prop);

                Assert.AreEqual(FloatName, prop.PropertyName);
                Assert.AreEqual(FloatProperty.TypeName, prop.PropertyType);

                Assert.AreEqual(0, prop.Index);

                Assert.AreEqual(FloatValue, prop.Value);

                Assert.AreEqual(stream.Length, stream.Position);
            }
        }

        [TestMethod]
        public void FloatPropertyWrite()
        {
            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                var prop = new FloatProperty(FloatName)
                {
                    Value = FloatValue
                };

                SatisfactorySaveSerializer.SerializeProperty(prop, writer);

                Assert.AreEqual(4, prop.SerializedLength);
                CollectionAssert.AreEqual(FloatBytes, stream.ToArray());
            }
        }

        [TestMethod]
        public void FloatPropertyAssign()
        {
            var saveObject = new MappingTestActor();
            var prop = new FloatProperty(MappingTestActor.TestFloatName, MappingTestActor.TestFloatIndex)
            {
                Value = MappingTestActor.TestFloatValue * 2
            };

            var (objProperty, objPropertyAttr) = prop.GetMatchingSaveProperty(saveObject.GetType());

            Assert.AreEqual(nameof(saveObject.TestFloat), objProperty.Name);

            prop.AssignToProperty(saveObject, objProperty);

            Assert.AreEqual(saveObject.TestFloat, MappingTestActor.TestFloatValue * 2);
        }
    }
}
