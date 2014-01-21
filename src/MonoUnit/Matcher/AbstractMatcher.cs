using System;

namespace MonoUnit.Matcher
{
    /// <summary>
    /// Represents an Abstract Matcher.
    /// </summary>
    public abstract class AbstractMatcher
    {
        private object expected;
        private object actual;

        /// <summary>
        /// Initialises a new instance of the <see cref="AbstractMatcher"/> class.
        /// </summary>
        /// <param name="expected">Expected value.</param>
        public AbstractMatcher(object expected)
        {
            this.expected = expected;
        }

        /// <summary>
        /// Gets a value indicating whether this matcher should show a stack trace on the test report.
        /// </summary>
        public virtual bool ShowStackTrace
        {
            get { return true; }
        }

        /// <summary>
        /// Gets the expected value of this matcher instance.
        /// </summary>
        public object Expected
        {
            get { return this.expected; }
        }

        /// <summary>
        /// Gets or sets the actual value of this matcher instance.
        /// </summary>
        public object Actual
        {
            get { return this.actual; }
            set { this.actual = value; }
        }

        /// <summary>
        /// Checks whether the given actual value matches the expected value.
        /// </summary>
        /// <param name="actual">Actual value.</param>
        /// <returns>True if the two values matched, otherwise false.</returns>
        public abstract bool Match(object actual);

        /// <summary>
        /// Returns the failure message that should be shown on the test report.
        /// </summary>
        /// <param name="inverse">Whether the matcher was inversed when the test ran.</param>
        /// <returns>Failure message.</returns>
        public abstract string GetFailureMessage(bool inverse);
    }
}
