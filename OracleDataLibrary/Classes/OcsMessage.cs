namespace OracleDataLibrary.Classes
{
    public class OcsMessage
    {
        public decimal Id { get; set; }
        public string MessageText { get; set; }
        public string LanguageCode { get; set; }
        public string FormFieldName { get; set; }
        public int? FormFieldOrder { get; set; }
    }
}
