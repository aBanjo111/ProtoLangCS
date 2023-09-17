namespace ProtoLangCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Interpreter.Interpret(File.ReadAllLines(args[0]));
            }
            Interpreter.StartShell();
        }
    }
}