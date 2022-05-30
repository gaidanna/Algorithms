//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Leetcode
//{
//    public class globalRelay
//    {
//        public class StringMap<TValue> : IStringMap<TValue>
//        where TValue : class
//        {
//            private Dictionary<string, TValue> collection = new Dictionary<string, TValue>();
//            /// <summary> Returns number of elements in a map</summary>
//            public int Count => collection.Count;

//            /// <summary>
//            /// If <c>GetValue</c> method is called but a given key is not in a map then <c>DefaultValue</c> is returned.
//            /// </summary>
//            // Do not change this property
//            public TValue DefaultValue { get; set; }

//            /// <summary>
//            /// Adds a given key and value to a map.
//            /// If the given key already exists in a map, then the value associated with this key should be overriden.
//            /// </summary>
//            /// <returns>true if the value for the key was overriden otherwise false</returns>
//            /// <exception cref="System.ArgumentNullException">If the key is null</exception>
//            /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
//            /// <exception cref="System.ArgumentNullException">If the value is null</exception>
//            public bool AddElement(string key, TValue value)
//            {
//                CheckKeyArgument(key);
//                CheckValueArgument(value);

//                if (!collection.ContainsKey(key))
//                {
//                    collection.Add(key, value);
//                    return false;
//                }
//                else
//                {
//                    collection[key] = value;
//                    return true;
//                }
//            }

//            /// <summary>
//            /// Removes a given key and associated value from a map.
//            /// </summary>
//            /// <returns>true if the key was in the map and was removed otherwise false</returns>
//            /// <exception cref="System.ArgumentNullException">If the key is null</exception>
//            /// <exception cref="System.ArgumentException">If the key is an empty string</exception>
//            public bool RemoveElement(string key)
//            {
//                CheckKeyArgument(key);
//                return collection.Remove(key);
//            }

//            /// <summary>
//            /// Returns the value associated with a given key.
//            /// </summary>
//            /// <returns>The value associated with a given key or <c>DefaultValue</c> if the key does not exist in a map</returns>
//            /// <exception cref="System.ArgumentNullException">If a key is null</exception>
//            /// <exception cref="System.ArgumentException">If a key is an empty string</exception>
//            public TValue GetValue(string key)
//            {
//                CheckKeyArgument(key);

//                if (collection.ContainsKey(key))
//                {
//                    return collection[key];
//                }
//                return DefaultValue;
//            }

//            private void CheckKeyArgument(string key)
//            {
//                if (key == null)
//                {
//                    throw new ArgumentNullException(nameof(key), "Key is null");
//                }
//                if (key == string.Empty)
//                {
//                    throw new ArgumentException("Key is empty", key);
//                }
//            }

//            private void CheckValueArgument(TValue value)
//            {
//                if (value == null)
//                {
//                    throw new ArgumentNullException(nameof(value), "Key is null");
//                }
//            }
//        }

//        //public int solution(int[] A, string[] D)
//        //{
//        //    var numberOfMonthesinYear = 12;
//        //    int[] deducationsInYear = new int[numberOfMonthesinYear];
//        //    var totalValue = 0;
//        //    Dictionary<int, int> transactionAmountInYear = new Dictionary<int, int>();

//        //    for (int i = 0; i < numberOfMonthesinYear; i++)
//        //    {
//        //        transactionAmountInYear.Add(i + 1, 0);
//        //    }

//        //    for (int i = 0; i < A.Length; i++)
//        //    {
//        //        totalValue += A[i];
//        //        var month = DateTime.Parse(D[i]).Month;

//        //        if (A[i] < 0)
//        //        {
//        //            transactionAmountInYear[month] += 1;

//        //            deducationsInYear[month - 1] += A[i];
//        //        }
//        //    }

//        //    for (int i = 0; i < deducationsInYear.Length; i++)
//        //    {
//        //        if (Math.Abs(deducationsInYear[i]) < 100 || transactionAmountInYear[i + 1] < 3)
//        //        {
//        //            totalValue -= 5;
//        //        }
//        //    }
//        //    return totalValue;
//        //}

//        //public int solution(int[] A)
//        //{
//        //var list = A.ToList();
//        //list.Sort();
//        //var positiveNumbers = list.Distinct().Where(x => x > 0).ToList();

//        //var iterateNumber = 1;

//        //if (positiveNumbers.Count == 0)
//        //{
//        //    return 1;
//        //}

//        //for (int i = 0; i < positiveNumbers.Count; i++)
//        //{
//        //    if (positiveNumbers[i] == iterateNumber)
//        //    {
//        //        iterateNumber++;
//        //    }
//        //    else
//        //    {
//        //        break;
//        //    }
//        //}

//        //return iterateNumber;
//        //}

//        //public String solution(String s)
//        //{
//        //    char c = s[0];
//        //    if (Char.IsUpper(c))
//        //    { 
//        //        return "upper";
//        //    }
//        //    else if (Char.IsLower(c))
//        //    {
//        //        return "lower";
//        //    }
//        //    else if (Char.IsDigit(c))
//        //    {
//        //        return "digit";
//        //    }
//        //    else
//        //    {
//        //        return "other";
//        //    }
//        //}
//    }
//}
