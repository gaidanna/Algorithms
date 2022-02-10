/* You are given an array of logs. Each log is a space-delimited string of words, where the first word is the identifier.
There are two types of logs:
Letter-logs: All words (except the identifier) consist of lowercase English letters.
Digit-logs: All words (except the identifier) consist of digits.

Reorder these logs so that:
The letter-logs come before all digit-logs.
The letter-logs are sorted lexicographically by their contents. If their contents are the same, then sort them lexicographically by their identifiers.
The digit-logs maintain their relative ordering.
Return the final order of the logs.

Example 1:
Input: logs = ["dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"]
Output: ["let1 art can","let3 art zero","let2 own kit dig","dig1 8 1 5 1","dig2 3 6"]
Explanation:
The letter-log contents are all different, so their ordering is "art can", "art zero", "own kit dig".
The digit-logs have a relative order of "dig1 8 1 5 1", "dig2 3 6".
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ReorderDataInLog
    {
        public string[] ReorderLogFiles(string[] logs)
        {
            var resultLogs = new string[logs.Length];
            StringBuilder sb;
            var letters = new Dictionary<string, Tuple<string, string>>();
            var digits = new List<string>();
            for (int i = 0; i < logs.Length; i++)
            {
                var parsed = logs[i].Split(' ');
                if (Int32.TryParse(parsed[1].Substring(0, 1), out var result))
                {
                    digits.Add(logs[i]);
                }
                else
                {
                    sb = new StringBuilder();
                    var index = logs[i].IndexOf(' ');
                    sb.Append(logs[i].Substring(index + 1, logs[i].Length - (index + 1)));
                    letters.Add(logs[i], new Tuple<string, string>(sb.ToString(), logs[i].Substring(0, index)));
                }
            }
            var sortedLetters = letters.OrderBy(k => k.Value.Item1).ThenBy(k => k.Value.Item2).ToDictionary(obj => obj.Key, obj => obj.Value);
            Queue<string> queue = new Queue<string>(sortedLetters.Keys);
            
            var ind = 0;
            while (queue.Any())
            {
                resultLogs[ind] = queue.Dequeue(); ;
                ind++;
            }

            queue = new Queue<string>(digits);

            while (queue.Any())
            {
                resultLogs[ind] = queue.Dequeue(); ;
                ind++;
            }

            return resultLogs;
        }
    }
}
