namespace GoPlay.Package
{
    public class ErrorMessage
    {
        public Status Code;
        public string Message;

        public override string ToString()
        {
            return string.Format("{{ Code = {0}, Message = \"{1}\" }}", Code, Message);
        }
    }
}