using System;
using F2KR.Jsonizer;
using Xunit;

namespace F2Kr.Jsonizer.Tests.TestJsonShortcut
{
    public class test_getFields
    {
        [Theory]
        [InlineData("sample1.json","$.*")]
        [InlineData("sample2.json","$.covers.*")]
        [InlineData("sample3.json", "$.*")]
        public void test_json_get_fields(string filePath, string jsonPath)
        {
           // ShortCuts sut = new ShortCuts();
           var json = ShortCuts.LoadTextFile(filePath);

           var fields = ShortCuts.GetFields(json, jsonPath);
           
           Assert.All(fields, field => Assert.False(string.IsNullOrWhiteSpace( field.Name) || string.IsNullOrWhiteSpace( field.StringValue) ));
        }
    }
}