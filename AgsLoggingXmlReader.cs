

using System;
using System.IO;
using System.Xml;

namespace SfSoapInterceptor
{
  public class AgsLoggingXmlReader : XmlTextReader
  {
    private static MemoryStream ToLoggedStream(Stream stream, int bufferSize)
    {
      // read the entire source stream into a memory stream

      MemoryStream memoryStream = new MemoryStream();

      byte[] buffer = new byte[bufferSize];
      int bytesRead = 0;

      while ((bytesRead = stream.Read(buffer, 0, bufferSize)) > 0)
      {
        memoryStream.Write(buffer, 0, bytesRead);
      }

      // load the memory stream as an XML document

      memoryStream.Position = 0;
      XmlDocument doc = new XmlDocument();
      doc.Load(new XmlTextReader(memoryStream));

      // write the XML document as formatted text to a second memory stream

      MemoryStream formatStream = new MemoryStream();
      XmlTextWriter writer = new XmlTextWriter(formatStream, new System.Text.UTF8Encoding());
      writer.Formatting = Formatting.Indented;
      writer.Indentation = 2;
      writer.IndentChar = ' ';
      doc.WriteTo(writer);
      writer.Flush();

      // read the formatted XML into a string and log

      formatStream.Position = 0;
      StreamReader streamReader = new StreamReader(formatStream, new System.Text.UTF8Encoding());
      AgsLogger.Log(streamReader.ReadToEnd(), "Response");

      // position the memory stream buffer for subsequent XML reading

      memoryStream.Position = 0;
      return memoryStream;
    }

    public AgsLoggingXmlReader(Stream stream, int bufferSize) : base(ToLoggedStream(stream, bufferSize)) { }
  }
}
