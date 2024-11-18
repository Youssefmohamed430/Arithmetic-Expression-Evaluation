using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Expression_Evaluation
{
    internal class Evaluation
    {
        Stack<int> nums;
        InfixToPostfixConversion conversion;
        public Evaluation(string PostfixExp) { 
            nums = new Stack<int>();
            conversion = new InfixToPostfixConversion();
            string temp = "";
            int num1 = 0, num2 = 0;
            for (int i = 0;i < PostfixExp.Length;i++)
            {
                if (conversion.IsDigit(PostfixExp[i]))
                    temp += PostfixExp[i];
                else if (PostfixExp[i] == ' ')
                {
                    if (temp == "") continue;
                    nums.Push(Convert.ToInt32(temp));
                    temp = "";
                    continue;
                }
                else
                {
                    if (PostfixExp[i] == '-' && conversion.IsDigit(PostfixExp[i + 1])) { 
                         temp += PostfixExp[i];
                         continue;
                    }
                    num2 = nums.Pop();
                    num1 = nums.Pop();
                    switch (PostfixExp[i])
                    {
                        case '+':
                            nums.Push(num1 + num2);
                            break;
                        case '-':
                            nums.Push(num1 - num2);
                            break;
                        case '*':
                            nums.Push(num1 * num2);
                            break;
                        case '/':
                            nums.Push(num1 / num2);
                            break;
                        case '^':
                            nums.Push(Convert.ToInt32(Math.Pow(num1, num2)));
                            break;
                    }
                }
            }
        }
        public int Result() => nums.Pop();
    }
}
