using System;
using System.Collections.Generic;

namespace MonoUnit.Reporter
{
    /// <summary>
    /// Represents an Abstract Reporter.
    /// </summary>
    public abstract class AbstractReporter
    {
        private int specCount;
        private List<Spec> failedSpecs;
        private List<Spec> incompleteSpecs;

        /// <summary>
        /// Initialises a new instance of the <see cref="AbstractReporter"/> class.
        /// </summary>
        public AbstractReporter()
        {
            this.failedSpecs = new List<Spec>();
            this.incompleteSpecs = new List<Spec>();
        }

        /// <summary>
        /// Gets or sets the number of Specs that have been run on this test run.
        /// </summary>
        public int SpecCount
        {
            get { return this.specCount; }
            set { this.specCount = value; }
        }

        /// <summary>
        /// Gets the specs which have failed on this test run.
        /// </summary>
        public Spec[] FailedSpecs
        {
            get { return this.failedSpecs.ToArray(); }
        }

        /// <summary>
        /// Gets the specs that are incomplete.
        /// </summary>
        public Spec[] IncompleteSpecs
        {
            get { return this.incompleteSpecs.ToArray(); }
        }

        /// <summary>
        /// Runs before any of the tests have been run.
        /// </summary>
        public virtual void BeforeRun()
        {
        }

        /// <summary>
        /// Runs after all of the tests have finished running.
        /// </summary>
        /// <param name="timeTaken">Time it took to run the tests.</param>
        public virtual void AfterRun(long timeTaken)
        {
        }

        /// <summary>
        /// Runs before a test suite runs.
        /// </summary>
        /// <param name="suite">Suite that is about to run.</param>
        public virtual void BeforeSuite(Suite suite)
        {
        }

        /// <summary>
        /// Runs after a test suite has finished running.
        /// </summary>
        /// <param name="suite">Suite that has finished running.</param>
        public virtual void AfterSuite(Suite suite)
        {
        }

        /// <summary>
        /// Runs before a spec runs.
        /// </summary>
        /// <param name="spec">Spec that is about to run.</param>
        public virtual void BeforeSpec(Spec spec)
        {
            this.specCount++;
        }

        /// <summary>
        /// Runs after a spec has finished running.
        /// </summary>
        /// <param name="spec">Spec that has finished running.</param>
        public virtual void AfterSpec(Spec spec)
        {
            switch (spec.Status)
            {
                case SpecStatus.FAILED:
                    this.failedSpecs.Add(spec);
                    break;
                case SpecStatus.INCOMPLETE:
                    this.incompleteSpecs.Add(spec);
                    break;
            }
        }

        /// <summary>
        /// Displays a report of the test results on the console.
        /// </summary>
        protected void DisplayReport()
        {
            if (this.failedSpecs.Count == 0)
                return;

            Console.WriteLine();

            for (int i = 0; i < this.failedSpecs.Count; i++)
            {
                Console.WriteLine();

                Spec spec = this.failedSpecs[i];

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
