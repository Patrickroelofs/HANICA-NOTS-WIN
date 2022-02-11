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

        public static int ParseToInt(string input)
        {
            int output;
            int.TryParse(input, out output);
            return output;
        }
    }
}