package org.example;

import java.util.ArrayList;
import java.util.List;

public class Bruteforce {
    private List<List<Task>> permutations;

    public Bruteforce(List<Task> taskList) {
        permutations = new ArrayList<>();
        generatePermutations(new ArrayList<>(), taskList);
    }
    private void generatePermutations(List<Task> current, List<Task> remaining) {
        if (remaining.isEmpty()) {
            permutations.add(new ArrayList<>(current));
        } else {
            for (int i = 0; i < remaining.size(); i++) {
                List<Task> newRemaining = new ArrayList<>(remaining);
                List<Task> newCurrent = new ArrayList<>(current);
                newCurrent.add(newRemaining.remove(i));
                generatePermutations(newCurrent, newRemaining);
            }
        }
    }
    public Solution BruteforceAlgorithm(){
        Solution solution = new Solution();
        int time;
        for (List<Task> perm : permutations) {
            time = solution.getPermutationTime(perm, 3);
            if(time < solution.bestTime){
                solution.bestTime = time;
                solution.bestPermutation = perm.stream().toList();
            }
        }
        return solution;
    }

    public int GetPermutationCount(){
        return permutations.size();
    }
}
