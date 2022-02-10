/* You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
 */
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public class AddTwoNumbersClass
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var number1 = ConvertLinkedListToNumber(l1);
            var number2 = ConvertLinkedListToNumber(l2);
            var sum = number1 + number2;

            var numbersQueue = ConvertNumberToQueue(sum);

            return ConvertToLinkedList(numbersQueue);
        }
        private ListNode ConvertToLinkedList(Queue<BigInteger> numbers)
        {
            ListNode head = new ListNode( -1);
            while (numbers.Any())
            {
                if (head.val == -1)
                {
                    head.val = (int)numbers.Dequeue();
                    continue;
                }
                ListNode current = head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new ListNode((int)numbers.Dequeue());
            }

            return head;
        }
        private Queue<BigInteger> ConvertNumberToQueue(BigInteger sum)
        {
            Queue<BigInteger> numbers = new Queue<BigInteger>();
            if (sum == 0)
            {
                numbers.Enqueue(0);
                return numbers;
            }
            while (sum > 0)
            {
                numbers.Enqueue(sum % 10);
                sum = sum / 10;
            }
            return numbers;
        }

        private BigInteger ConvertLinkedListToNumber(ListNode l)
        {
            StringBuilder st = new StringBuilder();
            Stack<int> numbers = new Stack<int>();
            ListNode current = l;
            while (current.next != null)
            {
                numbers.Push(current.val);
                current = current.next;
            }
            numbers.Push(current.val);


            while(numbers.Count > 0)
            {
                st.Append(numbers.Pop());
            }
            return BigInteger.Parse(st.ToString());
        }
    }
}
