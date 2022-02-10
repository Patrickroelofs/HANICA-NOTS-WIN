using System;
using System.Net;

namespace bp01_chatapplicatie
{
    public class Parsers
    {
        public static int ParsePort(string StringPort)
        {
            int IntPort;
            int.TryParse(StringPort, out IntPort);
            return IntPort;
        }
    }
}