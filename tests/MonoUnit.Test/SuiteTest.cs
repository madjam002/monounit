using System;

namespace MonoUnit.Test
{
    [Describe("Suite")]
    public class SuiteTest : TestCase
    {
        [Describe("Initialisation")]
        public void initialisation()
        {
            Suite suite = null;

            beforeEach(() => {
                suite = new Suite("Testing", null, null);
            });

            it("should initialise suites and specs and should have the right title and parent", () => {
                expect(suite.GetSpecs().Length).toEqual(0);
                expect(suite.GetSuites().Length).toEqual(0);

                expect(suite.Title).toEqual("Testing");
                expect(suite.Parent).toEqual(null);
            });
        }

        [Describe("Add/Get Suites")]
        public void addGetSuites()
        {
            Suite suite = null;

            beforeEach(() => {
                suite = new Suite("Testing", null, null);
            });

            it("should add a nested suite", () => {
                expect(suite.GetSuites().Length).toEqual(0);

                Suite nestedSuite = new Suite("Nested", null, null);
                suite.AddSuite(nestedSuite);

                expect(suite.GetSuites()[0]).toEqual(nestedSuite);
                expect(nestedSuite.Parent).toEqual(suite);
            });
        }
    }
}

