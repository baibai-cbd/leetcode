package com.white;

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

        TreeNode root = new TreeNode(4);
        //TreeNode t1 = new TreeNode(1);
        TreeNode t2 = new TreeNode(1);
        //TreeNode t3 = new TreeNode(0);
        TreeNode t4 = new TreeNode(3);
        //TreeNode t5 = new TreeNode(7);
        //root.left = t1;
        root.left =t2;
        //t1.left=t3;
        t2.right=t4;
        //t2.right=t5;

        MinimumAbsoluteDifferenceinBST min = new MinimumAbsoluteDifferenceinBST();
        int a = min.getMinimumDifference(root);

        System.out.println(a);
    }

//    public static void location(Map<String,Integer> m) {
//        HashMap<String,Integer> hm = new HashMap<>(m);
//    }


    public static boolean abc(int t) {
        if (t<3) {
            return false;
        } else if (t>3) {
            return true;
        } else {
            return true;
        }
    }



}
