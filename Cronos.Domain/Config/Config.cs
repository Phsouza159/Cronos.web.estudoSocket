using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Cronos.Domain.Config
{
    public static class Config
    {
        private static string FileLocation = "appsettings.json";

        public static dynamic Get()
        {
            dynamic json;
            using (StreamReader reader = new StreamReader(FileLocation))
            {
                json = JObject.Parse( reader.ReadToEnd() );
                reader.Close();
            }

            return json;
        }

        public static string Connect(string name = null)
        {
            if (String.IsNullOrEmpty(name))
                return Config.Get().Connect.ConnectStringDefault.Value;

            return Config.Get().Connect[name].Value;
        }
    }
}
