namespace Nanoleaf.Client.Exceptions
{
    public class NanoleafResourceNotFoundException : NanoleafHttpException
    {
        public NanoleafResourceNotFoundException(string message) : base(message)
        {

        }
    }
}