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

        Dictionary<string, Action> hooks;

        public Suite(string title, Action closure, Suite parent = null)
        {
            this.title = title;
            this.closure = closure;

            this.suites = new List<Suite>();
            this.specs = new List<Spec>();
            this.parent = null;

            this.hooks = new Dictionary<string, Action>();
        }

        public void AddSuite(Suite suite)
        {
            suites.Add(suite);
            suite.Parent = this;
        }

        public Suite[] GetSuites()
        {
            return suites.ToArray();
        }

        public void AddSpec(Spec spec)
        {
            specs.Add(spec);
        }

        public Spec[] GetSpecs()
        {
            return specs.ToArray();
        }

        public void SetHook(string name, Action action)
        {
            hooks[name] = action;
        }

        public Action GetHook(string name)
        {
            if (!hooks.ContainsKey(name))
            {
                return null;
            }

            return hooks[name];
        }

        public string Title
        {
            get
            {
                if (parent != null)
                {
                    return parent.Title + ' ' + title;
                }
                else
                {
                    return title;
                }
            }
        }

        public Action Closure
        {
            get { return closure; }
        }

        public Suite Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }
}

