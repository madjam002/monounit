using System;

namespace MonoUnit.Matcher
{
    /// <summary>
    /// Represents an Equality Matcher.
    /// </summary>
    public class EqualityMatcher : AbstractMatcher
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EqualityMatcher"/> class.
        /// </summary>
        /// <param name="expected">Expected value.</param>
        public EqualityMatcher(object expected)
            : base(expected)
        {
        }

        /// <inheritdoc />
        public override bool ShowStackTrace
        {
            get { return false; }
        }

        /// <inheritdoc />
        public override bool Match(object actual)
        {
            this.Actual = actual;

            return object.Equals(this.Actual, this.Expected);
        }

        /// <inheritdoc />
        public override string GetFailureMessage(bool inverse)
        {
            if (inverse)
            {
                return string.Format("Expected {0} not to equal {1}", this.Actual, this.Expected);
            }
            else
            {
                return string.Format("Expected {0} to equal {1}", this.Actual, this.Expected);
            }
        }
    }
}
