using HackerrankAlgorithms;
using HackerrankAlgorithms.BinaryTree;
using HackerrankAlgorithms.structures;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerrankAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            ///* dijkstra algorythm */
            //int[,] graph = new int[,] { { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            //                          { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            //                          { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            //                          { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            //                          { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            //                          { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            //                          { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            //                          { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            //                          { 0, 0, 2, 0, 0, 0, 6, 7, 0 } };
            //GFG t = new GFG();
            //t.dijkstra(graph, 0);


            /* BFS algorythm */

            //BFS bfs = new BFS();
            //bfs.ReadData();

            //foreach (var node in bfs.nodesList)
            //{
            //    var distances = bfs.CalculateDistances(node.Value, node.Key);
            //    bfs.PrintResult(distances);
            //}

            ///* Dijkstra algorythm BY ME */

            //Dijkstra dijkstra = new Dijkstra();
            //dijkstra.ReadData();

            //var distances = new List<int>();
            //foreach (var calcCase in dijkstra.cases)
            //{
            //    distances = dijkstra.ShortestReach(dijkstra.numberOfNodes, calcCase, dijkstra.startVertixNumber);
            //    dijkstra.PrintResult(distances);
            //}

            ///* Dijkstra2_faster algorythm BY ME */

            //Dijkstra2 dijkstra = new Dijkstra2();
            //dijkstra.ReadData();

            //var distances = new List<int>();
            //foreach (var calcCase in dijkstra.cases)
            //{
            //    distances = dijkstra.ShortestReach(dijkstra.numberOfNodes, calcCase, dijkstra.startVertixNumber);
            //    dijkstra.PrintResult(distances);
            //}


            //Treetraversal code

            //BinaryTree tr = new BinaryTree();
            //var root = tr.ReadData();

            //var result = new List<int>();
            //result.Add(root.Data);
            ////tr.levelOrder(root);
            //var r = tr.Height(root);
            //var r2 = tr.Height2(root);
            //var r3 = tr.getHeight(root);

            //// Balanced brackets
            //BalancedBrackets bb = new BalancedBrackets();
            //var cases = bb.ReadData();
            //foreach (var c in cases)
            //{
            //    Console.WriteLine(bb.isBalanced(c));
            //}
            //Console.ReadLine();


            ////ContactsFind

            //Node cf = new Node();
            //var result = cf.ReadData();

            //var r = cf.Contacts(result);
            //foreach (var rr in r)
            //{
            //    Console.WriteLine(rr);
            //}
            //Console.ReadLine();


            //Find median - heap

            //FindMedian_Heap fm = new FindMedian_Heap();
            //var result = fm.ReadData();
            //var r = fm.runningMedian(result);
            //foreach (var rr in r)
            //{
            //    Console.WriteLine(rr);
            //}
            //Console.ReadLine();


            ////Swap binary tree
            //SwapNodes_binaryTree.Node node = new SwapNodes_binaryTree.Node(1);
            //var indexes = node.ReadIndexes();
            //var queries = node.ReadQueries();
            //var r = node.swapNodes(indexes, queries);
            //for (int i = 0; i < r.Count; i++)
            //{
            //    Console.WriteLine(String.Join(" ", r[i]));
            //}
            //Console.ReadLine();


            ////segment tree_min

            //var n = Convert.ToInt32(Console.ReadLine());
            //int[] array = new int[n];
            //for (int i = 0; i < n; i++)
            //{
            //    array[i] = Convert.ToInt32(Console.ReadLine());
            //}
            //SegmentTree st = new SegmentTree();
            //st.CreateSegmentTree(array, n);
            //var r = st.Tree;
            //var rr1 = Convert.ToInt32(Console.ReadLine());//query low
            //var rr2 = Convert.ToInt32(Console.ReadLine());//query high
            //var result = st.GetRangeMinQuery(st.Tree, 0, n - 1, rr1, rr2, 0);


            //segment tree_sum

            var n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            SegmentTree_SumOfGivenTree st = new SegmentTree_SumOfGivenTree();
            st.CreateSegmentTree(array, n);
            var r = st.Tree;
            var rr1 = Convert.ToInt32(Console.ReadLine());
            var rr2 = Convert.ToInt32(Console.ReadLine());
            var result = st.GetSumRangeQuery(st.Tree, 0, n - 1, rr1, rr2, 0);
            var indexToUpdate = Convert.ToInt32(Console.ReadLine());
            var valueToUpdate = Convert.ToInt32(Console.ReadLine());
            st.UpdateValue(array, indexToUpdate, valueToUpdate);
            var result2 = st.GetSumRangeQuery(st.Tree, 0, n - 1, rr1, rr2, 0);
        }
    }
}
