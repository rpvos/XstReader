using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XstReader.App
{
    public class XstReaderViewOptions
    {
        [Category("Messages")]
        [DisplayName("Show Hidden Attachments")]
        [Description("Show Hidden Attachments in the Attachment list of a Message")]
        public bool ShowHiddenAttachments { get; set; } = false;
    }
}
