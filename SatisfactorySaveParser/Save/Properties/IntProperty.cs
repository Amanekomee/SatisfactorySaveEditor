﻿using System;
using System.Diagnostics;
using System.IO;

namespace SatisfactorySaveParser.Save.Properties
{
    public class IntProperty : SerializedProperty
    {
        public const string TypeName = nameof(IntProperty);
        public override string PropertyType => TypeName;

        public override Type BackingType => typeof(int);
        public override object BackingObject => Value;

        public override int SerializedLength => 4;

        public int Value { get; set; }

        public IntProperty(string propertyName, int index = 0) : base(propertyName, index)
        {
        }

        public override string ToString()
        {
            return $"Int {PropertyName}: {Value}";
        }

        public static IntProperty Deserialize(BinaryReader reader, string propertyName, int index)
        {
            var result = new IntProperty(propertyName, index);

            var nullByte = reader.ReadByte();
            Trace.Assert(nullByte == 0);

            result.Value = reader.ReadInt32();
            return result;
        }
    }
}
