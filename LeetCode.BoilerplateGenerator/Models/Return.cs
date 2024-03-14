using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class Return
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
