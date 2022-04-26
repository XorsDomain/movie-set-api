namespace Catalyte.Theater.Utilities.HttpResponseExceptions
{
    public interface IHttpResponseException
    {
        public HttpResponseExceptionValue Value { get; set; }
    }
}
