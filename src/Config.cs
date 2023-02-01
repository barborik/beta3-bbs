namespace Beta3
{
    class Config
    {
        public static string GetValue(string key)
        {
            foreach (string line in System.IO.File.ReadLines(".bbsrc"))
            {
                string[] pair = line.Split('=', 2);

                if (pair[0] == key)
                {
                    return pair[1];
                }
            }
            return "";
        }
    }
}