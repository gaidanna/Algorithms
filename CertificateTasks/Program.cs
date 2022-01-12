using System;

namespace CertificateTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Merge sort

            //MergeSort ms = new MergeSort();
            //var unordered = ms.ReadInput();
            //var result = ms.Sort(unordered);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.Write(result[i] + " ");
            //}
            //Console.ReadLine();


            ////Calculate Inversion
            //Inversion inv = new Inversion();
            //var unordered = inv.ReadInput();
            //var result = inv.SortAndCount(unordered);
            //Console.Write(inv.InversionCount);

            //Console.ReadLine();


            ////QuickSort
            //QuickSorting qs = new QuickSorting();
            //var elements = qs.ReadInput();
            ////now fisrt task, pivotIndex = 0
            ////here we need to change pivotIndex to elements.Length - 1 for second task
            //qs.QuickSort(elements, 0, 0, elements.Length - 1);
            //Console.WriteLine($"Number of calls - {qs.NumberOfCalls}");
            //foreach (var item in elements)
            //{

            //    Console.Write(item + " ");
            //}
            //Console.ReadLine();


            ////QuickSort2
            //QuickSort2 qs = new QuickSort2();
            //var elements = qs.ReadInput();
            //qs.QuickSort(elements, elements.Length - 1, 0, elements.Length - 1);
            //Console.WriteLine($"Number of calls - {qs.NumberOfCalls}");
            //foreach (var item in elements)
            //{

            //    Console.Write(item + " ");
            //}
            //Console.ReadLine();


            ////Karger Min cut
            //KargerMinCut mincut = new KargerMinCut();
            //var input = mincut.ReadInput();
            //var result = mincut.CalculateMinCut(new Graph(input));
            //Console.WriteLine($"RESULT - {result}");
            //Console.ReadLine();


            //// SCC
            //StronglyConnectedGraph graph = new StronglyConnectedGraph();
            //var input = graph.ReadInput();
            //graph.FillInReverseGraph(graph.ReverseNodes, input);
            //graph.FillInGraph(graph.OriginalNodes, input);
            //Thread t1 = new Thread(() => graph.DFS(graph.ReverseNodes), 67108864);
            //t1.Start();
            //t1.Join();
            //var result = graph.UpdateNodesToFinishingTimes(graph.OriginalNodes);
            //Thread t2 = new Thread(() => graph.DFS(result), 67108864);
            //t2.Start();
            //t2.Join();
            //var dict = new Dictionary<int, int>();
            //for (int i = 0; i < graph.Leaders.Length; i++)
            //{
            //    if (!dict.ContainsKey(graph.Leaders[i]))
            //    {
            //        dict.Add(graph.Leaders[i], 1);
            //    }
            //    else
            //    {
            //        dict[graph.Leaders[i]] += 1;
            //    }
            //}
            //var ee = dict.Values.ToList().OrderByDescending(i => i).ToList();
            //for (int i = 0; i < 5 ; i++)
            //{
            //    Console.WriteLine(ee[i]);
            //}
            //Console.ReadLine();


            //Dijkstra
            //MyGraph graph = new MyGraph();
            //var inputValues  = graph.ReadInput();
            //var nodesMatrix = graph.FillInGraph(inputValues);
            //var result = graph.CalculateShortestPath(nodesMatrix, 1);
            //for (int i = 0; i < result.Length; i++)
            //{
            //    Console.WriteLine( $"{i + 1} - {result[i]}");
            //}
            //Console.WriteLine();


            ////2-sum
            //TwoSumAlg alg = new TwoSumAlg();
            //var input = alg.ReadInput();
            //var r = alg.TwoSumCalculate(input);


            //BINARY SEARCH
            //BinarySearch_iterative it = new BinarySearch_iterative();
            //var numbers = new int[] { 2, 3, 4, 10, 40 };
            ////var n1 = it.Search(numbers, 2);
            //var n2 = it.Search(numbers, 1);

            //BinarySearch_recursive rec = new BinarySearch_recursive();
            //var numbers = new int[] { 2, 3, 4, 10, 40, 41 };
            //var n1 = rec.Search(numbers, 0, numbers.Length - 1, 1);


            //Find median -heap

            Median fm = new Median();
            //var result = fm.ReadData();
            var result = fm.ReadDataStanford();
            var r = fm.runningMedian(result);
            double sum = 0;
            foreach (var rr in r)
            {
                sum += rr;
                //Console.WriteLine(rr);
            }
            Console.WriteLine(sum % 10000);
            Console.ReadLine();
        }
    }
}
