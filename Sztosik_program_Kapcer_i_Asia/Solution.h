#pragma once
#include <vector>
#include <utility>


class Solution
{
	int totalTime = 0x3f3f3f3f;
	//int criterion = 0;
public:
	Solution(){}
	Solution(int size);
	~Solution() {}
	std::vector<int> taskOrder;
	int getTotalTime() { return this->totalTime; }
	void setTotalTime(int var) { this->totalTime = var; }	
};

Solution::Solution(int size) {
	taskOrder.resize(size);
}
