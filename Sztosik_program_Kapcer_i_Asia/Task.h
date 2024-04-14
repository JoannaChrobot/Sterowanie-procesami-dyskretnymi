#pragma once
class Task
{
	int ID;
	int readyTime;
	int processingTime;
	int qlingTime;
	int remainingTime;
	double priority;

public:

	Task(){}

	Task(int id, int rd, int p, int q, int rm) {
		 ID = id;
		 readyTime = rd;
		 processingTime = p;
		 qlingTime = q;
		 remainingTime = rm;
	}

	//void getTask() {}
	void setID(int arg) { this->ID = arg; }
	void setReadyTime(int arg) { this->readyTime = arg; }
	void setProcessingTime(int arg) { this->processingTime = arg; }
	void setQlingTime(int arg) { this->qlingTime = arg; }
	void setRemainingTime(int arg) { this->remainingTime = arg; }
	void setPriority(double prio) { this->priority = prio; }

	int getID() const { return this->ID; }
	int getReadyTime() const { return this->readyTime; }
	int getProcessingTime() const { return this->processingTime; }
	int getQlingTime() const { return this->qlingTime; }
	int getRemainingTime() const { return this->remainingTime; }
	double getPriority() const { return this->priority; }
};



