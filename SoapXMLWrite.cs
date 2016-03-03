using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SfSoapInterceptor
{
    class SoapXML: XmlWriter
    {
   
        private XmlWriter _me;
        private XmlTextWriter _bu; // Buffer to write XML to
        private StringWriter _sw;



        public SoapXML(XmlWriter implementation)
        {
            _me = implementation;
            _sw = new StringWriter();
            _bu = new XmlTextWriter(_sw);
            _bu.Formatting = Formatting.Indented;
            

        }
        public override void Flush()
        {
            _me.Flush();
            _bu.Flush();
            _sw.Flush();
        }
        public string Xml { get { return (_sw == null ? null : _sw.ToString()); } }

        public override void Close() { _me.Close(); _bu.Close(); }
        public override string LookupPrefix(string ns) { return _me.LookupPrefix(ns); }
        public override void WriteBase64(byte[] buffer, int index, int count) { _me.WriteBase64(buffer, index, count); _bu.WriteBase64(buffer, index, count); }

        // ...more overrides omitted, you get the idea...

        public override void WriteSurrogateCharEntity(char lowChar, char highChar) { _me.WriteSurrogateCharEntity(lowChar, highChar); _bu.WriteSurrogateCharEntity(lowChar, highChar); }
        public override void WriteWhitespace(string ws) { _me.WriteWhitespace(ws); _bu.WriteWhitespace(ws); }


        public override void WriteCData(string text)
        {
            throw new NotImplementedException();
        }

        public override void WriteCharEntity(char ch)
        {
            throw new NotImplementedException();
        }

        public override void WriteChars(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public override void WriteComment(string text)
        {
            throw new NotImplementedException();
        }

        public override void WriteDocType(string name, string pubid, string sysid, string subset)
        {
            throw new NotImplementedException();
        }

        public override void WriteEndAttribute()
        {
            throw new NotImplementedException();
        }

        public override void WriteEndDocument()
        {
            throw new NotImplementedException();
        }

        public override void WriteEndElement()
        {
            throw new NotImplementedException();
        }

        public override void WriteEntityRef(string name)
        {
            throw new NotImplementedException();
        }

        public override void WriteFullEndElement()
        {
            throw new NotImplementedException();
        }

        public override void WriteProcessingInstruction(string name, string text)
        {
            throw new NotImplementedException();
        }

        public override void WriteRaw(string data)
        {
            throw new NotImplementedException();
        }

        public override void WriteRaw(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartDocument(bool standalone)
        {
            throw new NotImplementedException();
        }

        public override void WriteStartDocument()
        {
            throw new NotImplementedException();
        }

        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            throw new NotImplementedException();
        }

        public override WriteState WriteState
        {
            get { throw new NotImplementedException(); }
        }

        public override void WriteString(string text)
        {
            throw new NotImplementedException();
        }
    }
}
    

