using System;

namespace MonoUnit.Matcher
{
    public class ExceptionMatcher<T> : AbstractMatcher
    {
        public ExceptionMatcher() : base(null) {}

        public override bool Match(object actual)
        {
            if (actual.GetType() != typeof(Action))
            {
                throw new InvalidOperationException("Cannot use toThrow on a non action");
            }

            try
            {
                ((Action) actual)();
            }
            catch (System.Exception exception)
            {
                return exception.GetType() == typeof(T);
            }

            return false;
        }

        public override string GetFailureMessage(bool inverse)
        {
            string expectedName = typeof(T).Name;

            if (inverse)
            {
                return String.Format("Expected {0} to not have been thrown", expectedName);
            }
            else
            {
                return String.Format("Expected {0} to have been thrown", expectedName);
            }
        }

        public override bool ShowStackTrace
        {
            get { return false; }
        }
    }
}

