using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class ConvertSortedLinkedListToBST
    {
        // 109. Convert Sorted List to Binary Search Tree
        public TreeNode SortedListToBST(ListNode head)
        {
            if (head == null)
                return null;
            if (head.next == null)
                return new TreeNode(head.val);

            var node1 = head;
            var preMid = new ListNode(0);
            preMid.next = node1;
            var node2 = head;
            while (node2.next != null && node2.next.next != null)
            {
                node1 = node1.next;
                preMid = preMid.next;
                node2 = node2.next.next;
            }
            preMid.next = null;
            var postMid = node1.next;
            node1.next = null;
            var treeNode1 = new TreeNode(node1.val);
            treeNode1.left = head == node1 ? null : SortedListToBST(head);
            treeNode1.right = postMid == null ? null : SortedListToBST(postMid);
            return treeNode1;
        }
    }
}
