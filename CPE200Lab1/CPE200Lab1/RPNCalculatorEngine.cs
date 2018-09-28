using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            Stack<string> rpnStack = new Stack<string>();
            List<string> parts;
            /*
            parts = new List<string>();
            parts.Add("+1");
            */
            try
            {
                if(str == null || str == "")
                {
                    throw new ArgumentNullException();
                }
                parts = str.Split(' ').ToList<string>();
                /*
                foreach(String token in parts)
                {
                    if (token != "" && (!isNumber(token) && !isOperator(token)))
                    {
                        throw new ArgumentException();
                    }
                }
                */
            }
            catch (ArgumentNullException ex)
            {
                return "E";
            }
            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isNumber(token) && token[0] != '+')
                {
                    rpnStack.Push(token);
                }
                else if (isOperator(token))
                {
                    //FIXME, what if there is only one left in stack?
                    try
                    {
                        secondOperand = rpnStack.Pop();
                        firstOperand = rpnStack.Pop();
                        result = calculate(token, firstOperand, secondOperand, 6);
                        rpnStack.Push(result);
                    }
                    catch (InvalidOperationException ex)
                    {
                        return "E";
                    }
                }
                else if (token == "")
                {
                    continue;
                }
                else
                {
                    return "E";
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            try
            {
                result = rpnStack.Pop();
                if (rpnStack.Count != 0)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return result;
                    /*
                    double temp = Convert.ToDouble(result);
                    return temp.ToString("G" + 4);
                    */
                }
            }
            catch (InvalidOperationException ex)
            {
                return "E";
            }
        }
    }
}
