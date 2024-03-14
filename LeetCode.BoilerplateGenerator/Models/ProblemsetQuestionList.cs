using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class ProblemsetQuestionList
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("questions")]
        public List<Question> Questions { get; set; }
    }
}
