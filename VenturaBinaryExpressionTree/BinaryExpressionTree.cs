using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeDemo
{
    class BinaryExpressionTree
    {
        public int Count { get; set; }
        public BinaryNode<char> RootNode;
        public string Expression { get; private set; }

        public BinaryExpressionTree(String expression)
        {
            this.Expression = expression;
            // TODO: get rid of the pesky spaces
            expression = expression.Replace(" ", "");
            Queue<char> expr = new Queue<char>(expression.ToCharArray());
            RootNode = Parse(expr);
        }
        
        public BinaryNode<char> Parse(Queue<char> expressionQueue)
        {
            char nextChar = ' ';
            BinaryNode<char> myNode = new BinaryNode<char>();

            // TODO: get the next character from the queue
            nextChar = expressionQueue.Dequeue(); //edit   "((3 * (8 - 2)) - (1 + 9))";

            if (nextChar != '(')
            {
                // TODO: insert the code for handling a leaf
                myNode.Data = nextChar;
            }
            else
            {
                // if we get here, we have an expression: (expr op expr)
                // TODO: assign the left child of the node to the expression on the left of the operator
                myNode.Left = Parse(expressionQueue);
                // TODO: the next character in the queue is the operator; get it and assign it to the data of the node
                myNode.Data = expressionQueue.Dequeue();
                // TODO: assign the right child of the node to the expression on the right of the operator
                myNode.Right = Parse(expressionQueue);
                // TODO: consume the paren at then end of the expression; throw it away
                expressionQueue.Dequeue();
            }

            return myNode;
        }


        public double Eval()
        {
            return Eval(RootNode);
        }

        private double Eval(BinaryNode<char> node)
        {
            double value = 0;
            if (node.isLeaf())
            {
                // cheap way to convert a single digit number to an integer
                value = node.Data - '0';
            }
            else {
                switch (node.Data)
                {
                    case '+':
                        // TODO evaluate operator
                        double leftValue = Eval(node.Left);
                        double rightValue = Eval(node.Right);
                        value = leftValue + rightValue;

                        break;
                    case '-':
                        // TODO evaluate operator
                        leftValue = Eval(node.Left);
                        rightValue = Eval(node.Right);
                        value = leftValue - rightValue;
                        break;
                    case '*':
                        // TODO evaluate operator
                        leftValue = Eval(node.Left);
                        rightValue = Eval(node.Right);
                        value = leftValue * rightValue;
                        break;
                    case '/':
                        // TODO evaluate operator
                        leftValue = Eval(node.Left);
                        rightValue = Eval(node.Right);
                        value = leftValue / rightValue;
                        break;
                    case '^':
                        leftValue = Eval(node.Left);
                        rightValue = Eval(node.Right);
                        value = Math.Pow(leftValue, rightValue);
                        break;
                    default:
                        Console.WriteLine("Invalid OP {0}", node.Data);
                        value = 0;
                        break;
                } 
            }

            return value;
        }

        public void DisplayInOrder()
        {
            if (RootNode != null)
            {
                DisplayInOrder(RootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
        }

        private void DisplayInOrder(BinaryNode<char> node)
        {
            if (node.Left != null)
            {
                Console.Write('(');
                DisplayInOrder(node.Left);
            }
            Console.Write(node.Data);
            if (node.Right != null)
            {
                DisplayInOrder(node.Right);
                Console.Write(')');
            }
        }

        public void DisplayPreOrder()
        {
            // TODO create code to perform a preorder traversal
            if (RootNode != null)
            {
                DisplayPreOrder(RootNode);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
            // Remember, no parentheses for pre-order
            // You may need one other method
            Console.WriteLine();
        }
        private void DisplayPreOrder(BinaryNode<char> node)
        {
            Console.Write(node.Data);
            if (node.Left != null)
            {
                DisplayPreOrder(node.Left);
            }
            if (node.Right != null)
            {
                DisplayPreOrder(node.Right);
            }
        }   

        public void DisplayPostOrder()
        {
            // TODO create code to perform a postorder traversal
            if (RootNode != null)
            {
                DisplayPostOrder(RootNode);
            }
            else
            {
                Console.WriteLine("Tree is empty.");
            }
            Console.WriteLine();
            // Remember, no parentheses for post-order
            // You may need one other method
        }
        private void DisplayPostOrder(BinaryNode<char> node)
        {
            if (node.Left != null)
            {
                DisplayPostOrder(node.Left);
            }
            if (node.Right != null)
            {
                DisplayPostOrder(node.Right);
            }
            Console.Write(node.Data);
        }
    }
}
