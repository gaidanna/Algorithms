using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
	//Count Unique Characters of All Substrings of a Given String
	public class CountUniqueLetters
    {
		public int UniqueLetterString(string s)
		{
			var ans = 0;
			var count = 0;
			int[] lastCount = new int[26];
			int[] lastSeen = new int[26];
			System.Array.Fill(lastSeen, -1);
			for (var i = 0; i < s.Length; ++i)
			{
				var c = (int)(s[i]) - (int)('A');
				var currentCount = i - lastSeen[c];
				count = count - lastCount[c] + currentCount;
				lastCount[c] = currentCount;
				lastSeen[c] = i;
				ans += count;
			}
			return ans;
			//int[] alphabet = new int[26];
			//int lettersCount = 0;
			//int result = 0;

			//         for (int i = 0; i < s.ToCharArray().Length; i++)
			//         {
			//	lettersCount += i + 1;
			//	if (alphabet[s[i] - 'A'] != 0)
			//	{
			//		if (s[i] == s[i - 1])
			//		{
			//			lettersCount = 2;
			//		}
			//		else
			//		{
			//			lettersCount -= (alphabet[s[i] - 'A'] + 1);
			//		}

			//	}

			//	alphabet[s[i] - 'A'] += 1;
			//	result += lettersCount;
			//}
			//return result;
		}

	}
}
