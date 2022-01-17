/*
 #1
In this programming problem and the next you'll code up the greedy algorithms from lecture for minimizing the weighted sum of completion times..
Download the text file below - jobs.txt
This file describes a set of jobs with positive and integral weights and lengths.  It has the format
[number_of_jobs]
[job_1_weight] [job_1_length]
[job_2_weight] [job_2_length]
...
For example, the third line of the file is "74 59", indicating that the second job has weight 74 and length 59.
You should NOT assume that edge weights or lengths are distinct.
Your task in this problem is to run the greedy algorithm that schedules jobs in decreasing order of the difference (weight - length).  Recall from lecture that this algorithm is not always optimal.  IMPORTANT: if two jobs have equal difference (weight - length), you should schedule the job with higher weight first.  Beware: if you break ties in a different way, you are likely to get the wrong answer.  You should report the sum of weighted completion times of the resulting schedule --- a positive integer --- in the box below. 
ADVICE: If you get the wrong answer, try out some small test cases to debug your algorithm (and post your test cases to the discussion forum).

#2
For this problem, use the same data set as in the previous problem.
Your task now is to run the greedy algorithm that schedules jobs (optimally) in decreasing order of the ratio (weight/length).  In this algorithm, it does not matter how you break ties.  You should report the sum of weighted completion times of the resulting schedule --- a positive integer --- in the box below. 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CertificateTasks2
{
    public class SchedulingJobs
    {

        public long Sort(List<Job> list)
        {
            long sum = 0;
            var lenght = 0;

            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                lenght = lenght + list[i].Length;
                sum += list[i].Weight * lenght;
            }
            return sum;
        }

        public List<Job> ReadInput()
        {
            var jobs = new List<Job>();
            int weigth;
            int length;
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\jobs.txt");
            var input = File.ReadAllLines(path);
            var count = Convert.ToInt32(input[0]);

            for (int i = 1; i <= count; i++)
            {
                var temp = input[i].Trim().Split(" ");
                weigth = Convert.ToInt32(temp[0]);
                length = Convert.ToInt32(temp[1]);
                jobs.Add(new Job(weigth, length));
            }

            return jobs;
        }
    }

    public class Job :IComparable
    {
        
        public int Weight { get; set; }
        public int Length { get; set; }
        public Job(int weight, int length)
        {
            Weight = weight;
            Length = length;
        }

        public int CompareTo(object obj)
        {
            Job Temp = (Job)obj;
            if (this.Weight - this.Length < Temp.Weight - Temp.Length)
                return 1;
            if (this.Weight - this.Length > Temp.Weight - Temp.Length)
                return -1;

            // logic for second task
            //if ((float)this.Weight / this.Length < (float)Temp.Weight / Temp.Length)
            //    return 1;
            //if ((float)this.Weight / this.Length > (float)Temp.Weight / Temp.Length)
            //    return -1;

            else
            {
                if (this.Weight < Temp.Weight)
                {
                    return 1;
                }
                if (this.Weight > Temp.Weight)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
