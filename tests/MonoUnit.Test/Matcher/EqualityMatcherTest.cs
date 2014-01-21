using MonoUnit.Matcher;
using System;

namespace MonoUnit.Test.Matcher
{
    [Describe("EqualityMatcher")]
    public class EqualityMatcherTest : TestCase
    {
        EqualityMatcher equalityMatcher = null;

        public EqualityMatcherTest()
        {
        }

        [Describe("ShowStackTrace property")]
        public void ShowStackTraceProperty()
        {
            it("should return false", () =>
            {
                equalityMatcher = new EqualityMatcher(null);
                expect(equalityMatcher.ShowStackTrace).toEqual(false);
            });
        }

        [Describe("Match method")]
        public void MatchMethod()
        {
            it("should return true if the actual and expected objects are equal", () =>
            {
                string object1 = "Hello World!";
                string object2 = "Hello World!";

                equalityMatcher = new EqualityMatcher(object1);

                expect(equalityMatcher.Match(object2)).toEqual(true);
            });

            it("should return true if the actual and expected objects are the same", () =>
            {
                string object1 = "Hello World!";

                equalityMatcher = new EqualityMatcher(object1);

                expect(equalityMatcher.Match(object1)).toEqual(true);
            });

            it("should return false if the actual and expected objects are different", () =>
            {
                string object1 = "Hello World!";
                string object2 = "Here I am!";

                equalityMatcher = new EqualityMatcher(object1);

                expect(equalityMatcher.Match(object2)).toEqual(false);
            });

            it("should set the actual property on the matcher", () =>
            {
                string object1 = "Hello World!";
                string object2 = "Here I am!";

                equalityMatcher = new EqualityMatcher(object1);
                equalityMatcher.Match(object2);

                expect(equalityMatcher.Expected).toBe(object1);
                expect(equalityMatcher.Actual).toBe(object2);
            });
        }

        [Describe("GetFailureMessage method")]
        public void GetFailureMessageMethod()
        {
            it("should return the correct message when the match is inverted", () =>
            {
                equalityMatcher = new EqualityMatcher("[Expected]");
                equalityMatcher.Actual = "[Actual]";
                expect(equalityMatcher.GetFailureMessage(true)).toEqual("Expected [Actual] not to equal [Expected]");
            });

            it("should return the correct message when the match isn't inverted", () =>
            {
                equalityMatcher = new EqualityMatcher("[Expected]");
                equalityMatcher.Actual = "[Actual]";
                expect(equalityMatcher.GetFailureMessage(false)).toEqual("Expected [Actual] to equal [Expected]");
            });
        }
    }
}
