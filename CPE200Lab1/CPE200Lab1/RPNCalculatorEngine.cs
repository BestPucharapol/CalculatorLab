using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            // your code here
            /*
            string[] parts = str.Split(' ');
            if (!(isNumber(parts[0]) && isNumber(parts[1]) && isOperator(parts[2])))
            {
                return "E";
            }
            else
            {
                return calculate(parts[2], parts[0], parts[1], 8);
            }
            return "E";
            */
            Stack<String> operandStack = new Stack<String>();
            string[] parts = str.Split(' ');

            foreach (String s in parts)
            {
                if(isNumber(s))
                {
                    operandStack.Push(s);
                }
                else if(isOperator(s))
                {
                    if(operandStack.Count < 2)
                    {
                        return "E";
                    }
                    else
                    {
                        String firstOperand;
                        String secondOperand;
                        secondOperand = operandStack.Pop();
                        firstOperand = operandStack.Pop();
                        operandStack.Push(calculate(s, firstOperand, secondOperand));
                    }
                }
            }
            if (operandStack.Count != 1)
            {
                return "E";
            }
            else
            {
                return operandStack.Peek();
            }
        }
    }
}
