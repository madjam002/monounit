using MonoUnit.Matcher;
using System;

namespace MonoUnit.Test.Matcher
{
    [Describe("ExceptionMatcher")]
    public class ExceptionMatcherTest : TestCase
    {
        ExceptionMatcher exceptionMatcher = null;

        public ExceptionMatcherTest()
        {
        }

        [Describe("ShowStackTrace property")]
        public void ShowStackTraceProperty()
        {
            it("should return false", () =>
            {
                exceptionMatcher = new ExceptionMatcher(null);
                expect(exceptionMatcher.ShowStackTrace).toEqual(false);
            });
        }

        [Describe("Match method")]
        public void MatchMethod()
        {
            it("should return true if an exception of the given type was thrown", () =>
            {
                exceptionMatcher = new ExceptionMatcher(typeof(InvalidCastException));
                Action closure = () =>
                {
                    throw new InvalidCastException();
                };

                expect(exceptionMatcher.Match(closure)).toEqual(true);
            });

            it("should return false if an exception with the wrong type was thrown", () =>
            {
                exceptionMatcher = new ExceptionMatcher(typeof(InvalidCastException));
                Action closure = () =>
                {
                    throw new IndexOutOfRangeException();
                };

                expect(exceptionMatcher.Match(closure)).toEqual(false);
            });

            it("should throw an invalid operation exception if a delegate wasn't provided", () =>
            {
                exceptionMatcher = new ExceptionMatcher(typeof(InvalidCastException));
                expect(() =>
                {
                    exceptionMatcher.Match("Trolololol");
                }).toThrow<InvalidOperationException>();
            });
        }

        [Describe("GetFailureMessage method")]
        public void GetFailureMessageMethod()
        {
            it("should return the correct message when the match is inverted", () =>
            {
                exceptionMatcher = new ExceptionMatcher(typeof(InvalidCastException));
                expect(exceptionMatcher.GetFailureMessage(true)).toEqual("Expected InvalidCastException to not have been thrown");
            });

            it("should return the correct message when the match isn't inverted", () =>
            {
                exceptionMatcher = new ExceptionMatcher(typeof(InvalidCastException));
                expect(exceptionMatcher.GetFailureMessage(false)).toEqual("Expected InvalidCastException to have been thrown");
            });
        }
    }
}
