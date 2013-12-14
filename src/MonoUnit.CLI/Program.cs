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

            }
        }
    }
}

