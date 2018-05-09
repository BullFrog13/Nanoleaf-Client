using System;

namespace Nanoleaf.Client.Exceptions
{
    public class NanoleafHttpException : Exception
    {
        public NanoleafHttpException(string message) : base(message)
        {

        }
    }
}