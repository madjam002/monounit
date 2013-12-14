using System;
using System.Collections.Generic;

namespace MonoUnit
{
    public class TestCase
    {
        List<Suite> suites;
        Suite currentSuite;

        public TestCase()
        {
            suites = new List<Suite>();
        }

        public void describe(string title, Action closure)
        {
            Suite previous = currentSuite;

            Suite suite = new Suite(title, closure, previous);

            if (currentSuite == null)
            {
                // Root Suite
                suites.Add(suite);
            }
            else
            {
                currentSuite.AddSuite(suite);
            }

            currentSuite = suite;
            closure();
            currentSuite = previous;
        }

        public void it(string title, Action closure = null)
        {
            Spec spec = new Spec(title, closure, currentSuite);
            currentSuite.AddSpec(spec);
        }

        public void beforeEach(Action closure)
        {
            currentSuite.SetHook("beforeEach", closure);
        }

        public void afterEach(Action closure)
        {
            currentSuite.SetHook("afterEach", closure);
        }

        public Expectation expect(object actual)
        {
            return new Expectation(actual);
        }

        public Suite[] GetSuites()
        {
            return suites.ToArray();
        }
    }
}

