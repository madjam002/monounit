using System;

namespace MonoUnit.Reporter
{
    public class DotReporter : AbstractReporter
    {
        static int maxPerLine = 60;

        int lineLength = 0;

        public override void BeforeRun()
        {
            Console.WriteLine();
        }

        public override void BeforeSpec(Spec spec)
        {
            base.BeforeSpec(spec);

            if (lineLength == maxPerLine)
            {
                Console.WriteLine();
                lineLength = 0;
            }
        }

        public override void AfterSpec(Spec spec)
        {
            base.AfterSpec(spec);

            lineLength++;

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

        public override void AfterRun(long timeTaken)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Time: {0} ms", timeTaken);

            if (failedSpecs.Count > 0)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else if (incompleteSpecs.Count > 0)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.Write("{0} tests, {1} failures, {2} incomplete", specCount, failedSpecs.Count, incompleteSpecs.Count);

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            DisplayReport();

            Console.WriteLine();
        }
    }
}

