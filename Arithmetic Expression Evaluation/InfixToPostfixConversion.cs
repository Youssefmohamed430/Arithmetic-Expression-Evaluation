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
            string postfix = "",temp="";
            Stack<int> eva = new Stack<int>();
            for (int i = 0;i < exp.Length;i++ )
            {
                if (IsDigit(exp[i]))
                    temp += exp[i];
                else
                {
                    if (i == 0) { 
                        temp += exp[i];
                        continue; 
                    }
                    else if (exp[i] == '-' && !IsDigit(exp[i-1]) && exp[i-1] != ')')
                    {
                        temp += exp[i];
                        continue;
                    }
                    if (temp != "")
                        postfix += temp+" ";
                    temp = "";
                    if (stack.Count == 0)
                        stack.Push(exp[i]);
                    else
                    {
                        if (exp[i] != ')')
                        {
                            while (stack.Count != 0 && PriorityOperator(stack.Peek(), exp[i]))
                            { postfix += stack.Pop()+" "; }
                            stack.Push(exp[i]);
                        }
                        else
                        {
                            while (stack.Peek() != '(')
                                postfix += stack.Pop() + " ";
                            stack.Pop();
                        }
                    }
                }
            }
            if (temp != "")
                postfix += temp + " ";
            while (stack.Count != 0)
                postfix += stack.Pop() + " ";
            return postfix;
        }
    }
}
