using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtoLangCS
{
    public class Interpreter
    {
        public static void StartShell()
        {
            while (true)
            {
                Console.Write(">>>");
                Interpret(Console.ReadLine());
            }

        }

        public static void Interpret(string? str)
        {
            if (str != null)
            {
                Lexer.Start(new string[] { str});
            }
        }
        public static void Interpret(string[]? str)
        {
            if (str != null)
            {
                Lexer.Start(str);
            }
        }
    }
}
