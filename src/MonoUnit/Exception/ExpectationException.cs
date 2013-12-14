using System;

namespace MonoUnit
{
    public class ExpectationException : Exception
    {
        public ExpectationException(string failureMessage) : base(failureMessage) {}
    }
}

