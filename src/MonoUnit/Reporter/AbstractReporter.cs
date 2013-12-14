using System;

namespace MonoUnit
{
    public abstract class AbstractReporter
    {
        protected int specCount;
        protected int failedSpecs;
        protected int incompleteSpecs;

        public AbstractReporter()
        {
        }

        public virtual void BeforeRun()
        {
        }

        public virtual void AfterRun(long timeTaken)
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
            specCount++;
        }

        public virtual void AfterSpec(Spec spec)
        {
            switch (spec.Status)
            {
                case SpecStatus.FAILED:
                    failedSpecs++;
                    break;
                case SpecStatus.INCOMPLETE:
                    incompleteSpecs++;
                    break;
            }
        }
    }
}

