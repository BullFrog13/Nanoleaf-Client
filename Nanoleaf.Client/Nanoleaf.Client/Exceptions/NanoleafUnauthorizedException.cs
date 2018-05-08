namespace Nanoleaf.Client.Exceptions
{
    public class NanoleafUnauthorizedException : NanoleafHttpException
    {
        public NanoleafUnauthorizedException(string message) : base(message)
        {

        }
    }
}