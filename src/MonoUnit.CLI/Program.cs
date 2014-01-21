using MonoUnit.Reporter;
using System;

namespace MonoUnit.CLI
{
    class MainClass
    {
        static bool testsRunning = false;

        public static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if (options.Watch)
                {
                    Watcher watcher = new Watcher();
                    foreach (string path in options.Inputs)
                    {
                        watcher.Watch(path);
                    }

                    watcher.Changed += () => {
                        RunTests(options.Inputs, options.Reporter);
                    };
                }

                RunTests(options.Inputs, options.Reporter);

                if (options.Watch)
                {
                    while (true)
                        ;
                }
            }
        }

        static void RunTests(string[] inputs, string reporterName)
        {
            if (testsRunning)
                return;

            testsRunning = true;

            AbstractReporter reporter = CreateReporter(reporterName);

            Runner.Runner runner = new Runner.Runner(reporter);
            AssemblyLoader loader = new AssemblyLoader(runner);

            foreach (string assemblyPath in inputs)
            {
                loader.Load(assemblyPath);
            }

            runner.Run();

            testsRunning = false;
        }

        static AbstractReporter CreateReporter(string name)
        {
            switch (name)
            {
                case "dot":
                    return new DotReporter();
            }

            return null;
        }
    }
}

