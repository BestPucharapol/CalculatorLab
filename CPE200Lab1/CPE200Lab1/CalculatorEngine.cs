using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class CalculatorEngine
    {
        /// <summary>
        /// Check if input is a number
        /// </summary>
        /// <param name="str">Input</param>
        /// <returns>True if is a number</returns>
        protected bool isNumber(string str)
        {
            double retNum;
            return Double.TryParse(str, out retNum);
        }
        /// <summary>
        /// Check if input is an operator 
        /// </summary>
        /// <param name="str">Input</param>
        /// <returns>True if is an operator</returns>
        protected bool isOperator(string str)
        {
            switch(str) {
                case "+":
                case "-":
                case "X":
                case "÷":
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Processing input for calculation
        /// </summary>
        /// <param name="str">Text from display</param>
        /// <returns></returns>
        public string Process(string str)
        {
            //Split input string to multiple parts by space
            List<string> parts = str.Split(' ').ToList<string>();
            string result;
            //As long as we have more than one part
            while(parts.Count > 1)
            {
                //Check if the first three is ready for calcuation
                if(!(isNumber(parts[0]) && isOperator(parts[1]) && isNumber(parts[2])))
                {
                    return "E";
                } else
                {
                    //Calculate the first three
                    result = calculate(parts[1], parts[0], parts[2], 4);
                    //Remove the first three
                    parts.RemoveRange(0, 3);
                    // Put back the result
                    parts.Insert(0, result);
                }
            }
            return parts[0];
        }
        /// <summary>
        /// Calculate unary operator
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="operand"></param>
        /// <param name="maxOutputSize"></param>
        /// <returns>Result in string</returns>
        public string unaryCalculate(string operate, string operand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "√":
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = Math.Sqrt(Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("G" + remainLength);
                    }
                case "1/x":
                    if(operand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (1.0 / Convert.ToDouble(operand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("G" + remainLength);
                    }
                    break;
            }
            return "E";
        }
        /// <summary>
        /// Calculate binary operator
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="firstOperand"></param>
        /// <param name="secondOperand"></param>
        /// <param name="maxOutputSize"></param>
        /// <returns>Result in string</returns>
        public string calculate(string operate, string firstOperand, string secondOperand, int maxOutputSize = 8)
        {
            switch (operate)
            {
                case "+":
                    return (Convert.ToDouble(firstOperand) + Convert.ToDouble(secondOperand)).ToString();
                case "-":
                    return (Convert.ToDouble(firstOperand) - Convert.ToDouble(secondOperand)).ToString();
                case "X":
                    return (Convert.ToDouble(firstOperand) * Convert.ToDouble(secondOperand)).ToString();
                case "÷":
                    // Not allow devide be zero
                    if (secondOperand != "0")
                    {
                        double result;
                        string[] parts;
                        int remainLength;

                        result = (Convert.ToDouble(firstOperand) / Convert.ToDouble(secondOperand));
                        // split between integer part and fractional part
                        parts = result.ToString().Split('.');
                        // if integer part length is already break max output, return error
                        if (parts[0].Length > maxOutputSize)
                        {
                            return "E";
                        }
                        // calculate remaining space for fractional part.
                        remainLength = maxOutputSize - parts[0].Length - 1;
                        // trim the fractional part gracefully. =
                        return result.ToString("G" + remainLength);
                    }
                    break;
                case "%":
                    //your code here
                    break;
            }
            return "E";
        }
    }
}
