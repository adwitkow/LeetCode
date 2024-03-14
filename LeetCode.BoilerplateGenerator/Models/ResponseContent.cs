using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class ResponseContent
    {
        [JsonPropertyName("challenge")]
        public Challenge Challenge { get; set; } = default!;

        [JsonPropertyName("question")]
        public Question Question { get; set; } = default!;

        [JsonPropertyName("problemsetQuestionList")]
        public ProblemsetQuestionList ProblemsetQuestionList { get; set; } = default!;
    }
}
