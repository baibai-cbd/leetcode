using System;
using System.Collections.Generic;
using System.Text;

namespace LeetcodeCore
{
    public class SerializeAndDeserializeBinaryTree
    {
        // 297. Serialize and Deserialize Binary Tree
        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            var sb = new StringBuilder("[");
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node == null)
                {
                    sb.Append("null,");
                }
                else
                {
                    sb.Append($"{node.val},");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }

            var temp = sb.ToString();
            while (temp.EndsWith("null,"))
            {
                temp = temp.Remove(temp.Length - 5);
            }

            return temp.Remove(temp.Length - 1) + "]";
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (data.Length <= 2)
                return null;
            var trimmed = data.Substring(1, data.Length - 2);
            var nodes = trimmed.Split(',');
            
            var queue = new Queue<TreeNode>();
            var index = 0;
            var root = ConstructTreeNode(nodes[index]);
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                if (currNode != null)
                {
                    index++;
                    if (index < nodes.Length)
                    {
                        currNode.left = ConstructTreeNode(nodes[index]);
                        queue.Enqueue(currNode.left);
                    }
                    else
                    {
                        break;
                    }
                    index++;
                    if (index < nodes.Length)
                    {
                        currNode.right = ConstructTreeNode(nodes[index]);
                        queue.Enqueue(currNode.right);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return root;
        }

        private TreeNode ConstructTreeNode(string s) => s == "null" ? null : new TreeNode(int.Parse(s));
    }
}
