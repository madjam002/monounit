using System;

namespace MonoUnit.CLI
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("Running Tests...");

                DotReporter reporter = new DotReporter();
                Test test = new Test();

                Runner runner = new Runner(reporter);
                runner.AddTestCase(test);
                runner.Run();
            }
        }
    }
}

