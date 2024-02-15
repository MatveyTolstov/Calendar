using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Календарь
{
    class SelandDel
    {
        public static T Ser<T>(string filename)
        {
            string put = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!File.Exists($"{put}\\{filename}"))
            {
                if (!Directory.Exists(put))
                {
                    Directory.CreateDirectory(put);
                }
                File.WriteAllText($"{put}\\{filename}", "");
            }

            string data = File.ReadAllText($"{put}\\{filename}");
            T list = JsonConvert.DeserializeObject<T>(data);
            return list;
        }

        public static void Der<T>(T data, string filename)
        {
            string put = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(put))
            {
                Directory.CreateDirectory(put);
            }

            string convertedData = JsonConvert.SerializeObject(data);
            File.WriteAllText($"{put}\\{filename}", convertedData);
        }
    }
}
