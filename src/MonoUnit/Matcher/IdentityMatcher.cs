using System;

namespace MonoUnit.Matcher
{
    public class IdentityMatcher : AbstractMatcher
    {
        public IdentityMatcher(object expected) : base(expected) {}

        public override bool Match(object actual)
        {
            this.actual = actual;

            return object.ReferenceEquals(actual, expected);
        }

        public override string GetFailureMessage(bool inverse)
        {
            if (inverse)
            {
                return String.Format("Expected {0} not to be {1}", actual, expected);
            }
            else
            {
                return String.Format("Expected {0} to be {1}", actual, expected);
            }
        }

        public override bool ShowStackTrace
        {
            get { return false; }
        }
    }
}

