using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class InfixToPostfixConverter
{
    //Bài tập Stack1
    static int Precedence(char op)
    {
        if (op == '+' || op == '-')
            return 1;
        else if (op == '*' || op == '/')
            return 2;
        else
            return 0;
    }
    static bool IsOperand(char c)
    {
        return char.IsLetterOrDigit(c);
    }
    static string ConvertToPostfix(string infix)
    {
        Stack<char> stack = new Stack<char>();
        List<string> output = new List<string>();
        for (int i = 0; i < infix.Length; i++)
        {
            char token = infix[i];
            if (IsOperand(token))
            {
                output.Add(token.ToString());
            }
            else if (token == '(')
            {
                stack.Push(token);
            }
            else if (token == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    output.Add(stack.Pop().ToString());
                }
                stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && Precedence(stack.Peek()) >= Precedence(token))
                {
                    output.Add(stack.Pop().ToString());
                }
                stack.Push(token);
            }
        }
        while (stack.Count > 0)
        {
            output.Add(stack.Pop().ToString());
        }
        return string.Join(" ", output);
    }
    static void Main()
    {
        Console.Write("Nhap bieu thuc Infix: ");
        string infixExpression = Console.ReadLine();
        string postfixExpression = ConvertToPostfix(infixExpression.Replace(" ", ""));
        Console.WriteLine("Bieu thuc Postfix: " + postfixExpression);
    }
}


class PostfixCalculator
{
    //Bài tập Stack2
    static double ApplyOperator(double operand1, double operand2, char op)
    {
        switch (op)
        {
            case '+':
                return operand1 + operand2;
            case '-':
                return operand1 - operand2;
            case '*':
                return operand1 * operand2;
            case '/':
                if (operand2 == 0)
                    throw new DivideByZeroException("Khong the chia cho so 0");
                return operand1 / operand2;
            default:
                throw new InvalidOperationException("Toan tu khong duoc ho tro: " + op);
        }
    }
    static double CalculatePostfix(string expression)
    {
        Stack<double> stack = new Stack<double>();
        foreach (char token in expression)
        {
            if (char.IsDigit(token))
            {
                stack.Push(double.Parse(token.ToString()));
            }
            else if (token == '+' || token == '-' || token == '*' || token == '/')
            {
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                double result = ApplyOperator(operand1, operand2, token);
                stack.Push(result);
            }
        }
        return stack.Pop();
    }
    static void Main()
    {
        Console.Write("Nhap bieu thuc Postfix: ");
        string postfixExpression = Console.ReadLine().Replace(" ", "");
        double result = CalculatePostfix(postfixExpression);
        Console.WriteLine("Ket qua cua bieu thuc Postfix: " + result);
    }
}


class HtmlTagValidator
{
    //Bài tập Queue
    static bool IsOpeningTag(string tag)
    {
        return !tag.StartsWith("</");
    }
    static bool IsClosingTag(string tag)
    {
        return tag.StartsWith("</");
    }
    static bool ValidateHtmlTags(string htmlContent)
    {
        Stack<string> tagStack = new Stack<string>();
        Regex tagRegex = new Regex(@"</?([a-zA-Z0-9]+)[^>]*>");
        MatchCollection matches = tagRegex.Matches(htmlContent);
        foreach (Match match in matches)
        {
            string tag = match.Value;
            if (IsOpeningTag(tag))
            {
                string tagName = tag.Substring(1, tag.Length - 2);
                tagStack.Push(tagName);
            }
            else if (IsClosingTag(tag))
            {
                string tagName = tag.Substring(2, tag.Length - 3);
                if (tagStack.Count == 0 || tagStack.Peek() != tagName)
                {
                    Console.WriteLine($"Loi: The dong <{tagName}> khong khop the mo.");
                    return false;
                }
                tagStack.Pop();
            }
        }
        if (tagStack.Count > 0)
        {
            Console.WriteLine("Loi: The mo chua duoc dong.");
            return false;
        }
        return true;
    }
    static void Main()
    {
        Console.Write("Nhap duong dan den file HTML: ");
        string filePath = Console.ReadLine();
        try
        {
            string htmlContent = File.ReadAllText(filePath);
            bool isValid = ValidateHtmlTags(htmlContent);
            if (isValid)
            {
                Console.WriteLine("Tat ca the HTML deu hop le.");
            }
            else
            {
                Console.WriteLine("Co loi trong the HTML.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Loi khi doc file: " + ex.Message);
        }
    }
}
