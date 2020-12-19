using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ReverseNodesInKGroup
    {
        // 25. Reverse Nodes in k-Group
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var dummy = new ListNode(0);
            dummy.next = head;

            var nodeA = dummy;
            var nodeB = head;
            while (true)
            {
                var currCount = k-1;
                while (currCount > 0 && nodeB != null)
                {
                    nodeB = nodeB.next;
                    currCount--;
                }

                if (currCount == 0 && nodeB != null)
                {
                    var nodeC = nodeB.next;
                    var results = ReverseGroup(nodeA.next, nodeB);
                    // connect this group with prev and latter nodes
                    nodeA.next = results.Item1;
                    results.Item2.next = nodeC;
                    // set for next group
                    nodeA = results.Item2;
                    nodeB = nodeC;
                }
                else
                {
                    return dummy.next;
                }
            }
        }

        private Tuple<ListNode, ListNode> ReverseGroup(ListNode head, ListNode tail)
        {
            var prev = (ListNode)null;
            var curr = head;
            while (!ReferenceEquals(curr, tail))
            {
                var temp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = temp;
            }
            curr.next = prev;
            return new Tuple<ListNode, ListNode>(tail, head);
        }
    }
}
