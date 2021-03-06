using System;
using System.Linq;
using System.Net;

namespace bp01_chatapplicatie
{
    public class Parsers
    {
        /**
         * Parses string to int and returns int
         */
        public static int ParseToInt(string input)
        {
            int output;
            int.TryParse(input, out output);
            return output;
        }

        /**
         * Parses input fields on server and client, ensures their values are safe and returns true.
         * It parses IP, Port, BufferSize and Name
         */
        public static bool ParseInputs(string ip, string port, string name, string bufferSize)
        {
            bool tryParseIp = IPAddress.TryParse(ip, out IPAddress ipAddress);
            bool tryValidatePort = port.All(char.IsDigit) && ParseToInt(port) <= 65535 && ParseToInt(port) > 0;
            bool tryValidateBufferSize = bufferSize.All(char.IsDigit) && ParseToInt(bufferSize) < 65535 && ParseToInt(bufferSize) > 0;
            bool tryValidateName = name.All(char.IsLetterOrDigit) && name.Length > 0 && name.Length < 16;

            if (tryParseIp && tryValidatePort && tryValidateBufferSize && tryValidateName) return true;
            return false;
        }
    }
}