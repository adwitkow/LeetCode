// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;
using LeetCode.BoilerplateGenerator;
using LeetCode.BoilerplateGenerator.Models;

if (args.Length < 1 || args.Length > 2)
{
    Console.WriteLine("Usage: LeetCode.BoilerplateGenerator.exe <project-path> [question-id]");
    return;
}

Array.Resize(ref args, 2); // dirty hack

var outputPath = args[0];
int questionId;
if (!int.TryParse(args[1], out questionId))
{
    questionId = -1;
}

// TODO: Dispose client
var client = new LeetCodeClient();

string slug;
if (questionId == -1)
{
    (questionId, slug) = await client.GetDaily();
}
else
{
    slug = await client.GetSlugById(questionId);
}
var question = await client.GetQuestion(slug);
var method = JsonSerializer.Deserialize<Method>(question.MetaData);
var methodName = CapitalizeFirstLetter(method.Name);

// TODO: cleanup params
// Actually, TODO: cleanup this whole procedure,
// like what is this mess
var joinedParams = string.Join(", ", method.Params
    .Select(param => $"{ConvertType(param.Type)} {param.Name}"));
var testParams = string.Join(", ", method.Params
    .Select(param => $"string raw{CapitalizeFirstLetter(param.Name)}"));
var paramValues = string.Join(", ", method.Params
    .Select(param => param.Name));
var returnType = ConvertType(method.Return.Type);

var builder = new StringBuilder();
builder.AppendLine(@"using System.Text.Json;");
builder.AppendLine(@"using NUnit.Framework;");
builder.AppendLine(@"");
builder.AppendLine(@"namespace LeetCode");
builder.AppendLine(@"{");
builder.AppendLine($"    // https://leetcode.com/problems/{slug}/");
builder.AppendLine($"    public class _{question.QuestionFrontendId}");
builder.AppendLine(@"    {");
builder.AppendLine($"        public {returnType} {methodName}({joinedParams})");
builder.AppendLine(@"        {");
builder.AppendLine(@"");
builder.AppendLine(@"        }");
builder.AppendLine(@"");
builder.AppendLine(@"        [Test]");
AddTestCases(question.ExampleTestcaseList, returnType, builder);
builder.AppendLine($"        public void Test({testParams}, {returnType} expected)");
builder.AppendLine(@"        {");
builder.AppendLine(AddTestParamConversion(method.Params));
builder.AppendLine($"            var result = {methodName}({paramValues});");
builder.AppendLine(@"");
builder.AppendLine(@"            Assert.That(result, Is.EqualTo(expected));");
builder.AppendLine(@"        }");
builder.AppendLine(@"    }");
builder.AppendLine(@"}");

outputPath = Path.Combine(outputPath, $"{questionId}.cs");
var result = builder.ToString();
File.WriteAllText(outputPath, result);

void AddTestCases(List<string> exampleTestcaseList, string returnType, StringBuilder builder)
{
    foreach (var rawTestCase in exampleTestcaseList)
    {
        var split = rawTestCase.Split(Environment.NewLine.ToCharArray());
        int quotesToAppend = 1;
        if (split.Any(s => s.Contains('"')))
        {
            quotesToAppend = 3;
        }
        var quotes = new string('"', quotesToAppend);
        var quoted = split.Select(s => $"{quotes}{s.Trim('"')}{quotes}");
        var commaSeparated = string.Join(", ", quoted);
        builder.AppendLine($"        [TestCase({commaSeparated}, /* TODO: Replace me */ default({returnType}))]");
    }
}

string? AddTestParamConversion(List<Param> parameters)
{
    var builder = new StringBuilder();

    foreach (var param in parameters)
    {
        builder.AppendLine($"            var {param.Name} = JsonSerializer.Deserialize<{ConvertType(param.Type)}>(raw{CapitalizeFirstLetter(param.Name)})!;");
    }

    return builder.ToString();
}

static string CapitalizeFirstLetter(string input)
{
    return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
}

static string ConvertType(string input)
{
    // TODO: Make it nice, I can't look at it
    return input switch
    {
        "integer" => "int",
        "integer[]" => "int[]",
        "integer[][]" => "int[][]",
        "character" => "char",
        "character[]" => "char[]",
        "character[][]" => "char[][]",
        _ => input,
    };
}