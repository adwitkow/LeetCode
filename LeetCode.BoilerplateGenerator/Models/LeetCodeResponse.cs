using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class LeetCodeResponse
    {
        [JsonPropertyName("data")]
        public ResponseContent Data { get; set; } = default!;
    }
}
