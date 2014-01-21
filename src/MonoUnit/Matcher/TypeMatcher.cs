using System;

namespace MonoUnit.Matcher
{
    public class TypeMatcher : AbstractMatcher
    {
        public TypeMatcher(Type expected) : base(expected) {}

        public override bool Match(object actual)
        {
            this.actual = actual;

            return ((Type)expected).IsInstanceOfType(actual);
        }

        public override string GetFailureMessage(bool inverse)
        {
            string expectedName = ((Type)expected).Name;

            if (inverse)
            {
                return String.Format("Expected {0} not to be type of {1}", actual, expectedName);
            }
            else
            {
                return String.Format("Expected {0} to be type of {1}", actual, expectedName);
            }
        }

        public override bool ShowStackTrace
        {
            get { return false; }
        }
    }
}

