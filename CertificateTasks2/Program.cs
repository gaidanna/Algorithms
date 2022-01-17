using System;

namespace CertificateTasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            //510289
            SchedulingJobs j = new SchedulingJobs();
            var r = j.ReadInput();
            var result = j.Sort(r);
           // var result= j.CalculateCompletionTime();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
