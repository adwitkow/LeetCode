using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class Method
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("params")]
        public List<Param> Params { get; set; }

        [JsonPropertyName("return")]
        public Return Return { get; set; }
    }
}
