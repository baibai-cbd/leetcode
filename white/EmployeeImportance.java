package com.white;

import java.util.ArrayList;
import java.util.List;

public class EmployeeImportance {

    // problem 690

    public static int getImportance(List<Employee> employees, int id) {
        Employee e = employees.get(id-1);
        List<Employee> sList = new ArrayList<>();
        sList.add(e);
        getSubordinatesList(employees,sList,e);
        int sum = 0;
        for (Employee eFound: sList) {
            sum += eFound.importance;
        }
        return sum;
    }

    private static void getSubordinatesList(List<Employee> employees,List<Employee> sList,Employee e) {
        if (e.subordinates == null) {
            return;
        } else {
            for (int i: e.subordinates) {
                sList.add(employees.get(i-1));
                getSubordinatesList(employees,sList,employees.get(i-1));
            }
        }
    }

    static class Employee {
        // It's the unique id of each node;
        // unique id of this employee
        public int id;
        // the importance value of this employee
        public int importance;
        // the id of direct subordinates
        public List<Integer> subordinates;
    }
}
