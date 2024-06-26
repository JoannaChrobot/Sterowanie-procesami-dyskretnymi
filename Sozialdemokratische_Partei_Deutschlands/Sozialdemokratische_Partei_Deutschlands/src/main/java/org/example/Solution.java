package org.example;

import java.util.ArrayList;
import java.util.List;

public class Solution {
    public List<Task> bestPermutation;
    public List<FNehTask> bestPermutationFNeh;
    public Integer bestTime;

    public Solution(){
        bestPermutation = new ArrayList<>();
        bestTime = Integer.MAX_VALUE;
    }

    public int getPermutationTime(List<Task> permutation, int nMachines){
        Integer[] m1EndTimes = new Integer[permutation.size()];
        Integer[] m2EndTimes = new Integer[permutation.size()];
        Integer[] m3EndTimes = new Integer[permutation.size()];

        m1EndTimes[0] = permutation.get(0).t1;
        for(int  i = 1; i < permutation.size(); i++){
            m1EndTimes[i] = m1EndTimes[i - 1] + permutation.get(i).t1;
        }
        m2EndTimes[0] = m1EndTimes[0] + permutation.get(0).t2;
        for(int  i = 1; i < permutation.size(); i++){
            m2EndTimes[i] = Integer.max(m1EndTimes[i], m2EndTimes[i - 1]) + permutation.get(i).t2;
        }
        m3EndTimes[0] = m2EndTimes[0] + permutation.get(0).t3;
        for(int  i = 1; i < permutation.size(); i++){
            m3EndTimes[i] = Integer.max(m2EndTimes[i], m3EndTimes[i - 1]) + permutation.get(i).t3;
        }

        /*if(m3EndTimes[permutation.size()-1] < bestTime){
            bestTime = m3EndTimes[permutation.size()-1];
            bestPermutation = permutation.stream().toList();
        }*/
        if(nMachines == 2) return m2EndTimes[permutation.size()-1];
        else if(nMachines == 3) return m3EndTimes[permutation.size()-1];
        return -1;
    }


    public int getPermutationTimeForFNEH(List<FNehTask> permutation, int nMachines){
        Integer[] m1EndTimes = new Integer[permutation.size()];
        Integer[] m2EndTimes = new Integer[permutation.size()];
        Integer[] m3EndTimes = new Integer[permutation.size()];

        m1EndTimes[0] = permutation.get(0).t1;
        permutation.get(0).endTime = m1EndTimes[0];
        for(int  i = 1; i < permutation.size(); i++){
            m1EndTimes[i] = m1EndTimes[i - 1] + permutation.get(i).t1;
            permutation.get(i).endTime = m1EndTimes[i];
            System.out.println(permutation.get(i).endTime);
        }


        m2EndTimes[0] = m1EndTimes[0] + permutation.get(0).t2;
        permutation.get(0).endTime = m2EndTimes[0];
        for(int  i = 1; i < permutation.size(); i++){
            m2EndTimes[i] = Integer.max(m1EndTimes[i], m2EndTimes[i - 1]) + permutation.get(i).t2;
            permutation.get(i).endTime = m2EndTimes[i];
        }

        m3EndTimes[0] = m2EndTimes[0] + permutation.get(0).t3;
        permutation.get(0).endTime = m3EndTimes[0];
        for(int  i = 1; i < permutation.size(); i++){
            m3EndTimes[i] = Integer.max(m2EndTimes[i], m3EndTimes[i - 1]) + permutation.get(i).t3;
            permutation.get(i).endTime = m3EndTimes[i];
        }

        /*if(m3EndTimes[permutation.size()-1] < bestTime){
            bestTime = m3EndTimes[permutation.size()-1];
            bestPermutation = permutation.stream().toList();
        }*/
        if(nMachines == 2) return m2EndTimes[permutation.size()-1];
        else if(nMachines == 3) return m3EndTimes[permutation.size()-1];
        return -1;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Best Solution: [");
        for(int i = 0; i < bestPermutation.size(); i++){
            sb.append(bestPermutation.get(i).ID + " ");
        }
        sb.append(" ]\n");
        sb.append("Best Time: " + bestTime + "\n");
        return sb.toString();
    }
}
