using System;

namespace MonoUnit
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

            Console.Write('.');
        }

        public override void AfterRun()
        {
            Console.WriteLine();
        }
    }
}

