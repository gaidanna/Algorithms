/*Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.
Implement the LRUCache class:
LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
int get(int key) Return the value of the key if the key exists, otherwise return -1.
void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
The functions get and put must each run in O(1) average time complexity.

Example 1:
Input
["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
[[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
Output
[null, null, null, 1, null, -1, null, -1, 3, 4]

Explanation
LRUCache lRUCache = new LRUCache(2);
lRUCache.put(1, 1); // cache is {1=1}
lRUCache.put(2, 2); // cache is {1=1, 2=2}
lRUCache.get(1);    // return 1
lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
lRUCache.get(2);    // returns -1 (not found)
lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
lRUCache.get(1);    // return -1 (not found)
lRUCache.get(3);    // return 3
lRUCache.get(4);    // return 4 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LRUCache
    {
        public Dictionary<int, int> _cache;
        public int _capacity;
        public int _lastKey;
        public LRUCache(int capacity)
        {
            _cache = new Dictionary<int, int>();
            _capacity = capacity;
            _lastKey = 0;
        }

        public int Get(int key)
        {
            if (_cache.TryGetValue(key, out var value))
            { 
            return value;
            }
            return -1;
        }

        public void Put(int key, int value)
        {
            if (_cache.ContainsKey(key))
            { 
                _cache[key] = value; 
            }
            else 
            {
                if (_cache.Count == _capacity)
                {
                    _cache.Remove(_lastKey);
                } 
                _cache.Add(key, value);
                _lastKey = key;
            }
        }
    }
}
