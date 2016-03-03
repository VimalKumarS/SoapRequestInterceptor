using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfSoapInterceptor
{
    public static class AgsLogger
    {
        private static BooleanSwitch _debugSwitch = new BooleanSwitch("AgsDebug", "Displays ArcGIS Server requests and responses in the Debug window");
        private static BooleanSwitch _traceSwitch = new BooleanSwitch("AgsTrace", "Enables the writing of ArcGIS Server requests and responses to a trace log");

        public static bool IsLogging
        {
            get
            {
                return true;
            }
        }

        public static void Log(string message, string type)
        {
            message = String.Format("{0:yyyy-MM-dd hh:mm:ss}  --  ArcGIS Server {1}\n\n{2}\n\n", DateTime.Now, type, message);

            if (_debugSwitch.Enabled)
            {
                Debugger.Log(0, "AGS", message);
            }

            if (_traceSwitch.Enabled)
            {
                Trace.Write(message);
            }
        }

        public static string RequestXml { get; set; }
    }
}
