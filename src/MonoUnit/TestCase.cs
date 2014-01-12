using System;
using System.Collections.Generic;

namespace MonoUnit
{
    public class TestCase
    {
        internal List<Suite> suites;
        internal Suite currentSuite;

        public TestCase()
        {
            suites = new List<Suite>();

            object[] attributes = this.GetType().GetCustomAttributes(true);
            foreach (object attribute in attributes)
            {
                if (attribute.GetType() == typeof(Describe))
                {
                    ((Describe)attribute).CreateSuite(this, null);
                    break;
                }
            }
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

        public Expectation expect(Action closure)
        {
            return new Expectation(closure);
        }

        internal Suite[] GetSuites()
        {
            return suites.ToArray();
        }
    }
}

