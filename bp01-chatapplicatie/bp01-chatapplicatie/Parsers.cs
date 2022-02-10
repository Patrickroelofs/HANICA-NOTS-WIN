namespace bp01_chatapplicatie
{
    public class Parsers
    {
        public static int ParsePortStringToPortInt(string portString)
        {
            int portInt;
            int.TryParse(portString, out portInt);
            
            return portInt;
        }
    }
}