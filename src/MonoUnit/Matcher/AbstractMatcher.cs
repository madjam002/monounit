using System;

namespace MonoUnit.Matcher
{
    public abstract class AbstractMatcher
    {
        protected object expected;
        protected object actual;

        public AbstractMatcher(object expected)
        {
            this.expected = expected;
        }

        public abstract bool Match(object actual);

        public abstract string GetFailureMessage(bool inverse);

        public virtual bool ShowStackTrace
        {
            get { return true; }
        }
    }
}

