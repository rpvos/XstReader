// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using XstReader.Exporter.MsgKit.Enums;

namespace XstReader.Exporter.MsgKit.Structures
{
    internal partial class Properties
    {
        internal void AddProperty(PropertyTag mapiTag, XstElement element, bool alsoNull = true, dynamic? valueIfNull = null, PropertyFlags flags = PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)
        {
            var value = element.Properties[mapiTag.Id]?.Value;
            byte[] data = AsBytes(mapiTag.Type, value);
            if (data?.Length > 0 || alsoNull)
                AddProperty(mapiTag, value, flags);
            else if (valueIfNull != null)
                AddProperty(mapiTag, valueIfNull, flags);
        }
        internal void AddOrReplaceProperty(PropertyTag mapiTag, XstElement element, bool alsoNull = true, dynamic? valueIfNull = null, PropertyFlags flags = PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)
        {
            var value = element.Properties[mapiTag.Id]?.Value;
            byte[] data = AsBytes(mapiTag.Type, value);
            if (data?.Length > 0 || alsoNull)
                AddOrReplaceProperty(mapiTag, value, flags);
            else if (valueIfNull != null)
                AddOrReplaceProperty(mapiTag, valueIfNull, flags);
        }
        internal void AddIfNotPresentProperty(PropertyTag mapiTag, XstElement element, bool alsoNull = true, dynamic? valueIfNull = null, PropertyFlags flags = PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)
        {
            var value = element.Properties[mapiTag.Id]?.Value;
            byte[] data = AsBytes(mapiTag.Type, value);
            if (data?.Length > 0 || alsoNull)
                AddIfNotPresentProperty(mapiTag, value, flags);
            else if (valueIfNull != null)
                AddIfNotPresentProperty(mapiTag, valueIfNull, flags);
        }
        internal void AddIfNotPresentProperty(PropertyTag mapiTag, object obj, PropertyFlags flags = PropertyFlags.PROPATTR_READABLE | PropertyFlags.PROPATTR_WRITABLE)
        {
            var index = FindIndex(m => m.Id == mapiTag.Id);
            if (index >= 0)
                return;

            AddProperty(mapiTag, obj, flags);
        }

    }
}
