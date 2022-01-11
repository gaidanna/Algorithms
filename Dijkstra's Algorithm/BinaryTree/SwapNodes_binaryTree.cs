using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.BinaryTree
{
    public class SwapNodes_binaryTree
    {
        public class Node
        {
            Node LeftNode;
            Node RightNode;
            int value;
            public Node(int value)
            {
                this.value = value;
            }

            public List<int> inOrdertraversal(Node node, List<int> result)
            {
                if (node.LeftNode != null)
                {
                    result = inOrdertraversal(node.LeftNode, result);
                }
                if (node.value != -1)
                {
                    result.Add(node.value);
                }

                if (node.RightNode != null)
                {
                    result = inOrdertraversal(node.RightNode, result);
                }
                return result;

            }

            public List<List<int>> swapNodes(List<List<int>> indexes, List<int> queries)
            {
                var swapResults = new List<List<int>>();
                var rootNode = FillInBinaryTree(indexes);

                foreach (var query in queries)
                {
                    rootNode.Swap(query, 1);
                    var r = inOrdertraversal(rootNode, new List<int>());
                    swapResults.Add(r);
                }
                return swapResults;
            }

            public void Swap(int query, int level)
            {
                if (LeftNode != null)
                {
                    if (level % query == 0)
                    {
                        var temp = LeftNode;
                        LeftNode = RightNode;
                        RightNode = temp;
                    }
                    level++;
                    LeftNode.Swap(query, level);
                    RightNode.Swap(query, level);
                }

            }

            public Node FillInBinaryTree(List<List<int>> indexes)
            {
                Queue<Node> nodes = new Queue<Node>();
                Node root = new Node(1);
                nodes.Enqueue(root);
                for (int i = 0; i < indexes.Count; i++)
                {
                    var currentNode = nodes.Peek();
                    while (currentNode.value == -1)
                    {
                        nodes.Dequeue();
                        currentNode = nodes.Peek();
                    }

                    if (currentNode.value != -1 && currentNode.LeftNode == null)
                    {
                        currentNode.LeftNode = new Node(indexes[i][0]);
                        currentNode.RightNode = new Node(indexes[i][1]);
                        nodes.Enqueue(currentNode.LeftNode);
                        nodes.Enqueue(currentNode.RightNode);
                        nodes.Dequeue();
                    }
                }
                return root;
            }

            public List<List<int>> ReadIndexes()
            {
                List<List<int>> indexes = new List<List<int>>();
                var numberOfNodes = Convert.ToInt32(Console.ReadLine().Trim());

                indexes = new List<List<int>>();

                for (int i = 0; i < numberOfNodes; i++)
                {
                    indexes.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(indexesTemp => Convert.ToInt32(indexesTemp)).ToList());
                }
                return indexes;
            }

            public List<int> ReadQueries()
            {
                List<int> queries = new List<int>();
                int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

                for (int i = 0; i < queriesCount; i++)
                {
                    int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
                    queries.Add(queriesItem);
                }
                return queries;
            }
        }
    }
}
