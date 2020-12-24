using System;
using System.Collections.Generic;
using System.Linq;

namespace WindowHider
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length < 2 || (args[0] != "hide" && args[0] != "show" && args[0] != "toggle"))
            {
                PrintHelp();
                return;
            }
            var windowHider = new WindowHider();

            switch (args[0])
            {
                case "hide":
                    PrintModifiedWindows("Hiding windows with full titles:", windowHider.ModifyWindowState(State.Hide, args.Skip(1)));
                    break;
                case "show":
                    PrintModifiedWindows("Showing windows with full titles:", windowHider.ModifyWindowState(State.Show, args.Skip(1)));
                    break;
                case "toggle":
                    PrintModifiedWindows("Switching visibility of windows with full titles:", windowHider.ModifyWindowState(State.Toggle, args.Skip(1)));
                    break;
                default:
                    PrintHelp();
                    break;
            }
           
        }

        private static void PrintHelp()
        {
            Console.WriteLine("WindowHider.exe (show|hide|toggle) partialWindowTitle1, partialWindowTitle2, ...");
        }

        private static void PrintModifiedWindows(string description, IEnumerable<string> titles)
        {
            Console.WriteLine(description);
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }
}
}