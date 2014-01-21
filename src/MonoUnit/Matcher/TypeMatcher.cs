using System;

namespace MonoUnit.Matcher
{
    /// <summary>
    /// Represents a Type Matcher.
    /// </summary>
    public class TypeMatcher : AbstractMatcher
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TypeMatcher"/> class.
        /// </summary>
        /// <param name="expected">Expected value.</param>
        public TypeMatcher(Type expected)
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

            return ((Type)this.Expected).IsInstanceOfType(actual);
        }

        /// <inheritdoc />
        public override string GetFailureMessage(bool inverse)
        {
            string expectedName = ((Type)this.Expected).Name;

            if (inverse)
            {
                return string.Format("Expected {0} not to be type of {1}", this.Actual, expectedName);
            }
            else
            {
                return string.Format("Expected {0} to be type of {1}", this.Actual, expectedName);
            }
        }
    }
}
