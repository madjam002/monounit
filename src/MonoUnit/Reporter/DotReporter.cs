using System;

namespace MonoUnit.Reporter
{
    /// <summary>
    /// Represents a Dot Reporter.
    /// </summary>
    public class DotReporter : AbstractReporter
    {
        private static int maxPerLine = 60;

        private int lineLength = 0;

        /// <inheritdoc />
        public override void BeforeRun()
        {
            Console.WriteLine();
        }

        /// <inheritdoc />
        public override void BeforeSpec(Spec spec)
        {
            base.BeforeSpec(spec);

            if (this.lineLength == maxPerLine)
            {
                Console.WriteLine();
                this.lineLength = 0;
            }
        }

        /// <inheritdoc />
        public override void AfterSpec(Spec spec)
        {
            base.AfterSpec(spec);

            this.lineLength++;

            switch (spec.Status)
            {
                case SpecStatus.FAILED:
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write('F');
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case SpecStatus.INCOMPLETE:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write('I');
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                default:
                case SpecStatus.PASSED:
                    Console.Write('.');
                    break;
            }
        }

        /// <inheritdoc />
        public override void AfterRun(long timeTaken)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Time: {0} ms", timeTaken);

            if (this.FailedSpecs.Length > 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else if (this.IncompleteSpecs.Length > 0)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write("{0} tests, {1} failures, {2} incomplete", this.SpecCount, this.FailedSpecs.Length, this.IncompleteSpecs.Length);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            this.DisplayReport();

            Console.WriteLine();
        }
    }
}
