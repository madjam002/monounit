using System;

namespace MonoUnit.Matcher
{
    /// <summary>
    /// Represents an Exception Matcher.
    /// </summary>
    /// <typeparam name="T">Type of Exception to match.</typeparam>
    public class ExceptionMatcher<T> : AbstractMatcher
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExceptionMatcher{T}"/> class.
        /// </summary>
        public ExceptionMatcher()
            : base(null)
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
                return exception.GetType() == typeof(T);
            }

            return false;
        }

        /// <inheritdoc />
        public override string GetFailureMessage(bool inverse)
        {
            string expectedName = typeof(T).Name;

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
