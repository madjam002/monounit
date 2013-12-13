using System;

namespace MonoUnit
{
    public class Runner
    {
        public Runner()
        {
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
            // Run specs inside suite
            RunSpecs(suite.GetSpecs());

            // Run nested suites
            Suite[] suites = suite.GetSuites();
            foreach (Suite nestedSuite in suites)
            {
                RunSuite(nestedSuite);
            }
        }

        public void RunSpecs(Spec[] specs)
        {
            foreach (Spec spec in specs)
            {
                spec.Run();
            }
        }
    }
}

