using System;

namespace BinaryTreeDemo
{
    public class BinaryNode<T>
    {
        public T Data { get; set; }
        public BinaryNode<T> Left { get; set; }
        public BinaryNode<T> Right { get; set; }

        public bool isLeaf()
        {
            return (Left == null && Right == null);
        }

        public override String ToString()
        {
            return Data.ToString();
        }
    }
}
