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

var typeConverter = new TypeConverter();

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

// TODO: cleanup this whole procedure,
// like what is this mess

var arguments = method.Params.Select(param => new Argument()
{
    Type = typeConverter.Convert(param.Type),
    Name = param.Name
}).ToArray();

var paramValues = string.Join(", ", method.Params
    .Select(param => param.Name));
var returnType = typeConverter.Convert(method.Return.Type);

var builder = new StringBuilder();
builder.AppendLine(@"using System.Text.Json;");
builder.AppendLine(@"using LeetCode.Scaffoldings;");
builder.AppendLine(@"using NUnit.Framework;");
builder.AppendLine(@"");
builder.AppendLine(@"namespace LeetCode");
builder.AppendLine(@"{");
builder.AppendLine($"    // https://leetcode.com/problems/{slug}/");
builder.AppendLine($"    public class _{question.QuestionFrontendId}");
builder.AppendLine(@"    {");
BuildMethodDefinition(builder, "public", returnType, methodName, arguments);
builder.AppendLine(@"        {");
builder.AppendLine(@"");
builder.AppendLine(@"        }");
builder.AppendLine(@"");
builder.AppendLine(@"        [Test]");
AddTestCases(builder, question.ExampleTestcaseList, arguments);
BuildTestMethodDefinition(builder, arguments, returnType);
builder.AppendLine(@"        {");
AddTestParamConversion(builder, arguments);
builder.AppendLine($"            var result = {methodName}({paramValues});");
builder.AppendLine(@"");
builder.AppendLine(@"            Assert.That(result, Is.EqualTo(expected));");
builder.AppendLine(@"        }");
builder.AppendLine(@"    }");
builder.AppendLine(@"}");

outputPath = Path.Combine(outputPath, $"{questionId}.cs");
var result = builder.ToString();
File.WriteAllText(outputPath, result);

void AddTestCases(StringBuilder builder, List<string> exampleTestcaseList, Argument[] arguments)
{
    for (int i = 0; i < exampleTestcaseList.Count; i++)
    {
        var rawTestCase = exampleTestcaseList[i];

        builder.Append(' ', 8);
        builder.Append("[TestCase(");

        var split = rawTestCase.Split(Environment.NewLine.ToCharArray());
        for (int j = 0; j < split.Length; j++)
        {
            var argument = arguments[j];
            var value = split[j];

            var wrappedValue = typeConverter.ConvertValue(argument.Type, value);
            builder.Append($"{wrappedValue}, ");
        }

        builder.AppendLine("/* TODO: Replace me */ \"\")]");
    }
}

void AddTestParamConversion(StringBuilder builder, IEnumerable<Argument> arguments)
{
    foreach (var argument in arguments)
    {
        if (typeConverter.IsBasicType(argument.Type))
        {
            continue;
        }

        var paramName = argument.Name;
        var capitalizedParamName = CapitalizeFirstLetter(paramName);

        builder.Append(' ', 12); // Hardcoded for the time being
        builder.Append($"var {paramName} ");
        builder.Append('=');

        if (argument.Type == "ListNode")
        {
            builder.AppendLine($" ListNode.FromString(raw{capitalizedParamName});");
        }
        else
        {
            builder.Append($" JsonSerializer.Deserialize<{argument.Type}>");
            builder.AppendLine($"(raw{capitalizedParamName})!;");
        }
    }

    builder.AppendLine();
}

static string CapitalizeFirstLetter(string input)
{
    return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
}

void BuildMethodDefinition(
    StringBuilder builder,
    string access,
    string returnType,
    string methodName,
    IEnumerable<Argument> parameters)
{
    var stringParameters = parameters.Select(param => $"{param.Type} {param.Name}");
    var joinedParams = string.Join(", ", stringParameters);

    builder.Append(' ', 8); // Hardcoded for the time being

    builder.Append(access);
    builder.Append(' ');
    builder.Append(returnType);
    builder.Append(' ');
    builder.Append(methodName);
    builder.Append('(');
    builder.Append(joinedParams);
    builder.Append(')');

    builder.AppendLine();
}

void BuildTestMethodDefinition(StringBuilder builder, IEnumerable<Argument> arguments, string returnType)
{
    var convertedArguments = new List<Argument>();
    foreach (var argument in arguments)
    {
        Argument converted;
        if (typeConverter.IsBasicType(argument.Type))
        {
            converted = argument;
        }
        else
        {
            converted = new Argument()
            {
                Type = "string",
                Name = $"raw{CapitalizeFirstLetter(argument.Name)}",
            };
        }

        convertedArguments.Add(converted);
    }

    if (!typeConverter.IsBasicType(returnType))
    {
        returnType = "string";
    }

    convertedArguments.Add(new Argument()
    {
        Type = returnType,
        Name = "expected",
    });

    BuildMethodDefinition(builder, "public", "void", "Test", convertedArguments);
}

readonly struct Argument()
{
    public required string Type { get; init; }

    public required string Name { get; init; }
}