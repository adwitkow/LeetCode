namespace LeetCode.BoilerplateGenerator
{
    public class TypeConverter
    {
        private static readonly Dictionary<string, string> Types = new Dictionary<string, string>()
        {
            { "integer", "int" },
            { "character", "char" },
            { "string", "string" },
            { "boolean", "bool" },
            { "list", "IList" },
        };
        private static readonly HashSet<string> BasicTypes = new HashSet<string>(Types.Values);

        public string Convert(string type)
        {
            // Doesn't handle the combinations atm
            // List<int[]> won't compute

            string result;
            if (IsArray(type))
            {
                result = SplitArrayType(type, out var braces);

                if (Types.TryGetValue(result, out var converted))
                {
                    result = converted;
                }

                return $"{result}{braces}";
            }
            else if (IsGeneric(type))
            {
                result = ExtractGenerics(type, out var baseType);

                if (Types.TryGetValue(result, out var converted))
                {
                    result = converted;
                }

                if (Types.TryGetValue(baseType, out var convertedBase))
                {
                    baseType = convertedBase;
                }

                return $"{baseType}<{result}>";
            }
            else
            {
                if (Types.TryGetValue(type, out var converted))
                {
                    result = converted;
                }
                else
                {
                    result = type;
                }

                return result;
            }
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
                    "string" => '\"',
                    _ => '\"',
                };
            }
            
            return $"{wrap}{value}{wrap}";
        }

        public bool IsBasicType(string type)
        {
            return BasicTypes.Contains(type);
        }

        private bool IsGeneric(string type)
        {
            return type.IndexOf('<') != -1;
        }

        private bool IsArray(string type)
        {
            return type.IndexOf('[') != -1;
        }

        private string ExtractGenerics(string type, out string baseType)
        {
            var genericIndex = type.IndexOf('<');

            if (genericIndex == -1)
            {
                baseType = string.Empty;
                return type;
            }

            baseType = type.Substring(0, genericIndex);
            return type.Substring(genericIndex + 1, type.Length - genericIndex - 2);
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
