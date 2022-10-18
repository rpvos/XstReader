// Project site: https://github.com/iluvadev/XstReader
//
// Based on the great work of Dijji. 
// Original project: https://github.com/dijji/XstReader
//
// Issues: https://github.com/iluvadev/XstReader/issues
// License (Ms-PL): https://github.com/iluvadev/XstReader/blob/master/license.md
//
// Copyright (c) 2021, iluvadev, and released under Ms-PL License.

using OpenMcdf;
using XstReader.ElementProperties;
using XstReader.Exporter.MsgKit.Enums;
using XstReader.Exporter.MsgKit.Helpers;
using XstReader.Exporter.MsgKit.Streams;
using XstReader.Exporter.MsgKit.Structures;

namespace XstReader.Exporter.MsgKit
{
    public class MessageXst : Message
    {
        private XstMessage XstMessage { get; set; }
        public MessageXst(XstMessage xstMessage) : base()
        {
            XstMessage = xstMessage;
            ClassAsString = xstMessage.PropertyValue(PropertyCanonicalName.PidTagMessageClass);
        }

        private long WriteToStorageRecipients(CFStorage rootStorage)
        {
            long size = 0;
            var index = 0;
            foreach (var recipient in XstMessage.Recipients.Items.Where(r => !r.IsGeneratedFromMessageProperties))
            {
                var storage = rootStorage.AddStorage(PropertyTags.RecipientStoragePrefix + index.ToString("X8").ToUpper());
                size += WritePropertiesRecipient(storage, recipient, index);
                index++;
            }
            return size;
        }
        private long WritePropertiesRecipient(CFStorage storage, XstRecipient recipient, long index)
        {
            var propertiesStream = new RecipientProperties();
            propertiesStream.AddProperty(PropertyTags.PR_ROWID, index);
            propertiesStream.AddProperty(PropertyTags.PR_ENTRYID, Mapi.GenerateEntryId());
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey());

            AddKnownProperties(recipient, propertiesStream);
            return propertiesStream.WriteProperties(storage);
        }

        private long WriteToStorageAttachments(CFStorage rootStorage)
        {
            long size = 0;
            var index = 0;
            foreach (var attachment in XstMessage.Attachments)
            {
                var storage = rootStorage.AddStorage(PropertyTags.AttachmentStoragePrefix + index.ToString("x8").ToUpper());
                size += WritePropertiesAttachment(storage, index, attachment);
                index++;
            }

            return size;
        }
        private long WritePropertiesAttachment(CFStorage storage, int index, XstAttachment attachment)
        {
            var propertiesStream = new AttachmentProperties();

            propertiesStream.AddProperty(PropertyTags.PR_ATTACH_NUM, index, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RECORD_KEY, Mapi.GenerateRecordKey(), PropertyFlags.PROPATTR_READABLE);

            using (var stream = new MemoryStream())
            {
                if (attachment.IsEmail)
                {
                    (new MessageXst(attachment.AttachedEmailMessage)).Save(stream);
                    string attachFileName = attachment.DisplayName + ".msg";
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_FILENAME_W, attachFileName);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FILENAME_W, FilePath.GetShortFileName(attachFileName));
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_EXTENSION_W, Path.GetExtension(attachFileName));
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_MIME_TAG_W, "application/vnd.ms-outlook");
                }
                else if (attachment.IsFile)
                    attachment.SaveToStream(stream);

                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_METHOD, 1);
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, stream.ToArray());
                propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, stream.Length);
            }

            AddKnownProperties(attachment, propertiesStream);
            return propertiesStream.WriteProperties(storage);
        }

        private void WriteToStorage()
        {
            var rootStorage = CompoundFile.RootStorage;

            MessageSize += WriteToStorageRecipients(rootStorage);
            MessageSize += WriteToStorageAttachments(rootStorage);

            var recipientCount = XstMessage.Recipients.Items.Where(r => !r.IsGeneratedFromMessageProperties).Count();
            var attachmentCount = XstMessage.Attachments.Count();
            TopLevelProperties.RecipientCount = recipientCount;
            TopLevelProperties.AttachmentCount = attachmentCount;
            TopLevelProperties.NextRecipientId = recipientCount;
            TopLevelProperties.NextAttachmentId = attachmentCount;

            TopLevelProperties.AddOrReplaceProperty(PropertyTags.PR_ENTRYID, Mapi.GenerateEntryId());
            TopLevelProperties.AddOrReplaceProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey());
            TopLevelProperties.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);
            TopLevelProperties.AddProperty(PropertyTags.PR_STORE_UNICODE_MASK, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);

            // http://www.meridiandiscovery.com/how-to/e-mail-conversation-index-metadata-computer-forensics/
            // http://stackoverflow.com/questions/11860540/does-outlook-embed-a-messageid-or-equivalent-in-its-email-elements

            TopLevelProperties.AddProperty(PropertyTags.PR_SUBJECT_W, XstMessage.Subject);

            AddKnownProperties(XstMessage, TopLevelProperties);
        }

        private void AddKnownProperties(XstElement element, Properties properties)
        {
            foreach (var propTag in PropertyTags.PropertyTagListForMessages)
            {
                try { properties.AddIfNotPresentProperty(propTag, element, false); }
                catch { }
            }
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="stream" />
        /// </summary>
        /// <param name="stream"></param>
        public new void Save(Stream stream)
        {
            WriteToStorage();
            base.Save(stream);
        }

        /// <summary>
        ///     Saves the message to the given <paramref name="fileName" />
        /// </summary>
        /// <param name="fileName"></param>
        public new void Save(string fileName)
        {
            WriteToStorage();
            base.Save(fileName);
        }
    }
}
