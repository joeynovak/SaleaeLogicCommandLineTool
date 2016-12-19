using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace SaleaeLogicCommandLineTool
{
   class CommandLineArguments
   {
      [Option('a', "action", Required = true, HelpText = "Action you wish to perform.  Options are: Start, Stop, Save, Load")]
      public string Action { get; set; }

      [Option('v', "verbose", HelpText = "Prints all messages to standard output.")]
      public bool Verbose { get; set; }

      [Option('f', "filename", HelpText = "Filename to save captures to.")]
      public string Filename { get; set; }

      [HelpOption]
      public string GetUsage()
      {
         return HelpText.AutoBuild(this,
           (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
      }

      public static CommandLineArguments Get(string[] args)
      {
         CommandLineArguments commandLineArguments = new CommandLineArguments();
         Parser.Default.ParseArguments(args, commandLineArguments);
         return commandLineArguments;
      }
   }
}
