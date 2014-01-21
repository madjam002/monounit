using MonoUnit.Matcher;
using System;

namespace MonoUnit.Test.Matcher
{
    [Describe("TypeMatcher")]
    public class TypeMatcherTest : TestCase
    {
        TypeMatcher typeMatcher = null;

        public TypeMatcherTest()
        {
        }

        [Describe("ShowStackTrace property")]
        public void ShowStackTraceProperty()
        {
            it("should return false", () =>
            {
                typeMatcher = new TypeMatcher(null);
                expect(typeMatcher.ShowStackTrace).toEqual(false);
            });
        }

        [Describe("Match method")]
        public void MatchMethod()
        {
            it("should return true if the given instance is an instance of the expected type", () =>
            {
                typeMatcher = new TypeMatcher(typeof(string));
                expect(typeMatcher.Match("Testing!")).toEqual(true);
            });

            it("should return false if the given instance isn't an instance of the expected type", () =>
            {
                typeMatcher = new TypeMatcher(typeof(int));
                expect(typeMatcher.Match("Testing!")).toEqual(false);
            });

            it("should set the actual property on the matcher", () =>
            {
                Type stringType = typeof(string);
                EventArgs value = new EventArgs();

                typeMatcher = new TypeMatcher(stringType);
                typeMatcher.Match(value);

                expect(typeMatcher.Expected).toBe(stringType);
                expect(typeMatcher.Actual).toBe(value);
            });
        }

        [Describe("GetFailureMessage method")]
        public void GetFailureMessageMethod()
        {
            it("should return the correct message when the match is inverted", () =>
            {
                typeMatcher = new TypeMatcher(typeof(string));
                typeMatcher.Actual = typeof(int);
                expect(typeMatcher.GetFailureMessage(true)).toEqual("Expected System.Int32 not to be type of String");
            });

            it("should return the correct message when the match isn't inverted", () =>
            {
                typeMatcher = new TypeMatcher(typeof(string));
                typeMatcher.Actual = typeof(int);
                expect(typeMatcher.GetFailureMessage(false)).toEqual("Expected System.Int32 to be type of String");
            });
        }
    }
}
