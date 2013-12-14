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
            RunSpecs(suite);

            // Run nested suites
            Suite[] suites = suite.GetSuites();
            foreach (Suite nestedSuite in suites)
            {
                RunSuite(nestedSuite);
            }

            reporter.AfterSuite(suite);
        }

        public void RunSpecs(Suite suite)
        {
            Spec[] specs = suite.GetSpecs();

            foreach (Spec spec in specs)
            {
                reporter.BeforeSpec(spec);
                RunSuiteHooks(suite, "beforeEach");

                spec.Run();

                RunSuiteHooks(suite, "afterEach");
                reporter.AfterSpec(spec);
            }
        }

        public void RunSuiteHooks(Suite suite, string name)
        {
            if (suite.Parent != null)
            {
                RunSuiteHooks(suite.Parent, name);
            }

            Action closure = suite.GetHook(name);
            if (closure != null)
            {
                closure();
            }
        }
    }
}

