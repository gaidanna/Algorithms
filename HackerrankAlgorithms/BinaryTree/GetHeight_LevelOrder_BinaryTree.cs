using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.BinaryTree
{
    public class GetHeight_LevelOrder_BinaryTree
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

        //this is not traversal, it reads the whole tree level, left and right at a time and then go to the next level
        //public List<int> levelOrder(Node root, List<int> result)
        //{
        //    if (root == null)
        //    {
        //        return null;
        //    }
        //    if (root.Left != null)
        //    {
        //        result.Add(root.Left.Data);
        //    }
        //    if (root.Right != null)
        //    {
        //        result.Add(root.Right.Data);
        //    }
        //    levelOrder(root.Left, result);
        //    levelOrder(root.Right, result);

        //    return result;
        //}


        //from Hackerrank
        public int getHeight(Node root)
        {
            if (root == null)
            {
                return -1;
            }
            else
            {
                var r = getHeight(root.Left);
                var rr = getHeight(root.Right);
                var s = 1 + Math.Max(r, rr);
                return s;
            }
        }

        //also checked and it is ok
        public int Height2(Node root)
        {
            int leftHeight = 0;
            int rightHeight = 0;

            if (root.Left != null)
            {
                leftHeight = 1 + Height2(root.Left);
            }

            if (root.Right != null)
            {
                rightHeight = 1 + Height2(root.Right);
            }

            return leftHeight > rightHeight ? leftHeight : rightHeight;
        }

        //this one is checked and seems slower
        public int Height(Node root)
        {
            int countLeft = 0;
            int countRight = 0;
            Queue<Node> nodes = new Queue<Node>();
            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                if (nodes.Peek().Left != null)
                {
                    nodes.Enqueue(nodes.Peek().Left);
                    countLeft++;
                }
                if (nodes.Peek().Right != null)
                {
                    nodes.Enqueue(nodes.Peek().Right);
                    countRight++;
                }
                nodes.Dequeue();
            }

            return countLeft >= countRight ? countLeft : countRight;
        }

            //order on nodes of each level, verified
            public void levelOrder(Node root)
        {
            Queue<Node> nodes = new Queue<Node>();

            nodes.Enqueue(root);

            while (nodes.Count > 0)
            {
                if (nodes.Peek().Left != null)
                    nodes.Enqueue(nodes.Peek().Left);

                if (nodes.Peek().Right != null)
                    nodes.Enqueue(nodes.Peek().Right);

                Console.Write(nodes.Dequeue().Data + " ");
            }
        }

        //left, parent, right
        public void PrintInOrder(Node root)
        {
            if (root.Left != null)
            {
                PrintInOrder(root.Left);
            }
            Console.WriteLine(root.Data);
            if (root.Right != null)
            {
                PrintInOrder(root.Right);
            }
        }

        public void PreOrder(Node root)
        {
            Console.WriteLine(root.Data);
            if (root.Left != null)
            {
                PreOrder(root.Left);
            }
            if (root.Right != null)
            {
                PreOrder(root.Right);
            }
        }

        public static void postOrder(Node root)
        {
            if (root.Left != null)
            {
                postOrder(root.Left);
            }

            if (root.Right != null)
            {
                postOrder(root.Right);
            }
            Console.WriteLine(root.Data + " ");
        }

        public static Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.Data)
                {
                    cur = Insert(root.Left, data);
                    root.Left = cur;
                }
                else
                {
                    cur = Insert(root.Right, data);
                    root.Right = cur;
                }
                return root;
            }
        }

        //insert by Gayle
        //public void Insert(int value)
        //{
        //    if (value <= Data)
        //    {
        //        if (Left == null)
        //        {
        //            Left = new Node(value)
        //        }
        //        else
        //        {
        //            Insert(Left, value);
        //        }
        //    }
        //    else
        //    {
        //        if (Right == null)
        //        {
        //            Right = new Node(value);
        //        }
        //        else
        //        {
        //            Insert(Right, value);
        //        }
        //    }
        //}

        public void PrintResult(List<int> result)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in result)
            {
                if (item != 0)
                {
                    sb.Append(item + " ");
                }
            }

            Console.WriteLine(sb.ToString() + Environment.NewLine);
        }

        public Node ReadData()
        {
            Node root = new Node(0);
            var numberOfQueries = Convert.ToInt32(Console.ReadLine().Trim());
            var collection = Console.ReadLine().Trim().Split(' ');
            for (int i = 0; i < collection.Length; i++)
            {
                var data = Convert.ToInt32(collection[i]);
                if (i == 0)
                {
                    root.Data = data;
                }
                else
                {
                    Insert(root, data);
                }
            }
            return root;
        }
    }
}
