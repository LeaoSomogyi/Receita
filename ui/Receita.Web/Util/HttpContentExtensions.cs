using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Receita.Web.Util
{
    public static class HttpContentExtensions
    {
        /// <summary>
        /// Json Serializer options adding SnakeCaseNamingStrategy
        /// </summary>
        private static JsonSerializerSettings SerializerSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() },
                    DateFormatString = "yyyy-MM-ddTHH:mm:ss",
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = NullValueHandling.Ignore,
                    Culture = new System.Globalization.CultureInfo("en-US"),
                    Formatting = Formatting.None,
                    FloatFormatHandling = FloatFormatHandling.DefaultValue,
                    FloatParseHandling = FloatParseHandling.Double,
                    TypeNameHandling = TypeNameHandling.None
                };
            }
        }

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            string json = await content.ReadAsStringAsync();
            T value = JsonConvert.DeserializeObject<T>(json, SerializerSettings);
            return value;
        }

        public static HttpContent SerializeAsJson(this object value)
        {
            var serialized = JsonConvert.SerializeObject(value, SerializerSettings);
            return new StringContent(serialized, Encoding.Default, "application/json");
        }
    }
}
