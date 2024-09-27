// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string expression = "{[(2+3)*(5-1)]}";

bool isValid = IsBalanced(expression);
Console.WriteLine("Is the expression balanced? " + isValid);
Console.ReadKey();


static bool IsBalanced(string expression)
{
    Stack<char> stack = new Stack<char>();

    foreach (char c in expression)
    {
        if (c == '(' || c == '{' || c == '[')
        {
            stack.Push(c);
        }
        else if (c == ')' || c == '}' || c == ']')
        {
            if (stack.Count == 0) return false;

            char top = stack.Pop();
            if (!Matches(top, c)) return false;
        }
    }

    return stack.Count == 0;
}

static bool Matches(char open, char close)
{
    return (open == '(' && close == ')') ||
           (open == '{' && close == '}') ||
           (open == '[' && close == ']');
}
