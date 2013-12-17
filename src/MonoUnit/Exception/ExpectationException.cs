using System;

namespace MonoUnit
{
    public class ExpectationException : Exception
    {
        bool showStackTrace;

        public ExpectationException(string failureMessage, bool showStackTrace) : base(failureMessage)
        {
            this.showStackTrace = showStackTrace;
        }

        public bool ShowStackTrace
        {
            get { return showStackTrace; }
            set { showStackTrace = value; }
        }
    }
}

