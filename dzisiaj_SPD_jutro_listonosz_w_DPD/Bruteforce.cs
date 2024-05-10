using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD {
    internal class Bruteforce {

        private int nMachines = 2;

        private List<short> combinations;
        private int time;
        private List<short> bestCombination;
        private int bestTime;

        public Bruteforce() {
            combinations = new List<short>();
            bestCombination = new List<short>();
            bestTime = int.MaxValue;
        }

        public void BruteforceAlgorithm(List<Task> problemTasks, Machine machine1, Machine machine2) {

            for (int i = 0; i < problemTasks.Count; i++) {
                combinations.Add(1);
            }

            for (int i = 0; i < Math.Pow(2, problemTasks.Count) / 2; i++) {
                
                calculateCombinationTime(problemTasks, machine1, machine2);
                if (time < bestTime) {
                    bestTime = time;
                    bestCombination = combinations.ToList();
                }
                incrementCombination();
            }
            getResult(problemTasks, machine1, machine2);
            printBestCombination();

        }

        public void incrementCombination() {
            if (combinations.Count > 0) {
                combinations[0]++;
                for (int i = 0; i < combinations.Count; i++) {
                    if (combinations[i] > nMachines) {
                        combinations[(i + 1) % combinations.Count]++;
                        combinations[i] = 1;
                    }
                }
            }
        }
        public void calculateCombinationTime(List<Task> problemTasks, Machine machine1, Machine machine2) {
            machine1.tasks.Clear();
            machine2.tasks.Clear();
            machine1.totalTime = 0;
            machine2.totalTime = 0;
            for (int i = 0; i < combinations.Count; ++i) {
                if (combinations[i] == 1) {
                    machine1.tasks.Add(problemTasks[i]);
                    machine1.totalTime += problemTasks[i].processingTime;
                } else if (combinations[i] == 2) {
                    machine2.tasks.Add(problemTasks[i]);
                    machine2.totalTime += problemTasks[i].processingTime;
                } else {
                    Console.WriteLine("Something's wrong!");
                }
            }
            time = Math.Max(machine1.totalTime, machine2.totalTime);
        }

        public void printCombination() {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("Current combination: (");
            foreach (short combination in combinations) {
                sb.Append(combination + " ");
            }
            sb.Append(")\n");
            sb.AppendLine("Time: " + time);
            Console.WriteLine(sb.ToString());
        }

        public void printBestCombination() {
            StringBuilder sb = new StringBuilder();
            sb.Clear();
            sb.Append("Best combination: (");
            foreach (short combination in bestCombination) {
                sb.Append(combination + " ");
            }
            sb.Append(")\n");
            sb.AppendLine("Time: " + time);
            Console.WriteLine(sb.ToString());
        }

        public void getResult(List<Task> problemTasks, Machine machine1, Machine machine2) {
            machine1.tasks.Clear();
            machine2.tasks.Clear();
            machine1.totalTime = 0;
            machine2.totalTime = 0;
            for (int i = 0; i < bestCombination.Count; ++i) {
                if (bestCombination[i] == 1) {
                    machine1.tasks.Add(problemTasks[i]);
                    machine1.totalTime += problemTasks[i].processingTime;
                } else if (bestCombination[i] == 2) {
                    machine2.tasks.Add(problemTasks[i]);
                    machine2.totalTime += problemTasks[i].processingTime;
                } else {
                    Console.WriteLine("Something's wrong!");
                }
            }
        }
        
        public string Wypisz(Machine machine1, Machine machine2) {

            StringBuilder result = new StringBuilder();

            result.Append(machine1.ToString());
            result.Append(machine2.ToString());

            result.AppendLine("Total machining time: " + bestTime);
            result.AppendLine();

            return result.ToString();
        }
        
    }
}


