using System;

namespace MonoUnit.Matcher
{
    /// <summary>
    /// Represents an Identity Matcher.
    /// </summary>
    public class IdentityMatcher : AbstractMatcher
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IdentityMatcher"/> class.
        /// </summary>
        /// <param name="expected">Expected value.</param>
        public IdentityMatcher(object expected)
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

            return object.ReferenceEquals(actual, this.Expected);
        }

        /// <inheritdoc />
        public override string GetFailureMessage(bool inverse)
        {
            if (inverse)
            {
                return string.Format("Expected {0} not to be {1}", this.Actual, this.Expected);
            }
            else
            {
                return string.Format("Expected {0} to be {1}", this.Actual, this.Expected);
            }
        }
    }
}
