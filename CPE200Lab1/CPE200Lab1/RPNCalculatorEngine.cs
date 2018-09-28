using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : BasicCalculatorEngine
    {
        public string calculate(string str)
        {
            Stack<String> operandStack = new Stack<String>();
            string[] parts = str.Split(' ');

            foreach (String s in parts)
            {
                if (isNumber(s))
                {
                    operandStack.Push(s);
                }
                else if (isOperator(s) || s == "%")
                {
                    if (operandStack.Count < 2)
                    {
                        return "E";
                    }
                    else
                    {
                        String firstOperand;
                        String secondOperand;
                        secondOperand = operandStack.Pop();
                        firstOperand = operandStack.Pop();
                        if (s == "%" && parts.Length > 4)
                        {
                            operandStack.Push(firstOperand);
                        }
                        operandStack.Push(calculate(s, firstOperand, secondOperand));
                    }
                }
                else if (s == "1/x" || s == "√")
                {
                    operandStack.Push(calculate(s, operandStack.Pop()));
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
