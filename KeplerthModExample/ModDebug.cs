using System;
using System.IO;
using System.Text;

namespace KeplerthModExample
{
    public class ModDebug
    {

        public static void Log(object msg)
        {
            string text = "C:\\Users\\mubai\\Desktop\\Log\\";
            bool flag = !Directory.Exists(text);
            if (flag)
            {
                Directory.CreateDirectory(text);
            }
            StreamWriter streamWriter = new StreamWriter(text + "itemLog.txt", true, Encoding.UTF8);
            streamWriter.WriteLine(DateTime.Now.ToString() + ":\t" + msg.ToString());
            streamWriter.Close();
        }
    }
}
