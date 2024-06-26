package org.example;

import java.util.Objects;

public class Task {
    public int ID;
    public Integer t1;
    public Integer t2;
    public Integer t3;

    public Task() {
    }

    public Task(int ID, Integer t1, Integer t2, Integer t3) {
        this.ID = ID;
        this.t1 = t1;
        this.t2 = t2;
        this.t3 = t3;
    }

    @Override
    public String toString() {
        return "Task ID: " + ID + ", t1: " + t1 + ", t2: " + t2 + ", t3: " + t3;
    }
    
}
