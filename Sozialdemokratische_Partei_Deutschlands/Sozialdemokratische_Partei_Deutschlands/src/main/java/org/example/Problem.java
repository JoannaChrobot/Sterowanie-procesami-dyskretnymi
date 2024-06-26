package org.example;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Problem {
    private List<Task> taskList;
    private Integer totalTime;

    public Problem() {
        taskList = new ArrayList<Task>();
    }

    public void loadTasksFromFile(String filename) {
        try (BufferedReader br = new BufferedReader(new InputStreamReader(
                getClass().getClassLoader().getResourceAsStream(filename)))) {
            if (br == null) {
                throw new IOException("File not found: " + filename);
            }
            String line;
            int ID = 1;
            while ((line = br.readLine()) != null) {
                String[] parts = line.split(" ");
                if (parts.length == 3) {
                    Integer t1 = Integer.parseInt(parts[0]);
                    Integer t2 = Integer.parseInt(parts[1]);
                    Integer t3 = Integer.parseInt(parts[2]);
                    taskList.add(new Task(ID++, t1, t2, t3));
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public List<Task> getTaskList() {
        return taskList;
    }


}
