using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Expression_Evaluation
{
    internal class InfixToPostfixConversion
    {
        private string Expression;
        private Stack<char> stack;
        public InfixToPostfixConversion(string expression)
        {
            Expression = expression;
        }
        public bool IsDigit (char  e)
             => (e >= '0' && e <= '9');

        public bool PriorityOperator(char op1,char op2)
        {
            if (op1 == '^')
                return true;
            else if (op1 == '/' || op1 == '*')
                return (op2 != '^'); 
            else 
                return (op2 != '^' && op2 != '*' && op2 != '/');
        }
        public void convertion(string exp)
        {
            string postfix = "";
            foreach(char c in exp)
            {
                if(IsDigit(c))
                    postfix += c;
                else
                {
                    if(stack.Count == 0)
                        stack.Push(c);

                }
            }
        }
    }
}
