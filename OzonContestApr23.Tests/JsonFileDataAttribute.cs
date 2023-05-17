using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Xunit.Sdk;

namespace OzonContestApr23.Tests
{
    public class JsonFileDataAttribute<T> : DataAttribute
    {
        private readonly string _filePath;

        public JsonFileDataAttribute(string filePath)
        {
            _filePath = filePath;
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            var tmp = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.GetFullPath(Path.Combine(tmp, $@"..\..\..\..\TestsInJson\{_filePath}"));

            if (!File.Exists(path))
            {
                throw new ArgumentException($"Could not find file at path: {path}");
            }

            using var reader = new StreamReader(path);
            var json = reader.ReadToEnd();
            var data = JsonConvert.DeserializeObject<List<T>>(json);


            return data.Select(x => new object[] { x });
        }
    }
}
