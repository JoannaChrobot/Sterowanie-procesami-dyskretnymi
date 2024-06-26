package org.example;

import java.util.ArrayList;
import java.util.List;

public class FNEH{
    public List<FNehTask> taskList = new ArrayList<FNehTask>();
    public FNEH(List<FNehTask> _taskList){
        taskList = _taskList;
    }
    private void SortByTimeSum(){
        taskList.sort((o1, o2) -> ((o1.t1 + o1.t2 + o1.t3) - (o2.t1 + o2.t2 + o2.t3)));
    }

    public Solution FNEHAlgorithm(){
        Solution solution = new Solution();
        List<FNehTask> taskListStar = new ArrayList<>();
        SortByTimeSum();

        // taskListStar.add(taskList.getFirst());
        // taskList.remove(taskList.getFirst());

        int time;
        int tempBestTime;
        int bestPosition;
        for (FNehTask task : taskList) {
            bestPosition = -1;
            tempBestTime = Integer.MAX_VALUE;
            for (int j = 0; j <= taskListStar.size(); j++) {
                taskListStar.add(j, task);
                time = solution.getPermutationTimeForFNEH(taskListStar, 3);
                if(time < tempBestTime){
                    tempBestTime = time;
                    bestPosition = j;
                }
                taskListStar.remove(j);
            }

            taskListStar.add(bestPosition, task);
        }
        solution.bestTime = solution.getPermutationTimeForFNEH(taskListStar, 3);
        solution.bestPermutationFNeh = taskListStar;

        return solution;
    }
}
