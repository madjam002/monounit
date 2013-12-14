using System;
using CommandLine;
using CommandLine.Text;

namespace MonoUnit.CLI
{
    public class Options
    {
        [OptionArray('i', "inputs", Required = true, HelpText = "Input file(s) to test")]
        public string[] Inputs { get; set; }

        [Option('r', "reporter", DefaultValue = "console", HelpText = "Reporter to use")]
        public string Reporter { get; set; }
    }
}

