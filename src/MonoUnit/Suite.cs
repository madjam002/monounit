using System;
using System.Collections.Generic;

namespace MonoUnit
{
    public class Suite
    {
        string title;
        Action closure;

        List<Suite> suites;
        List<Spec> specs;
        Suite parent;

        public Suite(string title, Action closure, Suite parent = null)
        {
            this.title = title;
            this.closure = closure;

            this.suites = new List<Suite>();
            this.specs = new List<Spec>();
            this.parent = null;
        }

        public void AddSuite(Suite suite)
        {
            suites.Add(suite);
        }

        public void AddSpec(Spec spec)
        {
            specs.Add(spec);
        }

        public Suite[] GetSuites()
        {
            return suites.ToArray();
        }

        public Spec[] GetSpecs()
        {
            return specs.ToArray();
        }

        public string Title
        {
            get { return title; }
        }

        public Action Closure
        {
            get { return closure; }
        }

        public Suite Parent
        {
            get { return parent; }
        }
    }
}

