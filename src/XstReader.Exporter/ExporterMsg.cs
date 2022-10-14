using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsgKit;

namespace XstReader.Exporter
{
    public class ExporterMsg
    {
        public void Export(XstMessage message, string fileName)
        {
            var mess = new MessageXst(message);
            mess.Save(fileName);
        }
    }
}
