package com.white;

import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) {
	// write your code here
        // problem 461
//        System.out.println(HammingDistance.hammingDistance(0xff,1));

        // problem 657
//        System.out.println(JudgeRouteCircle.judgeCircle("U"));

        // problem 617
//        TreeNode t11 = new TreeNode(1);
//        TreeNode t12 = new TreeNode(2);
//        TreeNode t13 = new TreeNode(3);
//        TreeNode t15 = new TreeNode(5);
//        TreeNode t22 = new TreeNode(2);
//        TreeNode t21 = new TreeNode(1);
//        TreeNode t23 = new TreeNode(3);
//        TreeNode t24 = new TreeNode(4);
//        TreeNode t27 = new TreeNode(7);
//        t11.left = t13;
//        t11.right = t12;
//        t13.left = t15;
//        t22.left = t21;
//        t22.right = t23;
//        t21.right = t24;
//        t23.right = t27;
//
//        TreeNode t1 = TreeNode.mergeTrees(t11,t22);
//        System.out.println(t1.val);
//        System.out.println(t1.left.val);
//        System.out.println(t1.left.left.val);
//        System.out.println(t1.left.right.val);
//        System.out.println(t1.right.val);
//        System.out.println(t1.right.right.val);
//
//        TreeNode t11 = new TreeNode(1);
//        TreeNode t22 = new TreeNode(2);
//        TreeNode t1 = TreeNode.mergeTrees(t11,null);
//        System.out.println(t1.val);

//        System.out.println(NumberComplement.findComplement(1));
//        System.out.println(NumberComplement.findComplement(2));
//        System.out.println(NumberComplement.findComplement(3));
//        System.out.println(NumberComplement.findComplement(4));
//        System.out.println(NumberComplement.findComplement(5));
//        System.out.println(NumberComplement.findComplement(6));
//        System.out.println(NumberComplement.findComplement(100));

//        String[] strings = {"Hello", "Alaska", "Dad", "Peace","bmn","poi","plm"};
////        System.out.println(strings[1] + strings[2]);
//        String[] outputStrings = KeyboardRow.findWords(strings);
//        System.out.println(outputStrings.length);
//        System.out.println(outputStrings[0]+" "+outputStrings[1]+" "+outputStrings[2]+" "+outputStrings[3]);


//        String s = "asdfghjkl";
//        System.out.println(ReverseString.reverseString2(s));
//
//        String ss = "Let's take LeetCode contest";
//        System.out.println(ReverseWordsInAStringIII.reverseWords(ss));



        // problem 575 distribute candies
//        int[] a = {1,3,4,5,6,7,8,9,0,11,22,11};
//        int[] b = {1,1,1,1,7,7,7,7,0,11,11,11};
//
//        System.out.println(DistributeCandies.distributeCandies(b));


        // problem 566 reshape the matrix
//        int[][] a = {{1,2},{3,4}};
//        int[][] b = ReshapeTheMatrix.matrixReshape(a,2,4);
//        System.out.println(Arrays.toString(b[0]));

        // problem 412
//        int n = 30;
//        System.out.println(FizzBuzz.fizzBuzz(n));


        // problem 690

        // problem 463
//        int[][] a = {{0,1,0,0},{0,0,1,0}};
//        System.out.println(IslandPerimeter.islandPerimeter(a));

//        //// problem 496
//        int[] nums1 = {2,4};
//        int[] nums2 = {1,2,3,4};
//        System.out.println(Arrays.toString(NextGreaterElementI.nextGreaterElement(nums1,nums2)));

        // problem 485
//        int[] a = {1,1,0,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,1};
//        System.out.println(MaxConsecutiveOnes.findMaxConsecutiveOnes(a));

        // problem 695
//        int[][] exp1 = {{0,0,1,0,0,0,0,1,0,0,0,0,0},
//                        {0,0,0,0,0,0,0,1,1,1,0,0,0},
//                        {0,1,1,0,1,0,0,0,0,0,0,0,0},
//                        {0,1,0,0,1,1,0,0,1,0,1,0,0},
//                        {0,1,0,0,1,1,0,0,1,1,1,0,0},
//                        {0,0,0,0,0,0,0,0,0,0,1,0,0},
//                        {0,0,0,0,0,0,0,1,1,1,0,0,0},
//                        {0,0,0,0,0,0,0,1,1,0,0,0,0}};
//
//        int[][] exp2 = {{0,0,0,0,1,1,0,0}};
//
//        System.out.println(MaxAreaOfIsland.maxAreaOfIsland(exp2));
//
//        System.out.println(BinaryNumberWithAlternatingBits.hasAlternatingBits(4));
//        System.out.println(BinaryNumberWithAlternatingBits.hasAlternatingBits(5));
//        System.out.println(BinaryNumberWithAlternatingBits.hasAlternatingBits(7));
//        System.out.println(BinaryNumberWithAlternatingBits.hasAlternatingBits(11));
//        System.out.println(BinaryNumberWithAlternatingBits.hasAlternatingBits(10));

//        // problem 520
//        System.out.println(DetectCapital.detectCapitalUse("USA"));
//        System.out.println(DetectCapital.detectCapitalUse("leetcode"));
//        System.out.println(DetectCapital.detectCapitalUse("FlaG"));

//        TreeMap<String,Integer> tm = new TreeMap<>();
//        tm.put("a",5);
//        tm.put("t",3);
//        HashMap<String,Integer> hm = tm;
//        location(tm);
//        RandomClassExample c1 = new RandomClassExample("white",20);
//        RandomClassExample c2 = new RandomClassExample("white",20);
//
//        System.out.println(c1 == c2);

         TreeNode root = new TreeNode(1);
         TreeNode t1 = new TreeNode(2);
         TreeNode t2 = new TreeNode(3);
         TreeNode t3 = new TreeNode(4);
         TreeNode t4 = new TreeNode(5);
         root.left = t1;
         root.right = t2;
         t1.left = t3;
         t1.right = t4;
//
//        MinimumAbsoluteDifferenceinBST min = new MinimumAbsoluteDifferenceinBST();
//        int a = min.getMinimumDifference(root);
//
//        System.out.println(a);

//        String s = "able0000";
//        System.out.println(ToLowerCase.toLowerCase(s));

//        int[][] grid = {{2}};
//
//        int i = SurfaceArea3DShapes.surfaceArea(grid);
//
//        System.out.println(i);

//        List<Double> arrayList = AverageOfLevelsInBinaryTree.averageOfLevels(root);
//        for (Double d: arrayList) {
//            System.out.println(d.doubleValue());
//        }

//        String[] words = {"gin","zen","gig","msg"};
//
//        int i = UniqueMorseCodeWords.uniqueMorseRepresentations(words);
//        System.out.println(i);

//        int[][] input = {{1,1,0,0},{1,0,0,1},{0,1,1,1},{1,0,1,0}};
//
//        int[][] result = FlippingAnImage.flipAndInvertImage(input);
//
//        for (int[] a: result) {
//            System.out.println(Arrays.toString(a));
//        }

//        ListNode l1 = new ListNode(2);
//        ListNode l2 = new ListNode(4);
//        ListNode l3 = new ListNode(3);
//        ListNode l4 = new ListNode(5);
//        ListNode l5 = new ListNode(6);
//        ListNode l6 = new ListNode(4);
//        l1.next = l2;
//        l2.next = l3;
//        l4.next = l5;
//        l5.next = l6;
//
//        ListNode r = AddTwoNumbers.addTwoNumbers(l1,l4);
//        while (r.next!=null) {
//            System.out.println(r.val);
//            r = r.next;
//        }
//        System.out.println(r.val);

//        int i = LongestSubStringWithoutRepeatingCharacters.lengthOfLongestSubstring("");
//        System.out.println(i);
        //

//        int[] nums2 = {2};
//        int[] nums1 = {1,3};
//        double s = MedianOfTwoSortedArrays.findMedianSortedArrays(nums1,nums2);
//        System.out.println(s);

        // String t = "PAYPALISHIRING";
        // System.out.println(ZigzagConversion.convert(t, 3));

//        int a = -3643;
//        int b = 0;
//        int c = 1234;
//        int d = 2147000647;
//        System.out.println(ReverseInteger.reverse(a));
//        System.out.println(ReverseInteger.reverse(b));
//        System.out.println(ReverseInteger.reverse(c));
//        System.out.println(ReverseInteger.reverse(d));
    	
    	ListNode a1 = new ListNode(1);
//    	ListNode a2 = new ListNode(1);
    	ListNode a3 = new ListNode(3);
    	ListNode a4 = new ListNode(4);
    	ListNode a5 = new ListNode(5);
//    	ListNode a6 = new ListNode(4);
    	ListNode a7 = new ListNode(7);
    	ListNode a8 = new ListNode(8);
    	
    	a1.next = a3; 
    	a3.next = a4;
    	a4.next = a5;
    	a5.next = a7;
    	a7.next = a8;
    	//
    	a8.next = a8;
    	
//    	ListNode[] nodes = {a1, a2, a3};
    	
//    	ListNode result = RemoveNthNodeFromEndOfList.removeNthFromEnd(a1, 1);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = MergeKSortedLists.mergeKLists(nodes);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = ReverseNodesInKGroup.reverseKGroup(a1, 5);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = RotateList.rotateRight(a1, 10);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = RemoveDuplicatesFromSortedListII.deleteDuplicates(a1);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = RemoveDuplicatesFromSortedList.deleteDuplicates(a1);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = PartitionList.partition(a1,1);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = ReverseLinkedListII.reverseBetween(a8, 1, 2);
//    	ListNode.printListNode(result);
    	
//    	ListNode result = LinkedListCycleII.detectCycle(a1);
//    	System.out.println(result.val);
    	
    	List<Integer> result = BinaryTreeInorderTraversal.inorderTraversal(root);
    	System.out.println(result.toString());
    }
}
