namespace Ibks.Models.Base
{
    public class ResultMessage
    {
        public bool Result { get; }
        public string Message { get; }

        public ResultMessage(bool result, string message)
        {
            this.Result = result;
            this.Message = message.ToString();
        }
    }
}
