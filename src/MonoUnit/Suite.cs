using System;
using System.Collections.Generic;
using System.Reflection;

namespace MonoUnit
{
    public class Describe : Attribute
    {
        string title;

        public Describe(string title)
        {
            this.title = title;
        }

        public Describe()
        {
            this.title = null;
        }

        internal void CreateSuite(TestCase testCase, MethodInfo method = null)
        {
            Suite previous = testCase.currentSuite;

            string title = this.title;
            if (title == null)
            {
                if (method != null)
                {
                    title = method.Name;
                }
                else
                {
                    title = testCase.GetType().Name;
                }
            }

            Action closure = null;
            if (method != null)
            {
                closure = (Action) Delegate.CreateDelegate(typeof(Action), testCase, method);
            }

            Suite suite = new Suite(title, closure, previous);

            if (testCase.currentSuite == null)
            {
                // Root Suite
                testCase.suites.Add(suite);
            }
            else
            {
                testCase.currentSuite.AddSuite(suite);
            }

            if (method == null)
            {
                testCase.currentSuite = suite;

                MethodInfo[] methods = testCase.GetType().GetMethods();
                foreach (MethodInfo childMethod in methods)
                {
                    object[] attributes = childMethod.GetCustomAttributes(true);
                    foreach (object attribute in attributes)
                    {
                        if (attribute.GetType() == typeof(Describe))
                        {
                            Describe describeAttribute = (Describe)attribute;
                            describeAttribute.CreateSuite(testCase, childMethod);
                        }
                    }
                }
            }
            else
            {
                testCase.currentSuite = suite;
                closure();
                testCase.currentSuite = previous;
            }
        }
    }

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

