using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD
{
    internal class LSA_3M
    {
        int totalTime;

        public void LsaAlgorithm(List<Task> problemTasks, Machine machine1, Machine machine2, Machine machine3)
        {
            foreach (Task task in problemTasks)
            {
                if (machine1.totalTime < machine2.totalTime)
                {
                    if(machine1.totalTime < machine3.totalTime)
                    {
                        machine1.tasks.Add(task);
                        machine1.totalTime += task.processingTime;
                    }
                    else
                    {
                        machine3.tasks.Add(task);
                        machine3.totalTime += task.processingTime;
                    }  
                }
                else 
                {
                    if (machine2.totalTime < machine3.totalTime)
                    {
                        machine2.tasks.Add(task);
                        machine2.totalTime += task.processingTime;
                    }
                    else
                    {
                        machine3.tasks.Add(task);
                        machine3.totalTime += task.processingTime;
                    }
                    
                }
                
            }
            totalTime = Math.Max(machine1.totalTime, machine2.totalTime);
        }
        /*
        public override string ToString() {

            StringBuilder result = new StringBuilder();

            result.Append(machine1.ToString());
            result.Append(machine2.ToString());

            result.AppendLine("Total machining time: " + totalTime);
            result.AppendLine();

            return result.ToString();
        }
        */
    }
}
