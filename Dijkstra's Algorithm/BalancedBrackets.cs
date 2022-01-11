using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankAlgorithms
{
    public class BalancedBrackets
    {
        public int numberOfCases;
        List<string> cases = new List<string>();
        char[] brackets = new char[] { '(', '{', '[', ']', '}', ')' };
        public List<string> ReadData()
        {
            numberOfCases = Convert.ToInt32(Console.ReadLine().Trim());

            for (int tItr = 0; tItr < numberOfCases; tItr++)
            {
                string s = Console.ReadLine();
                cases.Add(s);
            }
            return cases;
        }

        public string isBalanced(string s)
        {
            Stack<char> bracketsCollection = new Stack<char>();
            var stringArray = s.ToCharArray();
            if (stringArray.Length % 2 != 0)
            {
                return "NO";
            }
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (stringArray[i] == brackets[0] || stringArray[i] == brackets[1] || stringArray[i] == brackets[2])
                {
                    bracketsCollection.Push(stringArray[i]);
                }
                else if (stringArray[i] == brackets[3] || stringArray[i] == brackets[4] || stringArray[i] == brackets[5])
                {
                    if (bracketsCollection.Any())
                    {
                        var bracket = bracketsCollection.Pop();
                        if (stringArray[i] == brackets[3] && bracket != brackets[2])
                        {
                            return "NO";
                        }
                        else if (stringArray[i] == brackets[4] && bracket != brackets[1])
                        {
                            return "NO";
                        }
                        else if (stringArray[i] == brackets[5] && bracket != brackets[0])
                        {
                            return "NO";
                        }
                    }
                    else
                    {
                        return "NO";
                    }
                }
                else
                {
                    return "NO";
                }
            }
            if (bracketsCollection.Any())
            {
                return "NO";
            }
            return "YES";
        }
    }
}
