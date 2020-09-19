using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SearchWebApi.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SearchEngine
    {
        Google,
        Bing
    }
}
