package org.example;

import java.util.ArrayList;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        Problem problem = new Problem();
        problem.loadTasksFromFile("dane10.txt");
        Solution solution = new Solution();
        /*for (Task task : problem.getTaskList()) {
            System.out.println(task);
        }*/

        long startTime = System.nanoTime();

//        Bruteforce bruteforce = new Bruteforce(problem.getTaskList());
//        solution = bruteforce.BruteforceAlgorithm();

//        NEH neh = new NEH(problem.getTaskList());
//        solution = neh.NEHAlgorithm();

//        Dzonson dzon = new Dzonson(problem.getTaskList());
//        solution = dzon.DzonsonAlgorithm();

        TabuSearch tabuSearch = new TabuSearch(problem.getTaskList());
        List<Task> newList = new ArrayList<Task>();
        solution = tabuSearch.TabuSearchAlgorithm();

        long endTime = System.nanoTime();
        long duration = (endTime - startTime)/ 1000000;
        System.out.println("Czas wykonania funkcji: " + duration + " minisekundy");

        System.out.println(solution.toString());
    }
}