namespace LeetCode.BoilerplateGenerator
{
    internal class TypeConverter
    {
        private static readonly Dictionary<string, string> Types = new Dictionary<string, string>()
        {
            { "integer", "int" },
            { "character", "char" },
            { "boolean", "bool" },
        };
        private static readonly HashSet<string> BasicTypes = new HashSet<string>(Types.Values);

        public string Convert(string type)
        {
            type = SplitArrayType(type, out var braces);

            if (Types.TryGetValue(type, out var converted))
            {
                type = converted;
            }

            return $"{type}{braces}";
        }

        public string ConvertValue(string type, string value)
        {
            SplitArrayType(type, out var braces);

            char? wrap;
            if (!string.IsNullOrEmpty(braces))
            {
                wrap = '\"';
            }
            else
            {
                wrap = type switch
                {
                    "char" => '\'',
                    "int" => null,
                    _ => '\"',
                }; ;
            }
            
            return $"{wrap}{value}{wrap}";
        }

        public bool IsBasicType(string type)
        {
            return BasicTypes.Contains(type);
        }

        private string SplitArrayType(string type, out string braces)
        {
            var braceIndex = type.IndexOf('[');

            if (braceIndex == -1)
            {
                braces = string.Empty;
                return type;
            }

            braces = type.Substring(braceIndex);
            return type.Substring(0, braceIndex);
        }
    }
}
