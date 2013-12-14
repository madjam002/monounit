using System;

namespace MonoUnit
{
    public class Spec
    {
        string title;
        Action closure;
        Suite suite;

        SpecStatus status;
        Exception exception;

        public Spec(string title, Action closure, Suite suite)
        {
            this.title = title;
            this.closure = closure;
            this.suite = suite;

            this.status = SpecStatus.WAITING;
            this.exception = null;
        }

        public void Run()
        {
            try
            {
                if (closure != null)
                {
                    closure();
                    this.status = SpecStatus.PASSED;
                }
                else
                {
                    this.status = SpecStatus.INCOMPLETE;
                }
            }
            catch (ExpectationException ex)
            {
                exception = ex;
                this.status = SpecStatus.FAILED;
            }
            catch (Exception ex)
            {
                exception = ex;
                this.status = SpecStatus.FAILED;
            }
        }

        public string Title
        {
            get { return title; }
        }

        public Action Closure
        {
            get { return closure; }
        }

        public Suite Suite
        {
            get { return suite; }
        }

        public SpecStatus Status
        {
            get { return status; }
        }

        public Exception Exception
        {
            get { return exception; }
        }
    }
}

