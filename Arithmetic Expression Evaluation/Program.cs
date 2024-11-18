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
            string str = Console.ReadLine();
            InfixToPostfixConversion inf = new InfixToPostfixConversion();
            string exp = inf.convertion(str);
            Evaluation ev = new Evaluation(exp);
            Console.WriteLine(exp);
            Console.WriteLine(ev.Result());
        }
    }
}
