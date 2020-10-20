namespace F2KR.Jsonizer
{
    public class JsonField
    {
        public JsonField(string name, string stringValue)
        {
            Name = name;
            StringValue = stringValue;
        }

        public string Name { get; set; }
        public string StringValue { get; set; }
    }
}