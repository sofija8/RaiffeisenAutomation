using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BausparenAutomation.utilities
{
    public class JsonReader
    {
        public JsonReader() { }

        public String extractData(String token)
        {
            String jsonString = File.ReadAllText("utilities/testData.json");
            var jsonObject = JToken.Parse(jsonString);

            return jsonObject.SelectToken(token).Value<String>();
        }
    }
}
