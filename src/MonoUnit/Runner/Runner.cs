using System;
using System.Collections.Generic;

namespace MonoUnit
{
    public class Runner
    {
        List<TestCase> testCases;
        AbstractReporter reporter;

        public Runner(AbstractReporter reporter)
        {
            this.testCases = new List<TestCase>();
            this.reporter = reporter;
        }

        public void AddTestCase(TestCase testCase)
        {
            testCases.Add(testCase);
        }

        public void Run()
        {
            reporter.BeforeRun();

            TestCase[] testCases = this.testCases.ToArray();

            foreach (TestCase testCase in testCases)
            {
                RunTestCase(testCase);
            }

            reporter.AfterRun();
        }

        public void RunTestCase(TestCase testCase)
        {
            Suite[] suites = testCase.GetSuites();

            foreach (Suite suite in suites)
            {
                RunSuite(suite);
            }
        }

        public void RunSuite(Suite suite)
        {
            reporter.BeforeSuite(suite);

            // Run specs inside suite
            RunSpecs(suite.GetSpecs());

            // Run nested suites
            Suite[] suites = suite.GetSuites();
            foreach (Suite nestedSuite in suites)
            {
                RunSuite(nestedSuite);
            }

            reporter.AfterSuite(suite);
        }

        public void RunSpecs(Spec[] specs)
        {
            foreach (Spec spec in specs)
            {
                reporter.BeforeSpec(spec);

                spec.Run();

                reporter.AfterSpec(spec);
            }
        }
    }
}

