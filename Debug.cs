using System;
using System.Runtime.CompilerServices;

namespace PingDebugContainer
{
    public class Debug
    {
        public static void CatchExceptions(Exception ex, [CallerMemberName] string FunctionName = "")
        {
            string[] text = new string[] { "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", "[EXCEPTION " + FunctionName + "] " + ex.Message, "[EXCEPTION " + FunctionName + "] " + ex.StackTrace };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text[0]);
            Console.WriteLine(text[1]);
            Console.WriteLine(text[2]);
            Console.WriteLine(text[0]);
            Console.ResetColor();
        }
    }
}
