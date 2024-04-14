#pragma once
#include "Task.h"
#include "Solution.h"

#include <vector>
#include <fstream>
#include <algorithm>
#include <utility>

#include <queue>

class Problem
{
public:
	std::vector<Task> taskList;

	int nrOfTasks = 0;
	int totalTime = 0;


	void loadInput();
	Solution Brutforce();
	Solution Heuresticforce();
	int CalculateTotalTime(Solution currentSolution);
	Solution HeuresticforceByReadyTime();
	Solution HeuresticforceByQlingTime();
	Solution Shreka();
	Solution ShrekaWithTaskDivision();
	Solution ConstructionAlgorithm_PrioritySort();
	Solution Carliera();
	int MaxB(Solution sol);
};


void Problem::loadInput() {

	std::ifstream file;
	file.open("testing_data/SCHRAGE1.DAT");

	file >> this->nrOfTasks;

	Task task;
	int pom = 0;

	for (int i = 0; i < this->nrOfTasks; i++) {
		task.setID(i);
		file >> pom;
		task.setReadyTime(pom);
		file >> pom;
		task.setProcessingTime(pom);
		task.setRemainingTime(pom);
		file >> pom;
		task.setQlingTime(pom);
		
		this->taskList.push_back(task);
	}
}

int Problem::CalculateTotalTime(Solution currentSolution) {

	int startTime = 0;
	int endTime = 0;
	int maxQlingTime = 0;
	for (int i : currentSolution.taskOrder) {
		startTime = std::max(endTime, taskList[i].getReadyTime());
		endTime = startTime + taskList[i].getRemainingTime();
		maxQlingTime = std::max(maxQlingTime, endTime + taskList[i].getQlingTime());
	}

	return maxQlingTime;
}

Solution Problem::HeuresticforceByReadyTime() {
	Solution solution;

	std::sort(taskList.begin(), taskList.end(), [](Task& lhs, Task& rhs) {
		return lhs.getReadyTime() < rhs.getReadyTime();
	});

	for (int i = 0; i < nrOfTasks; ++i) {
		solution.taskOrder.push_back(taskList[i].getID());
	}

	solution.setTotalTime(CalculateTotalTime(solution));

	return solution;
}

Solution Problem::HeuresticforceByQlingTime() {
	Solution solution;

	std::sort(taskList.begin(), taskList.end(), [](Task& lhs, Task& rhs) {
		return lhs.getQlingTime() > rhs.getQlingTime();
	});

	for (int i = 0; i < nrOfTasks; ++i) {
		solution.taskOrder.push_back(taskList[i].getID());
	}

	solution.setTotalTime(CalculateTotalTime(solution));

	return solution;
}

Solution Problem::Brutforce() {
	Solution currentSolution;
	Solution bestSolution;

	for (int i = 0; i < nrOfTasks; ++i) {
		currentSolution.taskOrder.push_back(i);
	}

	do {
		int totalTime = CalculateTotalTime(currentSolution);

		currentSolution.setTotalTime(totalTime);

		if (currentSolution.getTotalTime() < bestSolution.getTotalTime()) {
			bestSolution = currentSolution;
		}

	} while (next_permutation(currentSolution.taskOrder.begin(), currentSolution.taskOrder.end()));
	return bestSolution;
}



struct CompareMinReady {
	bool operator()(Task& t1, Task& t2) {
		// Sortowanie rosnaco na podstawie parametru r
		return t1.getReadyTime() > t2.getReadyTime();
	}
};

struct CompareMaxQling {
	bool operator()(Task& t1, Task& t2) {
		// Sortowanie rosnaco na podstawie parametru r
		return t1.getQlingTime() < t2.getQlingTime();
	}
};

Solution Problem::ShrekaWithTaskDivision() {

	Solution bestSolution;
	int t = 0, k = 0, Cmax=0, q0 = 0x3F3F3F3F;
	Task e; 
	Task l(0,0,0,q0,0);
	std::priority_queue<Task, std::vector<Task>, CompareMinReady> N;
	std::priority_queue<Task, std::vector<Task>, CompareMaxQling> G;

	for (int i = 0; i < taskList.size(); i++) {
		N.push(taskList[i]);
	}

	while (!G.empty() || !N.empty()) {
		while (!N.empty() && N.top().getReadyTime() <= t) {
			e = N.top();
			G.push(e);
			N.pop();
			// l - zadanie obecnie znajdujace sie na maszynie
			// e - zadanie nowo przybyle
			if (e.getQlingTime() > l.getQlingTime()) {
				l.setRemainingTime(t - e.getReadyTime()); // tylko czesc ktora udala sie wykonac przed e
				t = e.getReadyTime();
				
				if (l.getRemainingTime() > 0) {
					G.push(l);
				}
			}
		}

		if (G.empty()) {
			t = N.top().getReadyTime();
			continue;
		}

		e = G.top();
		G.pop();

		l = e;
		bestSolution.taskOrder.push_back(e.getID());
		t += e.getRemainingTime();
		Cmax = std::max(Cmax, t + e.getQlingTime());
	}

	bestSolution.setTotalTime(Cmax);

	return bestSolution;
}


Solution Problem::Shreka() {

	Solution bestSolution;
	int t = 0, k = 0, Cmax = 0;
	Task e;
	std::priority_queue<Task, std::vector<Task>, CompareMinReady> N;
	std::priority_queue<Task, std::vector<Task>, CompareMaxQling> G;

	for (int i = 0; i < taskList.size(); i++) {
		N.push(taskList[i]);
	}

	while (!G.empty() || !N.empty()) {

		std::cout << "Kolejka g\n";
		if(!G.empty()){
			std::cout << G.top().getReadyTime() << std::endl;
			std::cout << G.top().getProcessingTime() << std::endl;
			std::cout << G.top().getQlingTime() << std::endl;
		}



		while (!N.empty() && N.top().getReadyTime() <= t) {
			e = N.top();
			G.push(e);
			N.pop();
		}

		// inicjalizacja kolejki G
		if (G.empty()) {
			t = N.top().getReadyTime();
			continue;
		}

		e = G.top();
		G.pop();

		bestSolution.taskOrder.push_back(e.getID());
		t += e.getProcessingTime();
		Cmax = std::max(Cmax, t + e.getQlingTime());
	}

	bestSolution.setTotalTime(Cmax);

	return bestSolution;
}

Solution Problem::ConstructionAlgorithm_PrioritySort() {

	Solution bestSolution;
	
	for (int i = 0; i < nrOfTasks; i++) {
		double priority = (double)(taskList[i].getQlingTime()*0.2) / ((double)(taskList[i].getReadyTime()*0.5) 
			+ (double)taskList[i].getProcessingTime()*0.9);
		
		taskList[i].setPriority(priority);
	}

	std::sort(taskList.begin(), taskList.end(), [](Task& lhs, Task& rhs) {
		return lhs.getPriority() > rhs.getPriority();
	});

	for (int i = 0; i < nrOfTasks; ++i) {
		bestSolution.taskOrder.push_back(taskList[i].getID());
	}

	bestSolution.setTotalTime(CalculateTotalTime(bestSolution));

	return bestSolution;
}




