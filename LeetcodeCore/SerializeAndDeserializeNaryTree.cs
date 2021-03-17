using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SerializeAndDeserializeNaryTree
    {
        // 428. Serialize and Deserialize N-ary Tree
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        public class Codec
        {
            // Encodes a tree to a single string.
            public string serialize(Node root)
            {
                if (root == null)
                    return null;
                var queue = new Queue<Node>();
                var stringBuilder = new StringBuilder();

                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    var currLevelCount = queue.Count;
                    for (int i = 1; i <= currLevelCount; i++)
                    {
                        var node = queue.Dequeue();
                        if (node == null)
                        {
                            stringBuilder.Append("null|");
                        }
                        else
                        {
                            stringBuilder.Append($"{node.val}|");
                            foreach (var cn in node.children)
                            {
                                queue.Enqueue(cn);
                            }
                            queue.Enqueue(null);
                        }
                    }
                }
                return stringBuilder.ToString();
            }

            // Decodes your encoded data to tree.
            public Node deserialize(string data)
            {
                if (data == null)
                    return null;
                var stringArr = data.Split('|', StringSplitOptions.RemoveEmptyEntries);
                var currArrIndex = 0;
                var nodesQueue = new Queue<Node>();
                var root = new Node(int.Parse(stringArr[currArrIndex]), new List<Node>());
                nodesQueue.Enqueue(root);
                currArrIndex++;

                var currNode = nodesQueue.Dequeue();
                for (currArrIndex+=0; currArrIndex < stringArr.Length - 1; currArrIndex++)
                {
                    if (stringArr[currArrIndex] != "null")
                    {
                        var newNode = new Node(int.Parse(stringArr[currArrIndex]), new List<Node>());
                        currNode.children.Add(newNode);
                        nodesQueue.Enqueue(newNode);
                    }
                    else
                    {
                        currNode = nodesQueue.Dequeue();
                    }
                }
                return root;
            }
        }
    }
}
