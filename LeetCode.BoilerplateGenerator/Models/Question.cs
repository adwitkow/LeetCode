using System.Text.Json.Serialization;

namespace LeetCode.BoilerplateGenerator.Models
{
    internal class Question
    {
        [JsonPropertyName("titleSlug")]
        public string TitleSlug { get; set; } = string.Empty;

        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("questionFrontendId")]
        public string QuestionFrontendId { get; set; } = string.Empty;

        [JsonPropertyName("frontendQuestionId")]
        public string FrontendQuestionId { get; set; } = string.Empty;

        [JsonPropertyName("exampleTestcaseList")]
        public List<string> ExampleTestcaseList { get; set; } = [];

        [JsonPropertyName("metaData")]
        public string MetaData { get; set; } = string.Empty;
    }
}
