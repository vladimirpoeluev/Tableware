using System;
using System.IO;

namespace Tableware
{
    static class SavePassword
    {
        const string path = "Resurce/save/save.txt";
        public static string GetPassword()
        {
            string value;
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine();
                value = sr.ReadLine();
            }
            return value;
        } 
        public static string GetLogin()
        {
            string value;
            using (StreamReader sr = new StreamReader(path))
            {
                value = sr.ReadLine();
            }
            return value;
        }

        public static void Save(string login, string password)
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(login);
                sw.WriteLine(password);
            }
        }
    }
}
