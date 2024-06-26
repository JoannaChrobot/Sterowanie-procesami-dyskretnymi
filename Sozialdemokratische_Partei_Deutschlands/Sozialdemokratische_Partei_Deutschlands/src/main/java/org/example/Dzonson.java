package org.example;

import java.lang.invoke.SerializedLambda;
import java.util.ArrayList;
import java.util.List;

public class Dzonson {

    public List<Task> taskList = new ArrayList<Task>();
    public List<Task> JL = new ArrayList<Task>();
    public List<Task> JR = new ArrayList<Task>();
    public Dzonson(List<Task> _taskList){
        taskList = _taskList;
        JR.addAll(_taskList);
        JL.addAll(_taskList);
    }

    private void SortAscendingByP1(){
        JL.sort((o1, o2) -> o1.t1 - o2.t1);
    }

    private void SortDescendingByP2(){
        JR.sort((o1, o2) -> ((o2.t2) - (o1.t2)));
    }

    public Solution DzonsonAlgorithm(){
        Solution solution = new Solution();

        SortAscendingByP1();
        SortDescendingByP2();

        //int size = JL.size();
        while(!JL.isEmpty()){
        //for(int i  = 0; i < size; i++){
            if(JL.getFirst().t1 <= JR.getFirst().t2) {
                int id = JL.getFirst().ID;
                solution.bestPermutation.add(JL.getFirst());
                JR.removeIf(task -> task.ID == id);
                JL.remove(JL.getFirst());

                //JR.re
            }
            else{
                int id = JR.getFirst().ID;
                solution.bestPermutation.add(JR.getFirst());
                JL.removeIf(task -> task.ID == id);
                JR.remove(JR.getFirst());
                //JR.remove(i);
            }
        }

        solution.bestTime = solution.getPermutationTime(solution.bestPermutation, 2);
        //solution.bestPermutation = taskListStar;
        return solution;
    }

}
