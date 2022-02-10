namespace bp01_chatapplicatie
{
    public class ParsersAndValidators
    {
        public static int ParsePortStringToPortInt(string portString)
        {
            int portInt;
            int.TryParse(portString, out portInt);
            
            return portInt;
        }
    }
}