using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Xml;

namespace SfSoapInterceptor
{
    public class SoapIntercept : SoapHttpClientProtocol
    {
        protected override XmlReader GetReaderForMessage(System.Web.Services.Protocols.SoapClientMessage message, int bufferSize)
        {
            if (!AgsLogger.IsLogging)
            {
                return base.GetReaderForMessage(message, bufferSize);
            }
            else
            {
                return new AgsLoggingXmlReader(message.Stream, bufferSize);
            }
        }

        protected override XmlWriter GetWriterForMessage(System.Web.Services.Protocols.SoapClientMessage message, int bufferSize)
        {
            if (!AgsLogger.IsLogging)
            {
                return base.GetWriterForMessage(message, bufferSize);
            }
            else
            {
                var requestXML= new AgsLoggingXmlWriter(message.Stream);

                return requestXML;
            }
        }
    }
}
