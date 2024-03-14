using System.Text;
using System.Text.Json;
using LeetCode.BoilerplateGenerator.Models;

namespace LeetCode.BoilerplateGenerator
{
    internal class LeetCodeClient
    {
        private readonly HttpClient _client;

        public LeetCodeClient()
        {
            // TODO: Dispose
            _client = new HttpClient();
        }

        public async Task<(int Id, string Slug)> GetDaily()
        {
            var payload = GetDailyOperation();
            var response = await SendAsync<LeetCodeResponse>(payload);

            var question = response.Data.Challenge.Question;

            var slug = question.TitleSlug;
            var questionId = int.Parse(question.QuestionFrontendId);
            return (questionId, question.TitleSlug);
        }

        public async Task<Question> GetQuestion(string slug)
        {
            var payload = GetQuestionOperation(slug);
            var response = await SendAsync<LeetCodeResponse>(payload);

            return response.Data.Question;
        }

        public async Task<string> GetSlugById(int id)
        {
            var payload = GetProblemsetQuestionListOperation(id);
            var response = await SendAsync<LeetCodeResponse>(payload);
            var question = response.Data.ProblemsetQuestionList.Questions.FirstOrDefault();

            if (question is null || int.Parse(question.FrontendQuestionId) != id)
            {
                throw new InvalidDataException($"Question with id '{id}' could not be found.");
            }

            return question.TitleSlug;
        }

        private async Task<T> SendAsync<T>(string json)
        {
            var message = CreateRequest(json);
            var response = await _client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(content)!;
        }

        private string GetQuestionOperation(string slug)
        {
            return JsonSerializer.Serialize(new
            {
                operationName = "consolePanelConfig",
                query = """
                query consolePanelConfig($titleSlug: String!) {
                  question(titleSlug: $titleSlug) {
                    questionFrontendId
                    exampleTestcaseList
                    metaData
                  }
                }
                """,
                variables = new
                {
                    titleSlug = slug
                }
            });
        }

        private string GetDailyOperation()
        {
            return JsonSerializer.Serialize(new
            {
                operationName = "daily",
                query = """
                query daily {
                    challenge: activeDailyCodingChallengeQuestion {
                        date
                        link
                        question {
                            questionFrontendId
                            titleSlug
                        }
                    }
                }
                """
            });
        }

        private string GetProblemsetQuestionListOperation(int id)
        {
            return JsonSerializer.Serialize(new
            {
                operationName = "problemsetQuestionList",
                query = """
                query problemsetQuestionList($categorySlug: String, $limit: Int, $skip: Int, $filters: QuestionListFilterInput) {
                    problemsetQuestionList: questionList(
                        categorySlug: $categorySlug
                        limit: $limit
                        skip: $skip
                        filters: $filters
                    ) {
                        total: totalNum
                        questions: data {
                            frontendQuestionId: questionFrontendId
                            title
                            titleSlug
                        }
                    }
                }
                """,
                variables = new
                {
                    categorySlug = "",
                    skip = id - 1,
                    limit = 1,
                    filters = new object()
                }
            });
        }

        private HttpRequestMessage CreateRequest(string content)
        {
            var message = new HttpRequestMessage(HttpMethod.Post, "https://leetcode.com/graphql");
            message.Headers.Add("Origin", "https://leetcode.com");
            message.Headers.Add("Referer", "https://leetcode.com");
            message.Headers.Add("Cookie", "csrftoken=; LEETCODE_SESSION=;");
            message.Headers.Add("x-csrftoken", "");
            message.Headers.Add("user-agent", "Mozilla/5.0 LeetCode API");
            message.Content = new StringContent(content, Encoding.UTF8, "application/json");

            return message;
        }
    }
}
