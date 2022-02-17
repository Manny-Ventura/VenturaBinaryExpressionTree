using System;

namespace BinaryTreeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            String userInput = "";
            while (true)
            {
                Console.Write("Please enter an expression in parentheses to Evaluate (to quit type \"q\" ): ");
                userInput = Console.ReadLine();
                if (userInput == "q")
                {
                    break;
                }
                BinaryExpressionTree bet = new BinaryExpressionTree(userInput);
                Console.WriteLine(bet.Expression);
                Console.Write("Infix: ");
                bet.DisplayInOrder();
                Console.Write("Postfix: ");
                bet.DisplayPostOrder();
                Console.Write("Prefix: ");
                bet.DisplayPreOrder();
                Console.WriteLine("{0} = {1}", bet.Expression, bet.Eval());
            }


        }
    }
}
