using ForFrontAutomation.Core;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string commandString = "FLFLFRFFLF";
            char [] commands = commandString.ToCharArray();

            Spider spider = new Spider(4, 10, 7, 15, "Left");

            spider.ProcessCommand(commandString);
            
        }
    }
}
