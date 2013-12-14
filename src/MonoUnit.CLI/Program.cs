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
                AbstractReporter reporter = CreateReporter(options.Reporter);

                Runner runner = new Runner(reporter);
                AssemblyLoader assemblyLoader = new AssemblyLoader(runner);

                foreach (string assemblyPath in options.Inputs)
                {
                    assemblyLoader.Load(assemblyPath);
                }

                runner.Run();
            }
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

