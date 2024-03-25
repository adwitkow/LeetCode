namespace LeetCode.BoilerplateGenerator.Tests
{
    public class TypeConverterTests
    {
        [Fact]
        public void ShouldNotConvertComplexTypes()
        {
            var type = "TypeConverter";
            var sut = new TypeConverter();

            var result = sut.Convert(type);

            Assert.Equal(type, result);
        }

        [Fact]
        public void ShouldConvertBasicTypes()
        {
            var type = "integer";
            var sut = new TypeConverter();

            var result = sut.Convert(type);
            
            Assert.Equal("int", result);
        }

        [Fact]
        public void ShouldConvertBasicArrays()
        {
            var type = "integer[]";
            var sut = new TypeConverter();

            var result = sut.Convert(type);

            Assert.Equal("int[]", result);
        }

        [Fact]
        public void ShouldConvertBasicMultiDimensionalArrays()
        {
            var type = "integer[][]";
            var sut = new TypeConverter();

            var result = sut.Convert(type);

            Assert.Equal("int[][]", result);
        }

        [Fact]
        public void ShouldConvertBasicGenerics()
        {
            var type = "list<integer>";
            var sut = new TypeConverter();

            var result = sut.Convert(type);

            Assert.Equal("IList<int>", result);
        }
    }
}
