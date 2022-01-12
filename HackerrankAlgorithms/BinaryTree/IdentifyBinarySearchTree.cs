using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.BinaryTree
{
    class IdentifyBinarySearchTree
    {
        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Data { get; set; }
            public Node(int data)
            {
                Data = data;
            }
        }
        public bool CheckBST(Node root)
        {
            return CheckBSTNode(root, Int32.MinValue, Int32.MaxValue);
        }

        private bool CheckBSTNode(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }
            if (root.Data < min || root.Data > max)
            {
                return false;
            }
            return (CheckBSTNode(root.Left, min, root.Data - 1) && CheckBSTNode(root.Right, root.Data + 1, max));
        }
    }
}
