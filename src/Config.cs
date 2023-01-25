namespace BBS
{
    class Config
    {
        public static string getValue(string key)
        {
            foreach (string line in System.IO.File.ReadLines(".bbsrc"))
            {
                string[] pair = line.Split('=');

                if (pair[0] == key)
                {
                    return pair[1];
                }
            }
            return "";
        }
    }
}