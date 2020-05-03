using System;

namespace Schalken.PhotoDesktop
{
    public class MissingImagesException : Exception
    {
        public MissingImagesException()
        {
        }

        public MissingImagesException(string message)
            : base(message)
        {
        }

        public MissingImagesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
