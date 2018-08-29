package com.white;

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

public class AverageOfLevelsInBinaryTree {

    // problem 637

    public static List<Double> averageOfLevels(TreeNode root) {
        List<Double> list = new ArrayList<>();

        boolean chooseStack = true;
        Stack<TreeNode> stack1 = new Stack<>();
        Stack<TreeNode> stack2 = new Stack<>();

        stack1.push(root);

        while(!stack1.empty() || !stack2.empty()) {
            if (chooseStack) {
                double sum = 0;
                double count = 0;
                while (!stack1.empty()) {
                    TreeNode t = stack1.pop();
                    if (t.left!=null)
                        stack2.add(t.left);
                    if (t.right!=null)
                        stack2.add(t.right);
                    sum += t.val;
                    count++;
                }
                chooseStack = false;
                list.add((double)sum/count);
            } else {
                double sum = 0;
                double count = 0;
                while (!stack2.empty()) {
                    TreeNode t = stack2.pop();
                    if (t.left!=null)
                        stack1.add(t.left);
                    if (t.right!=null)
                        stack1.add(t.right);
                    sum += t.val;
                    count++;
                }
                chooseStack = true;
                list.add((double)sum/count);
            }
        }

        return list;
    }
}
