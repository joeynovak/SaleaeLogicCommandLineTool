using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saleae.SocketApi;

namespace SaleaeLogicCommandLineTool
{
   class Program
   {
      static void Main(string[] args)
      {
         CommandLineArguments arguments = CommandLineArguments.Get(args);
         SaleaeClient client = new SaleaeClient();
         client.WaitForResponse = false;
         switch (arguments.Action.ToLower())
         {
            case "start":
               client.Capture();      
               break;
            case "stop":
               client.StopCapture();
               break;
            case "save":
               client.SaveToFile(arguments.Filename);
               break;
            case "load":
               client.LoadFromFile(arguments.Filename);
               break;
            default:
               Console.WriteLine("Unknown action: " + arguments.Action);
               break;
         }                  
         client.Close();
      }      
   }
}
