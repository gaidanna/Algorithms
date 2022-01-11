using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms.BinaryTree
{
    class LowestCommonAncestor_binaryTree
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
        public static Node lca(Node root, int v1, int v2)
        {
            Node searchedNode = root;
            // Write your code here.
            if (root == null)
            {
                return null;
            }
            if (v1 == root.Data || v2 == root.Data)
            {
                return searchedNode;
            }
            else if (v1 < root.Data)
            {
                if (v2 < root.Data)
                {
                    if (root.Left != null)
                    {
                        searchedNode = root.Left;
                        searchedNode = lca(searchedNode, v1, v2);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return searchedNode;
                }
            }
            else
            {
                if (v2 > root.Data)
                {
                    if (root.Right != null)
                    {
                        searchedNode = root.Right;
                        searchedNode = lca(searchedNode, v1, v2);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return searchedNode;
                }
            }
            return searchedNode;
        }
    }
}
