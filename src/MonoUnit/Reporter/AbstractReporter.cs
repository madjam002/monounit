using System;
using System.Collections.Generic;

namespace MonoUnit
{
    public abstract class AbstractReporter
    {
        protected int specCount;
        protected List<Spec> failedSpecs;
        protected List<Spec> incompleteSpecs;

        public AbstractReporter()
        {
            failedSpecs = new List<Spec>();
            incompleteSpecs = new List<Spec>();
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
                    failedSpecs.Add(spec);
                    break;
                case SpecStatus.INCOMPLETE:
                    incompleteSpecs.Add(spec);
                    break;
            }
        }

        protected void DisplayReport()
        {
            if (failedSpecs.Count == 0)
                return;

            Console.WriteLine();

            for (int i = 0; i < failedSpecs.Count; i++)
            {
                Console.WriteLine();

                Spec spec = failedSpecs[i];

                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("#{0} {1}", i + 1, spec.Title);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine("  {0}", spec.Exception.Message);

                if (spec.ShowStackTrace)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(spec.Exception.StackTrace);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }
    }
}

