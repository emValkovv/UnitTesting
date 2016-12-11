namespace Santase.Logic.Cards
{
    using System;
    using System.Runtime.Serialization;
    using System.Runtime.CompilerServices;

    [Serializable]
    public class InternalGameException : Exception
    {
        public InternalGameException()
        {
        }

        public InternalGameException(string message) : base(message)
        {
        }

        public InternalGameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalGameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}