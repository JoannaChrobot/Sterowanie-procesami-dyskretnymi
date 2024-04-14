#include "Problem.h"

void Problem::loadInput() {

	std::ifstream file;
	file.open("testing_data/SCHRAGE1.DAT");

	file >> this->nrOfTasks;

	Task task;
	int pom = 0;

	for (int i = 0; i < this->nrOfTasks; i++) {
		file >> pom;
		task.setReadyTime(pom);
		file >> pom;
		task.setProcessingTime(pom);
		file >> pom;
		task.setQlingTime(pom);

		this->taskList.push_back(task);
	}
}

//Solution Problem::Brutforce() {
//	//return 22;
//}