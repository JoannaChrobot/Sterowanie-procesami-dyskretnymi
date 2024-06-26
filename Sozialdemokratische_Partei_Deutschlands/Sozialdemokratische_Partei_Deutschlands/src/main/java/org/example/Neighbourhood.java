package org.example;

import java.io.Serial;
import java.util.ArrayList;
import java.util.List;

import static java.util.Collections.swap;

public class Neighbourhood {
    public List<Task> SwapPrzylegle(List<Task> lista, int index){
        List<Task> newList = new ArrayList<>(lista);
        if(index < lista.size()-1){
            Task task = newList.get(index);
            newList.remove(index);
            newList.add(index+1, task);
        }
        else {
            System.out.println("Whoopsy doopsy sth gose wrong...");
        }
        return newList;
    }

    public List<Task> Swap(List<Task> lista, int index1, int index2) {
        List<Task> newList = new ArrayList<>(lista);
        if (index1 < newList.size() && index2 < newList.size()) {
            Task temp = newList.get(index1);
            newList.set(index1, newList.get(index2));
            newList.set(index2, temp);
        } else {
            System.out.println("Whoopsy doopsy sth goes wrong...");
        }
        return newList;
    }

    public List<Task> Invert(List<Task> lista, int index, int index2) {
        List<Task> newList = new ArrayList<>(lista);
        if (index < 0 || index2 >= newList.size() || index >= index2) {
            System.out.println("Whoopsy doopsy sth goes wrong...");

        }
        while (index < index2) {
            newList = Swap(newList, index, index2);
            index++;
            index2--;
        }
        return newList;
    }
}

