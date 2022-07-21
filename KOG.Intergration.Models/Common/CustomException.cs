namespace KOG.Intergration.Models.Common
{
    public class CustomException : Exception
    {
        public IDictionary<string, string> Details { get; private set; }

        public CustomException(string errorKey, string errorMessage) : base("")
        {
            this.Details = new Dictionary<string, string> { { errorKey, errorMessage } };
        }

        public CustomException(IDictionary<string, string> details) : base("")
        {
            this.Details = details;
        }

        public CustomException(string message, IDictionary<string, string> details) : base(message)
        {
            this.Details = details;
        }
    }
}
