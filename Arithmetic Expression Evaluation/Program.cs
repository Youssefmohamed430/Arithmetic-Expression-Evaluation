using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Expression_Evaluation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Enter your Expression : ");
            string str = Console.ReadLine();
            InfixToPostfixConversion inf = new InfixToPostfixConversion();
            string exp = inf.convertion(str);
            Evaluation ev = new Evaluation(exp);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nPostfix Expression : ");
            Console.WriteLine(exp+"\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("The Result is : ");
            Console.WriteLine(ev.Result()+"\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
