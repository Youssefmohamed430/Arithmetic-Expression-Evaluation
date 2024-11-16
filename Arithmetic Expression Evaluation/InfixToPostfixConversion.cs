using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Expression_Evaluation
{
    internal class InfixToPostfixConversion
    {
        private Stack<char> stack;
        public InfixToPostfixConversion()
           => stack = new Stack<char>();
        public bool IsDigit (char  e)
             => (e >= '0' && e <= '9');

        public bool PriorityOperator(char op1,char op2)
        {
            if (op1 == '^')
                return (op2 != '(');
            else if (op1 == '/' || op1 == '*')
                return (op2 != '^' && op2 != '('); 
            else if (op1 == '+' || op1 == '-')
                return (op2 != '^' && op2 != '*' && op2 != '/' && op2 != '(');
            else
                return false;
            
        }
        public string convertion(string exp)
        {
            string postfix = "";
            for (int i = 0;i < exp.Length;i++ )
            {
                if (IsDigit(exp[i]))
                    postfix += exp[i];
                else
                {
                    if (stack.Count == 0)
                        stack.Push(exp[i]);
                    else
                    {
                        if (exp[i] != ')') {
                            while (stack.Count != 0 && PriorityOperator(stack.Peek(), exp[i]))
                            { postfix += stack.Pop(); }
                            stack.Push(exp[i]); 
                        }
                        else
                        {
                            while(stack.Peek()  != '(')
                                postfix += stack.Pop();
                            stack.Pop();
                        }
                    }
                }
            }
            while(stack.Count != 0)
                postfix += stack.Pop();
            return postfix;
        }
    }
}
