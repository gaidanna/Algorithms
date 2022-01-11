using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.BinaryTree
{
    public class TopView_BinaryTree
    {
        public class Node
        {
            public int Data;
            public Node Left;
            public Node Right;
            public Node(int data)
            {
                Data = data;
                Left = null; 
                Right = null;
            }
        }

        public class QueueObj
        { 
            public int Index;
            public Node Node;
            public QueueObj(Node node, int index)
            {
                Node = node;
                Index = index;
            }
        }
        public void TopView(Node root)
        {
            Queue<QueueObj> nodes = new Queue<QueueObj>();
            SortedDictionary<int, Node> topViewValues = new SortedDictionary<int, Node>();

            if (root == null)
            {
                return;
            }
            else
            {
                nodes.Enqueue(new QueueObj(root, 0));
            }

            while (nodes.Any())
            {
                var r = nodes.Dequeue();
                if (!topViewValues.ContainsKey(r.Index))
                {
                    topViewValues.Add(r.Index, r.Node);
                }

                if (root.Left != null)
                {
                    nodes.Enqueue(new QueueObj(r.Node.Left, r.Index - 1));
                }
                if (root.Right != null)
                {
                    nodes.Enqueue(new QueueObj(r.Node.Right, r.Index + 1));
                }
            }

            foreach (var entry in topViewValues.Values)
            {
                Console.Write(entry.Data);
            }
        }
    }
}
