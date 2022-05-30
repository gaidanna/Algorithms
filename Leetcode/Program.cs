//using System;

//namespace Leetcode
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //AnagramsInString a = new AnagramsInString();

//            ////a.FindAnagrams("cbaebabacd", "abc");
//            ////a.FindAnagrams("abab", "ab");
//            //a.FindAnagrams("aaaaaaaaaaaaa", "aaaaaaaaaa");
//            //var r = 1;


//            //TwoSumsCalc tw = new TwoSumsCalc();
//            //var r = tw.TwoSum(new int[] { 3, 2, 4 }, 6);


//            //FourSum fs = new FourSum();
//            //var r = fs.FourSumCount(new int[] { -1, -1 }, new int[] { -1, 1 }, new int[] { -1, 1 }, new int[] { 1, -1 });


//            //AddTwoNumbersClass add = new AddTwoNumbersClass();
//            ////ListNode ln1 = new ListNode(2, new ListNode(4, new ListNode(3, null)));
//            ////ListNode ln2 = new ListNode(5, new ListNode(6, new ListNode(4, null)));
//            //ListNode ln1 = new ListNode(0);
//            //ListNode ln2 = new ListNode(0);
//            //var r = add.AddTwoNumbers(ln1, ln2);

//            //LongestSubstring ls = new LongestSubstring();
//            ////var r = ls.LengthOfLongestSubstring("ggububgvfk");
//            //var r = ls.LengthOfLongestSubstring("pwwkew");

//            //ZigzagConversion z = new ZigzagConversion();
//            //z.Convert("ABCD", 2);

//            //CountUniqueLetters cl = new CountUniqueLetters();
//            ////cl.UniqueLetterString("ABA");
//            //cl.UniqueLetterString("LEEEETE"); 

//            //FlipSteingToMonotoneIncrease fl = new FlipSteingToMonotoneIncrease();
//            //fl.MinFlipsMonoIncr("00011000");


//            //SearchSuggestionsSystem_Trie ss = new SearchSuggestionsSystem_Trie();
//            //ss.SuggestedProducts(new string[] { "mobile", "mouse", "moneypot", "monitor", "mousepad" }, "mouse");

//            //Subset s = new Subset();
//            //s.Subsets(new int[] { 3, 2, 4, 1 });


//            //RemoveDigits rem = new RemoveDigits();
//            //var r = rem.RemoveKdigits("12345264", 4);


//            //CountBinarySubstring sub = new CountBinarySubstring();
//            //sub.CountBinarySubstrings("00110");

//            //RemoveCoveredInterval inter = new RemoveCoveredInterval();
//            //inter.RemoveCoveredIntervals(new int[][]{ new int[] { 1, 2 }, new int[] { 1, 4 }, new int[] { 3, 4 }});

//            //K_FactorOf_N kf = new K_FactorOf_N();
//            //kf.KthFactor(1, 1);

//            //var g = new globalRelay();
//            //var r = g.solution(new int[] { 1, 3, 6, 4, 1, 2 });

//            //var rr = 1;
//            SpecialNumber n = new SpecialNumber();
//            //var r = n.method(new string[] { "22", "121" }, 2);
//            var rr = n.method(3, 5, new int[] { 2, 1, 0, 2, 1, 1, 0, 1, 2, 1, 1, 0, 0, 2, 1 });
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

public class Test
{
    public static void Main()
    {
        var parser = new HandParser();
        string input = Console.ReadLine();
        Console.WriteLine(parser.GetHandName(input));
    }
}

public class HandParser
{
    private readonly AToBConverter<char, Rank> _rankConverter = new AToBConverter<char, Rank>(_rankConversions);

    private static readonly IDictionary<char, Rank> _rankConversions = new Dictionary<char, Rank>()
    {
        {'A', Rank.Ace},
        {'2', Rank.Two},
        {'3', Rank.Three},
        {'4', Rank.Four},
        {'5', Rank.Five},
        {'6', Rank.Six},
        {'7', Rank.Seven},
        {'8', Rank.Eight},
        {'9', Rank.Nine},
        {'T', Rank.Ten},
        {'t', Rank.Ten},
        {'J', Rank.Jack},
        {'Q', Rank.Queen},
        {'O', Rank.Queen},
        {'K', Rank.King},
    };

    public string GetHandName(string input)
    {
        var splitter = new StringSplitter();
        splitter.AddCharacterToSplitOn(',');
        IEnumerable<string> tokens = splitter.Split(input);

        var tempList = GetListOfCards(tokens);

        return CheckCards(tempList);

    }

    private string CheckCards(IEnumerable<Card<Suit, Rank>> list)
    {
        IMatch<Suit, Rank> flush = new Flush<Suit, Rank>();
        IMatch<Suit, Rank> threeOfAKind = new ThreeOfAKind<Suit, Rank>();
        IMatch<Suit, Rank> twoOfAKind = new TwoOfAKind<Suit, Rank>();
        if (flush.IsMatch(list))
        {
            return "Flush";
        }
        else if (threeOfAKind.IsMatch(list))
        {
            return "ThreeOfAKind";
        }
        else if (twoOfAKind.IsMatch(list))
        {
            return "Pair";
        }
        else
        {
            return "NoMatch";
        }
    }

    private IEnumerable<Card<Suit, Rank>> GetListOfCards(IEnumerable<string> tokens)
    {
        var result = new List<Card<Suit, Rank>>();

        var lokensList = tokens.ToList();
        for (int i = 0; i < lokensList.Count; i++)
        {
            var chars = lokensList[i].ToCharArray();
            var mysuit = Suit.Spades;
            if (chars[1] == 'H')
            {
                mysuit = Suit.Hearts;
            }
            else if (lokensList[i][1] == 'D')
            {
                mysuit = Suit.Diamonds;
            }
            else if (lokensList[i][1] == 'C')
            {
                mysuit = Suit.Clubs;
            }
            var convertedRank = ConvertRank(chars[0]);
            
            if (convertedRank != null)
            {
                result.Add(new Card<Suit, Rank>(mysuit, (Rank)convertedRank));
            }
        }
        return result;
    }

    private Rank? ConvertRank(char input)
    {
        return _rankConverter.Convert(input);
    }
}

public interface IMatch<TSuit, TRank>
{
    bool IsMatch(IEnumerable<Card<TSuit, TRank>> cards);
}

public class TwoOfAKind<TSuit, TRank> : IMatch<TSuit, TRank>
{
    public bool IsMatch(IEnumerable<Card<TSuit, TRank>> cards)
    {
        return cards.GroupBy(c => c.Rank).Any(g => g.Count() >= 2);
    }
}

public class Flush<TSuit, TRank> : IMatch<TSuit, TRank>
{
    public bool IsMatch(IEnumerable<Card<TSuit, TRank>> cards)
    {
        return cards.GroupBy(c => c.Suit).Any(g => g.Count() >= 5);
    }
}

public class ThreeOfAKind<TSuit, TRank> : IMatch<TSuit, TRank>
{
    public bool IsMatch(IEnumerable<Card<TSuit, TRank>> cards)
    {
        return cards.GroupBy(c => c.Rank).Any(g => g.Count() >= 3);
    }
}

public enum Rank
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public enum Suit
{
    Hearts,
    Spades,
    Diamonds,
    Clubs
}

public class Card<TSuit, TRank>
{
    public Card(TSuit suit, TRank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public TSuit Suit { get; private set; }
    public TRank Rank { get; private set; }
}

public class AToBConverter<TA, TB> where TB : struct
{
    private readonly IDictionary<TA, TB> _conversions;

    public AToBConverter(IDictionary<TA, TB> conversions)
    {
        _conversions = conversions;
    }

    public TB? Convert(TA input)
    {
        TB output;
        if (_conversions.TryGetValue(input, out output))
        {
            return output;
        }

        return null;
    }
}

public class StringSplitter
{
    IList<char> _splitChars = new List<char>();

    public void AddCharacterToSplitOn(char splitCharacter)
    {
        _splitChars.Add(splitCharacter);
    }

    public IEnumerable<string> Split(string input)
    {
        return input.Split(_splitChars.ToArray())
            .Where(c => !String.IsNullOrEmpty(c));
    }
}