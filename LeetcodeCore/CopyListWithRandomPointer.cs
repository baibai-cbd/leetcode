using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class CopyListWithRandomPointer
    {
        // 138. Copy List with Random Pointer
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            var dictOriginal = new Dictionary<Node, int>();
            var dictNew = new Dictionary<int, Node>();

            Node lastNewNode = null;
            var currNode = head;
            var index = 0;
            while (currNode != null)
            {
                dictOriginal.Add(currNode, index);
                var newNode = new Node(currNode.val);
                dictNew.Add(index, newNode);
                if (lastNewNode != null)
                    lastNewNode.next = newNode;
                lastNewNode = newNode;
                currNode = currNode.next;
                index++;
            }

            currNode = head;
            index = 0;
            while (currNode != null)
            {
                if (currNode.random != null)
                {
                    var newNode = dictNew.GetValueOrDefault(index);

                    if (dictOriginal.TryGetValue(currNode.random, out int index2))
                    {
                        var newNodeRandom = dictNew.GetValueOrDefault(index2);
                        newNode.random = newNodeRandom;
                    }
                }
                index++;
                currNode = currNode.next;
            }

            return dictNew.GetValueOrDefault(0);
        }
    }

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
}
