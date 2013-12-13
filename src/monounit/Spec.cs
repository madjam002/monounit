using System;

namespace MonoUnit
{
    public class Spec
    {
        string title;
        Action closure;
        Suite suite;

        public Spec(string title, Action closure, Suite suite)
        {
            this.title = title;
            this.closure = closure;
            this.suite = suite;
        }

        public void Run()
        {
            closure();
        }
    }
}

