using System;

namespace MonoUnit
{
    public class Expectation
    {
        object actual;
        bool inverse;

        public Expectation(object actual)
        {
            this.actual = actual;
            this.inverse = false;
        }

        public Expectation not()
        {
            inverse = true;

            return this;
        }

        public Expectation toEqual(object expected)
        {
            Test(new EqualityMatcher(expected));

            return this;
        }

        private void Test(AbstractMatcher matcher)
        {
            bool match = matcher.Match(actual);

            if (!(inverse ^ match))
            {
                string failureMessage = matcher.GetFailureMessage(inverse);

                throw new Exception(failureMessage);
            }
        }
    }
}

