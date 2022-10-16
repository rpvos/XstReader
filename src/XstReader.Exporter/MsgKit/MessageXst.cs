
using XstReader.Exporter.MsgKit.Enums;
using XstReader.Exporter.MsgKit.Helpers;
using XstReader.Exporter.MsgKit.Streams;
using OpenMcdf;
using System.IO;
using System.Linq;
using XstReader;
using XstReader.ElementProperties;
using static System.Net.Mime.MediaTypeNames;

namespace XstReader.Exporter.MsgKit
{
    public class MessageXst : Message
    {
        private XstMessage XstMessage { get; set; }
        public MessageXst(XstMessage xstMessage) : base()
        {
            if (xstMessage == null) return;

            XstMessage = xstMessage;
            ClassAsString = xstMessage.PropertyValue(PropertyCanonicalName.PidTagMessageClass);

        }

        internal long WriteToStorageRecipients(CFStorage rootStorage)
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
        internal long WritePropertiesRecipient(CFStorage storage, XstRecipient recipient, long index)
        {
            var propertiesStream = new RecipientProperties();
            propertiesStream.AddProperty(PropertyTags.PR_ROWID, index);
            propertiesStream.AddProperty(PropertyTags.PR_ENTRYID, Mapi.GenerateEntryId());
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey());
            //propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_TYPE, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ADDRTYPE_W, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_EMAIL_ADDRESS_W, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_SMTP_ADDRESS_W, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_OBJECT_TYPE, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_TYPE, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_TYPE_EX, recipient, false); 
            //propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_RECORD_KEY, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_SEARCH_KEY, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_SEND_RICH_INFO, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_TRANSMITABLE_DISPLAY_NAME_W, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_RESPONSIBILITY, recipient, false);
            //propertiesStream.AddProperty(PropertyTags.PR_RECIPIENT_FLAGS, recipient, false);

            foreach (var propTag in PropertyTags.AllPropertyTags)
            {
                try { propertiesStream.AddIfNotPresentProperty(propTag, recipient, false); }
                catch { }
            }
            return propertiesStream.WriteProperties(storage);
        }

        internal long WriteToStorageAttachments(CFStorage rootStorage)
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
        internal long WritePropertiesAttachment(CFStorage storage, int index, XstAttachment attachment)
        {
            var propertiesStream = new AttachmentProperties();

            propertiesStream.AddProperty(PropertyTags.PR_ATTACH_NUM, index, PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_INSTANCE_KEY, Mapi.GenerateInstanceKey(), PropertyFlags.PROPATTR_READABLE);
            propertiesStream.AddProperty(PropertyTags.PR_RECORD_KEY, Mapi.GenerateRecordKey(), PropertyFlags.PROPATTR_READABLE);

            //propertiesStream.AddProperty(PropertyTags.PR_RENDERING_POSITION, attachment, flags: PropertyFlags.PROPATTR_READABLE);
            //propertiesStream.AddProperty(PropertyTags.PR_OBJECT_TYPE, MapiObjectType.MAPI_ATTACH);

            //propertiesStream.AddProperty(PropertyTags.PR_ATTACHMENT_CONTACTPHOTO, attachment, false, flags: PropertyFlags.PROPATTR_READABLE);

            //propertiesStream.AddProperty(PropertyTags.PR_DISPLAY_NAME_W, attachment, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FILENAME_W, attachment, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_FILENAME_W, attachment, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_EXTENSION_W, attachment, false);

            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_CONTENT_ID_W, attachment, false);

            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_MIME_TAG_W, attachment, false);

            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_METHOD, attachment, false);

            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, attachment, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, attachment, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_PATHNAME_W, attachment, false);

            //propertiesStream.AddProperty(PropertyTags.PR_ATTACHMENT_HIDDEN, attachment, false);
            //propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FLAGS, attachment, false);

            //var utcNow = DateTime.UtcNow;
            //propertiesStream.AddProperty(PropertyTags.PR_CREATION_TIME, attachment, false, utcNow);
            //propertiesStream.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, attachment, false, utcNow);
            //propertiesStream.AddProperty(PropertyTags.PR_STORE_SUPPORT_MASK, attachment, false, StoreSupportMaskConst.StoreSupportMask, PropertyFlags.PROPATTR_READABLE);
            if (attachment.IsFile)
            {
                using (var stream = new MemoryStream())
                {
                    attachment.SaveToStream(stream);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, stream.ToArray());
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, stream.Length);
                }
            }
            else if (attachment.IsEmail)
            {
                var innerMsg = new MessageXst(attachment.AttachedEmailMessage);
                var auxFileName = Path.GetTempFileName();
                innerMsg.Save(auxFileName);
                using (var stream = new FileStream(auxFileName, FileMode.Open))
                {
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_DATA_BIN, stream.ToByteArray());
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_SIZE, stream.Length);
                    string attachFileName = attachment.DisplayName + ".msg";
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_LONG_FILENAME_W, attachFileName);
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_FILENAME_W, FilePath.GetShortFileName(attachFileName));
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_EXTENSION_W, Path.GetExtension(attachFileName));
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_MIME_TAG_W, "application/vnd.ms-outlook");
                    propertiesStream.AddProperty(PropertyTags.PR_ATTACH_METHOD, 1);
                }
                try { File.Delete(auxFileName); }
                catch { }
            }
            foreach (var propTag in PropertyTags.AllPropertyTags)
            {
                try { propertiesStream.AddIfNotPresentProperty(propTag, attachment, false); }
                catch { }
            }
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


            //TopLevelProperties.AddProperty(PropertyTags.PR_ALTERNATE_RECIPIENT_ALLOWED, true, PropertyFlags.PROPATTR_READABLE);
            //TopLevelProperties.AddProperty(PropertyTags.PR_HASATTACH, attachmentCount > 0);

            //if (XstMessage.PropertyValue(PropertyCanonicalName.PidTagTransportMessageHeaders) != null)
            //{
            //    TopLevelProperties.AddProperty(PropertyTags.PR_TRANSPORT_MESSAGE_HEADERS_W, XstMessage);
            //    TopLevelProperties.AddProperty(PropertyTags.PR_INTERNET_MESSAGE_ID_W, XstMessage, false);
            //    TopLevelProperties.AddProperty(PropertyTags.PR_INTERNET_REFERENCES_W, XstMessage, false);
            //    TopLevelProperties.AddProperty(PropertyTags.PR_IN_REPLY_TO_ID_W, XstMessage, false);
            //}

            //TopLevelProperties.AddOrReplaceProperty(PropertyTags.PR_INTERNET_MESSAGE_ID_W, XstMessage, false);
            //TopLevelProperties.AddOrReplaceProperty(PropertyTags.PR_INTERNET_REFERENCES_W, XstMessage, false);
            //TopLevelProperties.AddOrReplaceProperty(PropertyTags.PR_IN_REPLY_TO_ID_W, XstMessage, false);

            //TopLevelProperties.AddProperty(PropertyTags.PR_INTERNET_CPID, XstMessage, false, Encoding.UTF8.CodePage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_BODY_W, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_HTML, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RTF_COMPRESSED, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RTF_IN_SYNC, XstMessage, false, false);

            //TopLevelProperties.AddProperty(PropertyTags.PR_MSG_EDITOR_FORMAT, XstMessage, false);

            //TopLevelProperties.AddProperty(PropertyTags.PR_MESSAGE_DELIVERY_TIME, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_CLIENT_SUBMIT_TIME, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ACCESS, XstMessage, false, MapiAccess.MAPI_ACCESS_DELETE | MapiAccess.MAPI_ACCESS_MODIFY | MapiAccess.MAPI_ACCESS_READ);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ACCESS_LEVEL, XstMessage, false, MapiAccess.MAPI_ACCESS_MODIFY);
            //TopLevelProperties.AddProperty(PropertyTags.PR_OBJECT_TYPE, XstMessage, false, MapiObjectType.MAPI_MESSAGE);

            //TopLevelProperties.AddProperty(PropertyTags.PR_SUBJECT_W, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_NORMALIZED_SUBJECT_W, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SUBJECT_PREFIX_W, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_CONVERSATION_TOPIC_W, XstMessage);

            //// http://www.meridiandiscovery.com/how-to/e-mail-conversation-index-metadata-computer-forensics/
            //// http://stackoverflow.com/questions/11860540/does-outlook-embed-a-messageid-or-equivalent-in-its-email-elements
            ////propertiesStream.AddProperty(PropertyTags.PR_CONVERSATION_INDEX, Subject);

            //// TODO: Change modification time when this message is opened and only modified
            //var utcNow = DateTime.UtcNow;
            //TopLevelProperties.AddProperty(PropertyTags.PR_CREATION_TIME, XstMessage, false, utcNow);
            //TopLevelProperties.AddProperty(PropertyTags.PR_LAST_MODIFICATION_TIME, XstMessage, false, utcNow);
            //TopLevelProperties.AddProperty(PropertyTags.PR_PRIORITY, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_IMPORTANCE, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_MESSAGE_LOCALE_ID, XstMessage, false, CultureInfo.CurrentCulture.LCID);

            //TopLevelProperties.AddProperty(PropertyTags.PR_READ_RECEIPT_REQUESTED, XstMessage, false, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_REPORT_TAG, XstMessage, false);

            //TopLevelProperties.AddProperty(PropertyTags.PR_MESSAGE_FLAGS, XstMessage);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ICON_INDEX, XstMessage);

            ////OriginalSentRepresenting
            //TopLevelProperties.AddProperty(PropertyTags.PR_ORIGINAL_SENT_REPRESENTING_ADDRTYPE_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ORIGINAL_SENT_REPRESENTING_EMAIL_ADDRESS_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ORIGINAL_SENT_REPRESENTING_ENTRYID, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ORIGINAL_SENT_REPRESENTING_NAME_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_ORIGINAL_SENT_REPRESENTING_SEARCH_KEY, XstMessage, false);

            ////SentRepresenting
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENT_REPRESENTING_ADDRTYPE_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENT_REPRESENTING_EMAIL_ADDRESS_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENT_REPRESENTING_ENTRYID, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENT_REPRESENTING_NAME_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENT_REPRESENTING_SEARCH_KEY, XstMessage, false);

            ////Sender
            //TopLevelProperties.AddProperty(PropertyTags.PR_CreatorEmailAddr_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_CreatorSimpleDispName_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_CreatorAddrType_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENDER_ADDRTYPE_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENDER_EMAIL_ADDRESS_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENDER_ENTRYID, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENDER_NAME_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SENDER_SEARCH_KEY, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_SMTP_ADDRESS_W, XstMessage, false);

            ////ReceivingRepresenting
            //TopLevelProperties.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_ADDRTYPE_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_EMAIL_ADDRESS_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_NAME_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RCVD_REPRESENTING_SEARCH_KEY, XstMessage, false);

            ////Receiving
            //TopLevelProperties.AddProperty(PropertyTags.PR_RECEIVED_BY_ADDRTYPE_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RECEIVED_BY_EMAIL_ADDRESS_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RECEIVED_BY_ENTRYID, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RECEIVED_BY_NAME_W, XstMessage, false);
            //TopLevelProperties.AddProperty(PropertyTags.PR_RECEIVED_BY_SEARCH_KEY, XstMessage, false);


            //TopLevelProperties.AddProperty(PropertyTags.PR_DISPLAY_TO_W, XstMessage, false, flags: PropertyFlags.PROPATTR_READABLE);
            //TopLevelProperties.AddProperty(PropertyTags.PR_DISPLAY_CC_W, XstMessage, false, flags: PropertyFlags.PROPATTR_READABLE);
            //TopLevelProperties.AddProperty(PropertyTags.PR_DISPLAY_BCC_W, XstMessage, false, flags: PropertyFlags.PROPATTR_READABLE);
            //TopLevelProperties.AddProperty(PropertyTags.PR_REPLY_RECIPIENT_NAMES_W, XstMessage, false, flags: PropertyFlags.PROPATTR_READABLE);

            TopLevelProperties.AddProperty(PropertyTags.PR_SUBJECT_W, XstMessage.Subject);

            foreach (var propTag in PropertyTags.AllPropertyTags)
            {
                try { TopLevelProperties.AddIfNotPresentProperty(propTag, XstMessage, false); }
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
