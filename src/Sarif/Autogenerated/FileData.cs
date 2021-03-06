// Copyright (c) Microsoft.  All Rights Reserved.
// Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.CodeAnalysis.Sarif.Readers;

namespace Microsoft.CodeAnalysis.Sarif
{
    /// <summary>
    /// A single file. In some cases, this file might be nested within another file.
    /// </summary>
    [DataContract]
    [GeneratedCode("Microsoft.Json.Schema.ToDotNet", "0.42.0.0")]
    public partial class FileData : PropertyBagHolder, ISarifNode
    {
        public static IEqualityComparer<FileData> ValueComparer => FileDataEqualityComparer.Instance;

        public bool ValueEquals(FileData other) => ValueComparer.Equals(this, other);
        public int ValueGetHashCode() => ValueComparer.GetHashCode(this);

        /// <summary>
        /// Gets a value indicating the type of object implementing <see cref="ISarifNode" />.
        /// </summary>
        public SarifNodeKind SarifNodeKind
        {
            get
            {
                return SarifNodeKind.FileData;
            }
        }

        /// <summary>
        /// The path to the file within its containing file.
        /// </summary>
        [DataMember(Name = "uri", IsRequired = false, EmitDefaultValue = false)]
        public Uri Uri { get; set; }

        /// <summary>
        /// A string that identifies the conceptual base for the 'uri' property (if it is relative), e.g.,'$(SolutionDir)' or '%SRCROOT%'.
        /// </summary>
        [DataMember(Name = "uriBaseId", IsRequired = false, EmitDefaultValue = false)]
        public string UriBaseId { get; set; }

        /// <summary>
        /// Identifies the key of the immediate parent of the file, if this file is nested.
        /// </summary>
        [DataMember(Name = "parentKey", IsRequired = false, EmitDefaultValue = false)]
        public string ParentKey { get; set; }

        /// <summary>
        /// The offset in bytes of the file within its containing file.
        /// </summary>
        [DataMember(Name = "offset", IsRequired = false, EmitDefaultValue = false)]
        public int Offset { get; set; }

        /// <summary>
        /// The length of the file in bytes.
        /// </summary>
        [DataMember(Name = "length", IsRequired = false, EmitDefaultValue = false)]
        public int Length { get; set; }

        /// <summary>
        /// The MIME type (RFC 2045) of the file.
        /// </summary>
        [DataMember(Name = "mimeType", IsRequired = false, EmitDefaultValue = false)]
        public string MimeType { get; set; }

        /// <summary>
        /// An array of hash objects, each of which specifies a hashed value for the file, along with the name of the algorithm used to compute the hash.
        /// </summary>
        [DataMember(Name = "hashes", IsRequired = false, EmitDefaultValue = false)]
        public IList<Hash> Hashes { get; set; }

        /// <summary>
        /// Key/value pairs that provide additional information about the file.
        /// </summary>
        [DataMember(Name = "properties", IsRequired = false, EmitDefaultValue = false)]
        internal override IDictionary<string, SerializedPropertyInfo> Properties { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileData" /> class.
        /// </summary>
        public FileData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileData" /> class from the supplied values.
        /// </summary>
        /// <param name="uri">
        /// An initialization value for the <see cref="P: Uri" /> property.
        /// </param>
        /// <param name="uriBaseId">
        /// An initialization value for the <see cref="P: UriBaseId" /> property.
        /// </param>
        /// <param name="parentKey">
        /// An initialization value for the <see cref="P: ParentKey" /> property.
        /// </param>
        /// <param name="offset">
        /// An initialization value for the <see cref="P: Offset" /> property.
        /// </param>
        /// <param name="length">
        /// An initialization value for the <see cref="P: Length" /> property.
        /// </param>
        /// <param name="mimeType">
        /// An initialization value for the <see cref="P: MimeType" /> property.
        /// </param>
        /// <param name="hashes">
        /// An initialization value for the <see cref="P: Hashes" /> property.
        /// </param>
        /// <param name="properties">
        /// An initialization value for the <see cref="P: Properties" /> property.
        /// </param>
        public FileData(Uri uri, string uriBaseId, string parentKey, int offset, int length, string mimeType, IEnumerable<Hash> hashes, IDictionary<string, SerializedPropertyInfo> properties)
        {
            Init(uri, uriBaseId, parentKey, offset, length, mimeType, hashes, properties);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileData" /> class from the specified instance.
        /// </summary>
        /// <param name="other">
        /// The instance from which the new instance is to be initialized.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="other" /> is null.
        /// </exception>
        public FileData(FileData other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            Init(other.Uri, other.UriBaseId, other.ParentKey, other.Offset, other.Length, other.MimeType, other.Hashes, other.Properties);
        }

        ISarifNode ISarifNode.DeepClone()
        {
            return DeepCloneCore();
        }

        /// <summary>
        /// Creates a deep copy of this instance.
        /// </summary>
        public FileData DeepClone()
        {
            return (FileData)DeepCloneCore();
        }

        private ISarifNode DeepCloneCore()
        {
            return new FileData(this);
        }

        private void Init(Uri uri, string uriBaseId, string parentKey, int offset, int length, string mimeType, IEnumerable<Hash> hashes, IDictionary<string, SerializedPropertyInfo> properties)
        {
            if (uri != null)
            {
                Uri = new Uri(uri.OriginalString, uri.IsAbsoluteUri ? UriKind.Absolute : UriKind.Relative);
            }

            UriBaseId = uriBaseId;
            ParentKey = parentKey;
            Offset = offset;
            Length = length;
            MimeType = mimeType;
            if (hashes != null)
            {
                var destination_0 = new List<Hash>();
                foreach (var value_0 in hashes)
                {
                    if (value_0 == null)
                    {
                        destination_0.Add(null);
                    }
                    else
                    {
                        destination_0.Add(new Hash(value_0));
                    }
                }

                Hashes = destination_0;
            }

            if (properties != null)
            {
                Properties = new Dictionary<string, SerializedPropertyInfo>(properties);
            }
        }
    }
}