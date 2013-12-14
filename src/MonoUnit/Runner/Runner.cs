using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MonoUnit
{
    public class Runner
    {
        List<TestCase> testCases;
        AbstractReporter reporter;

        Stopwatch timer;

        public Runner(AbstractReporter reporter)
        {
            this.testCases = new List<TestCase>();
            this.reporter = reporter;

            this.timer = new Stopwatch();
        }

        public void AddTestCase(TestCase testCase)
        {
            testCases.Add(testCase);
        }

        public void Run()
        {
            reporter.BeforeRun();
            timer.Reset();
            timer.Start();

            TestCase[] testCases = this.testCases.ToArray();

            foreach (TestCase testCase in testCases)
            {
                RunTestCase(testCase);
            }

            timer.Stop();
            reporter.AfterRun(timer.ElapsedMilliseconds);
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

        public Stopwatch Timer
        {
            get { return timer; }
        }
    }
}

