using System;

namespace MonoUnit
{
    public abstract class AbstractReporter
    {
        int specCount;
        int failedSpecs;
        int incompleteSpecs;

        public AbstractReporter()
        {
        }

        public virtual void BeforeRun()
        {
        }

        public virtual void AfterRun()
        {
        }

        public virtual void BeforeSuite(Suite suite)
        {
        }

        public virtual void AfterSuite(Suite suite)
        {
        }

        public virtual void BeforeSpec(Spec spec)
        {
        }

        public virtual void AfterSpec(Spec spec)
        {
        }
    }
}

