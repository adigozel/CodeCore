using System;

namespace Pipline
{
    public class MiddlewareResult
    {
        public MiddlewareResult( bool isSucceed, string message, Exception exception, AppItem appItem )
        {
            IsSucceed = isSucceed;
            Message = message;
            Exception = exception;
            AppItem = appItem;
        }

        public static MiddlewareResult Succeed(AppItem appItem )
        {
            return new MiddlewareResult( true, "", null, appItem );
        }

        public static MiddlewareResult Failure(Exception exception )
        {
            return new MiddlewareResult( false, exception.Message, exception, null );
        }

        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public AppItem AppItem { get; set; }
    }
}
