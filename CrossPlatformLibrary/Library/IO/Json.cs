using System;
using System.IO;
using Newtonsoft.Json;

namespace CrossPlatform.Library.IO
{
    public static class Json
    {
        private static JsonSerializerSettings JsonSettings { get; set; }

        static Json()
        {
            JsonSettings = new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };
        }

        public static string ToJson(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, JsonSettings);
            }
            catch (Exception)
            {
                throw new Exception("Failed to serialise object to JSON");
            }
        }

        public static bool ToJsonFile(object obj, string filepath)
        {
            var json = ToJson(obj);

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(filepath))) Directory.CreateDirectory(Path.GetDirectoryName(filepath));
                File.WriteAllText(filepath, json);
            }
            catch (Exception)
            {
                throw new Exception("Failed to write to file.");
            }

            return true;
        }

        public static T FromJson<T>(string json) where T : new()
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json, JsonSettings);
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception("Failed to deserialise");
            }
        }

        public static T FromJsonFile<T>(string filepath) where T : new()
        {
            string json = "";
            try
            {
                if (!File.Exists(filepath))
                {
                    throw new FileNotFoundException(filepath);
                }
                json = File.ReadAllText(filepath);

            }
            catch (Exception)
            {
                throw new FileLoadException("Failed to read json file");
            }

            try
            {
                return FromJson<T>(json);
            }
            catch (Exception e)
            {
                throw new Exception("Failed to deserialise file contents.");
            }
        }

    }
}
