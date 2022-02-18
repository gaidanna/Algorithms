using System;

namespace Leetcode
{
    class Program
    {
        static void Main(string[] args)
        {
            //AnagramsInString a = new AnagramsInString();

            ////a.FindAnagrams("cbaebabacd", "abc");
            ////a.FindAnagrams("abab", "ab");
            //a.FindAnagrams("aaaaaaaaaaaaa", "aaaaaaaaaa");
            //var r = 1;


            //TwoSumsCalc tw = new TwoSumsCalc();
            //var r = tw.TwoSum(new int[] { 3, 2, 4 }, 6);


            //FourSum fs = new FourSum();
            //var r = fs.FourSumCount(new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { -1, 1 }, new int[] { 1, -1 });


            //AddTwoNumbersClass add = new AddTwoNumbersClass();
            ////ListNode ln1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
            ////ListNode ln2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));
            //ListNode ln1 = new ListNode(0);
            //ListNode ln2 = new ListNode(0);
            //var r = add.AddTwoNumbers(ln1, ln2);

            //LongestSubstring ls = new LongestSubstring();
            ////var r = ls.LengthOfLongestSubstring("ggububgvfk");
            //var r = ls.LengthOfLongestSubstring("pwwkew");

            //ZigzagConversion z = new ZigzagConversion();
            //z.Convert("ABCD", 2);

            //CountUniqueLetters cl = new CountUniqueLetters();
            ////cl.UniqueLetterString("ABA");
            //cl.UniqueLetterString("LEEEETE"); 

            //FlipSteingToMonotoneIncrease fl = new FlipSteingToMonotoneIncrease();
            //fl.MinFlipsMonoIncr("00011000");


            SearchSuggestionsSystem_Trie ss = new SearchSuggestionsSystem_Trie();
            ss.SuggestedProducts(new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse");

            //Subset s = new Subset();
            //s.Subsets(new int[] { 3, 2, 4, 1 });
        }
    }
}
