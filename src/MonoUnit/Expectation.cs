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

        public Expectation toBe(object expected)
        {
            Test(new IdentityMatcher(expected));

            return this;
        }

        public Expectation toThrow<T>()
        {
            Test(new ExceptionMatcher<T>());

            return this;
        }

        private void Test(AbstractMatcher matcher)
        {
            bool match = matcher.Match(actual);

            if (!match)
            {
                string failureMessage = matcher.GetFailureMessage(inverse);

                throw new ExpectationException(failureMessage, matcher.ShowStackTrace);
            }
        }
    }
}

