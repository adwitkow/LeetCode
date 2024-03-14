using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class Challenge
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("question")]
        public Question Question { get; set; }
    }
}
