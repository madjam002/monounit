using MonoUnit.Matcher;
using System;

namespace MonoUnit.Test.Matcher
{
    [Describe("IdentityMatcher")]
    public class IdentityMatcherTest : TestCase
    {
        IdentityMatcher identityMatcher = null;

        public IdentityMatcherTest()
        {
        }

        [Describe("ShowStackTrace property")]
        public void ShowStackTraceProperty()
        {
            it("should return false", () =>
            {
                identityMatcher = new IdentityMatcher(null);
                expect(identityMatcher.ShowStackTrace).toEqual(false);
            });
        }

        [Describe("Match method")]
        public void MatchMethod()
        {
            it("should return true if the actual and expected objects are the same", () =>
            {
                EventArgs object1 = new EventArgs();

                identityMatcher = new IdentityMatcher(object1);

                expect(identityMatcher.Match(object1)).toEqual(true);
            });

            it("should return false if the actual and expected objects are equal but not the same", () =>
            {
                EventArgs object1 = new EventArgs();
                EventArgs object2 = new EventArgs();

                identityMatcher = new IdentityMatcher(object1);

                expect(identityMatcher.Match(object2)).toEqual(false);
            });

            it("should set the actual property on the matcher", () =>
            {
                EventArgs object1 = new EventArgs();
                EventArgs object2 = new EventArgs();

                identityMatcher = new IdentityMatcher(object1);
                identityMatcher.Match(object2);

                expect(identityMatcher.Expected).toBe(object1);
                expect(identityMatcher.Actual).toBe(object2);
            });
        }

        [Describe("GetFailureMessage method")]
        public void GetFailureMessageMethod()
        {
            it("should return the correct message when the match is inverted", () =>
            {
                identityMatcher = new IdentityMatcher("[Expected]");
                identityMatcher.Actual = "[Actual]";
                expect(identityMatcher.GetFailureMessage(true)).toEqual("Expected [Actual] not to be [Expected]");
            });

            it("should return the correct message when the match isn't inverted", () =>
            {
                identityMatcher = new IdentityMatcher("[Expected]");
                identityMatcher.Actual = "[Actual]";
                expect(identityMatcher.GetFailureMessage(false)).toEqual("Expected [Actual] to be [Expected]");
            });
        }
    }
}
