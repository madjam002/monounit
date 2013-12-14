using System;

namespace MonoUnit.Test
{
    public class SuiteTest : TestCase
    {
        public SuiteTest()
        {
            describe("Initialisation", () => {

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

            });

            describe("Add/Get Suites", () => {

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

            });
        }
    }
}

