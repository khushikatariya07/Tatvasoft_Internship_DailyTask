
namespace Mission.Entities.ViewModels
{
    public class ResponseResult
    {
        public object Data { get; set; }
        public ResponseStatus Result { get; set; }
        public string Message { get; set; }

        public void Deconstruct(out object response, out object message)
        {
            throw new NotImplementedException();
        }
    }
    public enum ResponseStatus
    {
        Error,
        Success
    }
}
