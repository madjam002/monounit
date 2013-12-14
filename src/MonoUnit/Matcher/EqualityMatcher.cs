using System;

namespace MonoUnit
{
    public class EqualityMatcher : AbstractMatcher
    {
        public EqualityMatcher(object expected) : base(expected) {}

        public override bool Match(object actual)
        {
            this.actual = actual;

            return object.Equals(actual, expected);
        }

        public override string GetFailureMessage(bool inverse)
        {
            if (inverse)
            {
                return String.Format("Expected {0} not to equal {1}", actual, expected);
            }
            else
            {
                return String.Format("Expected {0} to equal {1}", actual, expected);
            }
        }
    }
}

