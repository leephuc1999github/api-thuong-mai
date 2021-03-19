namespace library.Models.Base
{
    public class DataManagerResponse
    {
        private MethodRequest _Method;
        private int _StatusCode;
        private string _Message;
        private object _Result;

        public DataManagerResponse() { }

        public DataManagerResponse(MethodRequest method, int statusCode , string message , object result)
        {
            this._Method = method;
            this._StatusCode = statusCode;
            this._Message = message;
            this._Result = result;
        }

        public MethodRequest Method { get { return this._Method; } set { this._Method = value; } }
        public int StatusCode { get { return this._StatusCode; } set { this._StatusCode = value; } }
        public string Message { get { return this._Message; } set { this._Message = value; } }
        public object Result { get { return this._Result; } set { this._Result = value; } }
    }


    public enum MethodRequest
    {
        GET , POST , PUT , DELETE
    }
}