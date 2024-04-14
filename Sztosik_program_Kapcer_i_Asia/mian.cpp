#include <iostream>
#include <fstream>
#include <vector>
#include "Problem.h"

std::ostream& operator << (std::ostream& os, std::vector<Task>& taskList) {
	for (int i = 0; i < taskList.size(); i++) {
		os << taskList[i].getID() << "  ";
		os << taskList[i].getReadyTime() << "  ";
		os << taskList[i].getProcessingTime() << "  ";
		os << taskList[i].getQlingTime() << std::endl;
		//os << taskList[i].getPriority() << std::endl;
	}
	return os;
}

std::ostream& operator << (std::ostream& os, Solution solution) {
	os << "Najlepsze rozwiazanie: " << std::endl;
	for (int i = 0; i < solution.taskOrder.size(); i++) {
		os << solution.taskOrder[i] << " ";
	}
	os << std::endl << "Calkowity czas: " << solution.getTotalTime() << std::endl;;
	return os;
}

int main() {

	Problem problem;
	Solution bestSolution;
	problem.loadInput();
	//std::cout << problem.taskList << std::endl;
	//bestSolution = problem.Brutforce();
	//bestSolution = problem.HeuresticforceByReadyTime();
	//bestSolution = problem.HeuresticforceByQlingTime();
	bestSolution = problem.Shreka();
	//bestSolution = problem.ShrekaWithTaskDivision();
	//bestSolution = problem.ConstructionAlgorithm_PrioritySort();
	std::cout << problem.taskList << std::endl;

	//bestSolution = problem.Carliera();
	std::cout << bestSolution << std::endl;
	return 0;
}