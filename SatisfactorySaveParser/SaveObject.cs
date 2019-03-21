﻿using System.IO;

namespace SatisfactorySaveParser
{
    /// <summary>
    ///     Class representing a single saved object in a Satisfactory save
    /// </summary>
    public abstract class SaveObject
    {
        /// <summary>
        ///     Forward slash separated path of the script/prefab of this object.
        ///     Can be an empty string.
        /// </summary>
        public string TypePath { get; set; }

        /// <summary>
        ///     Root object (?) of this object
        ///     Often some form of "Persistent_Level", can be an empty string
        /// </summary>
        public string RootObject { get; set; }

        /// <summary>
        ///     Unique (?) name of this object
        /// </summary>
        public string InstanceName { get; set; }

        /// <summary>
        ///     Main serialized data of the object
        /// </summary>
        public SerializedFields DataFields { get; set; }

        protected SaveObject(BinaryReader reader)
        {
            TypePath = reader.ReadLengthPrefixedString();
            RootObject = reader.ReadLengthPrefixedString();
            InstanceName = reader.ReadLengthPrefixedString();
        }

        public virtual void SerializeHeader(BinaryWriter writer)
        {
            writer.WriteLengthPrefixedString(TypePath);
            writer.WriteLengthPrefixedString(RootObject);
            writer.WriteLengthPrefixedString(InstanceName);
        }

        public virtual void SerializeData(BinaryWriter writer)
        {
            DataFields.Serialize(writer);
        }

        public virtual void ParseData(int length, BinaryReader reader)
        {
            DataFields = SerializedFields.Parse(length, reader);
        }

        public override string ToString()
        {
            return TypePath;
        }
    }
}
