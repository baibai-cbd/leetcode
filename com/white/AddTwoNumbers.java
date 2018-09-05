package com.white;

public class AddTwoNumbers {

    // problem 2

    public static ListNode addTwoNumbers(ListNode l1, ListNode l2) {

        ListNode result = new ListNode(0);
        ListNode x1 = l1;
        ListNode x2 = l2;
        ListNode temp = result;
        int carry = 0;

        while(x1!=null || x2!=null || carry==1) {
            int sum = 0;
            if (x1!=null) {
                sum += x1.val;
                x1 = x1.next==null ? null : x1.next;
            }
            if (x2!=null) {
                sum += x2.val;
                x2 = x2.next==null ? null : x2.next;
            }
            temp.next = new ListNode(sum+carry);
            temp = temp.next;
            carry = temp.val / 10;
            temp.val = temp.val % 10;
        }

        return result.next;
    }
}
