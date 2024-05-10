using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD {
    internal class LPT {
        int totalTime;

        public void LptAlgorithm(List<Task> problemTasks, Machine machine1, Machine machine2) {

            IEnumerable<Task> orderedTasks;
            orderedTasks = problemTasks.OrderByDescending(problemTasks => problemTasks.processingTime).ToList();

            foreach (Task task in orderedTasks) {
                if (machine1.totalTime < machine2.totalTime) {
                    machine1.tasks.Add(task);
                    machine1.totalTime += task.processingTime;
                } else {
                    machine2.tasks.Add(task);
                    machine2.totalTime += task.processingTime;
                }
            }
            totalTime = Math.Max(machine1.totalTime, machine2.totalTime);
        }
        
    }
}
