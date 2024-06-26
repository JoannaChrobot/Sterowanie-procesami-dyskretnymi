package org.example;

import java.util.ArrayList;
import java.util.List;

public class TabuSearch {
    List<Task> permutationStar = new ArrayList<>();
    List<Task> permutationApostrophe = new ArrayList<>();
    List<Task> permutationInit = new ArrayList<>();
    List<List<Task>> tabuList = new ArrayList<>();
    List<List<Task>> neighbours = new ArrayList<>();
    Integer bestCandidateFitness;
    final int maxTabuSize = 100; // Assuming a maximum tabu list size

    public TabuSearch(List<Task> _permutation) {
        permutationApostrophe.addAll(_permutation);
        permutationInit.addAll(_permutation);
        permutationStar.addAll(_permutation);
        tabuList.add(new ArrayList<>(_permutation)); // Ensure initial permutation is copied correctly
    }

    public Solution TabuSearchAlgorithm() {
        Solution solution = new Solution();
        Integer currentCandidateFitness = 0;
        for (int i = 0; i < 100000; ++i) {
            GetNeighbours(permutationApostrophe);
            bestCandidateFitness = Integer.MAX_VALUE;
            List<Task> bestCandidate = null;
            for (List<Task> neighbour : neighbours) {
                currentCandidateFitness = solution.getPermutationTime(neighbour, 3);
                if (!isInTabuList(neighbour) && currentCandidateFitness < bestCandidateFitness) {
                    bestCandidateFitness = currentCandidateFitness;
                    bestCandidate = neighbour;
                }
            }
            if (bestCandidateFitness == Integer.MAX_VALUE) {
                break;
            }
            permutationApostrophe = new ArrayList<>(bestCandidate);
            if (bestCandidateFitness < solution.getPermutationTime(permutationStar, 3)) {
                permutationStar = new ArrayList<>(permutationApostrophe);
            }
            tabuList.add(new ArrayList<>(permutationApostrophe));
            if (tabuList.size() > maxTabuSize) { // Remove the oldest element if the tabu list is too large
                tabuList.remove(0);
            }
            solution.bestPermutation = permutationStar;
            solution.bestTime = solution.getPermutationTime(permutationStar, 3);
        }
        return solution;
    }

    private boolean isInTabuList(List<Task> candidate) {
        for (List<Task> tabuElement : tabuList) {
            if (tabuElement.equals(candidate)) {
                return true;
            }
        }
        return false;
    }

    public void GetNeighbours(List<Task> permutation) {
        Neighbourhood neighbourhood = new Neighbourhood();
        neighbours.clear();
        for (int i = 0; i < permutation.size() - 1; ++i) {
            neighbours.add(new ArrayList<>(neighbourhood.SwapPrzylegle(permutation, i)));
        }
        for (int i = 1; i < permutation.size() - 1; ++i) {
            neighbours.add(new ArrayList<>(neighbourhood.Swap(permutation, 0, i)));
        }
        for (int i = 0; i < permutation.size() - 1; ++i) {
            neighbours.add(new ArrayList<>(neighbourhood.Swap(permutation, i, permutation.size() - 1)));
        }
        for (int i = 0; i < 3; ++i) {
            neighbours.add(new ArrayList<>(neighbourhood.Invert(permutation, 0, permutation.size() - 1)));
            neighbours.add(new ArrayList<>(neighbourhood.Invert(permutation, 0, (permutation.size() - 1) / 2)));
            neighbours.add(new ArrayList<>(neighbourhood.Invert(permutation, (permutation.size() - 1) / 2, permutation.size() - 1)));
        }
    }
}
