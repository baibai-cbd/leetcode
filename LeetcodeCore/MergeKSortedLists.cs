using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class MergeKSortedLists
    {
        // 23. Merge k Sorted Lists
        // Using for loop to determine smallest among first values
        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            var dummy = new ListNode(0);
            var currHead = dummy;
            
            while (true)
            {
                var currSmallestIndex = 0;
                for (int i = 0; i < lists.Length; i++)
                {
                    if (i == currSmallestIndex || lists[i] == null)
                        continue;
                    if (lists[currSmallestIndex] == null || lists[currSmallestIndex].val > lists[i].val)
                    {
                        currSmallestIndex = i;
                    }
                }

                if (lists[currSmallestIndex] == null)
                {
                    break;
                }
                else
                {
                    currHead.next = lists[currSmallestIndex];
                    lists[currSmallestIndex] = lists[currSmallestIndex].next;
                    currHead = currHead.next;
                    currHead.next = null;
                }
            }

            return dummy.next;
        }



        // Using MergeTwoLists()
        public ListNode MergeKLists2(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            for (int i = lists.Length - 1; i >= 1; i--)
            {
                lists[i - 1] = MergeTwoLists(lists[i], lists[i - 1]);
            }

            return lists[0];
        }

        private ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;

            var dummy = new ListNode(0);
            var currHead = dummy;

            while (l1 != null || l2 != null)
            {
                if (l1 == null)
                {
                    currHead.next = l2;
                    l2 = l2.next;
                }
                else if (l2 == null)
                {
                    currHead.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    if (l1.val < l2.val)
                    {
                        currHead.next = l1;
                        l1 = l1.next;
                    }
                    else
                    {
                        currHead.next = l2;
                        l2 = l2.next;
                    }
                }
                currHead = currHead.next;
                currHead.next = null;
            }

            return dummy.next;
        }



        // Merge K Lists with PriorityQueue
        public ListNode MergeKListsWithPQ(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            // Beware of using SortedSet in absense of PQ, because SortedSet doesn't support duplicate entry,
            // need to add a index to form a Tuple to use, and PUT THE INDEX IN COMPARISON as well to avoid equal comparison result
            var priorityQueue = new SortedSet<Tuple<int, ListNode>>(Comparer<Tuple<int, ListNode>>.Create(
                (a, b) => { if (a.Item2.val.CompareTo(b.Item2.val) != 0) return a.Item2.val.CompareTo(b.Item2.val); else return a.Item1.CompareTo(b.Item1); }));

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    priorityQueue.Add(new Tuple<int, ListNode>(i, lists[i]));
                    lists[i] = lists[i].next;
                }
            }
            var dummy = new ListNode(0);
            var currHead = dummy;

            while (priorityQueue.Count > 0)
            {
                var currNode = priorityQueue.Min;
                var index = currNode.Item1;
                priorityQueue.Remove(currNode);
                if (lists[index] != null)
                {
                    priorityQueue.Add(new Tuple<int, ListNode>(index, lists[index]));
                    lists[index] = lists[index].next;
                }

                currHead.next = currNode.Item2;
                currHead = currHead.next;
            }

            return dummy.next;
        }


        // Merge K Lists with my own PriorityQueue
        public ListNode MergeKListsWithPQ2(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            var priorityQueue = new PriorityQueue<ListNode>(Comparer<ListNode>.Create((a, b) => a.val.CompareTo(b.val)));

            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                    priorityQueue.Push(lists[i]);
            }

            var dummy = new ListNode(0);
            var currHead = dummy;

            while (priorityQueue.Count > 0)
            {
                var currNode = priorityQueue.Pop();
                currHead.next = currNode;
                currHead = currHead.next;

                if (currNode.next != null)
                {
                    var nextNode = currNode.next;
                    currNode.next = null;
                    priorityQueue.Push(nextNode);
                }
            }

            return dummy.next;
        }
    }
}
