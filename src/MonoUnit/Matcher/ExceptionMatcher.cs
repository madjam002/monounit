using System;

namespace MonoUnit.Matcher
{
    /// <summary>
    /// Represents an Exception Matcher.
    /// </summary>
    public class ExceptionMatcher : AbstractMatcher
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExceptionMatcher"/> class.
        /// </summary>
        /// <param name="expected">Expected Exception Type.</param>
        public ExceptionMatcher(Type expected)
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
            if (actual.GetType() != typeof(Action))
            {
                throw new InvalidOperationException("Cannot use toThrow on a non action");
            }

            try
            {
                ((Action)actual)();
            }
            catch (System.Exception exception)
            {
                return exception.GetType() == (Type)this.Expected;
            }

            return false;
        }

        /// <inheritdoc />
        public override string GetFailureMessage(bool inverse)
        {
            string expectedName = ((Type)this.Expected).Name;

            if (inverse)
            {
                return string.Format("Expected {0} to not have been thrown", expectedName);
            }
            else
            {
                return string.Format("Expected {0} to have been thrown", expectedName);
            }
        }
    }
}
