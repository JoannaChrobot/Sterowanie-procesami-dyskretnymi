using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD
{
    internal class FPTAS
    {
        public void ArrangeByIndex(List<Task> problemTasks, Machine machine1, Machine machine2)
        {
            List<int> machine1ID = new List<int>();
            List<int> machine2ID = new List<int>();

            foreach(Task task in machine1.tasks)
            {
                machine1ID.Add(task.ID);
            }
            machine1.tasks.Clear();
            machine1.totalTime = 0;

            foreach (Task task in machine2.tasks)
            {
                machine2ID.Add(task.ID);
            }
            machine2.tasks.Clear();
            machine2.totalTime = 0;

            foreach (int i in machine1ID)
            {
                machine1.tasks.Add(problemTasks[i-1]);
                machine1.totalTime += problemTasks[i - 1].processingTime; 
            }
            
            foreach (int i in machine2ID)
            {
                machine2.tasks.Add(problemTasks[i - 1]);
                machine2.totalTime += problemTasks[i - 1].processingTime;
            }

        }
        public void FPTAS_Algorithm(List<Task> problemTasks, Machine machine1, Machine machine2)
        {
            int k = 1;
            
            List<Task> EspaniolTasks = new List<Task>();
            foreach (Task task in problemTasks) // kopjowanie
            {
                // Trzeba skopjowac dodatkowo tasku
                Task copiedTask = new Task(task.ID, task.processingTime);
                EspaniolTasks.Add(copiedTask);
            }

            //List<Task> EspaniolTasks = problemTasks.ToList();
            PD pd = new PD();

            for (int i = 0; i< EspaniolTasks.Count; i++)
            {
                EspaniolTasks[i].processingTime /= k;
            }
    
            pd.PD_Algorithm(EspaniolTasks, machine1, machine2); // sa ukladane ale po czsie mniejszym k

            ArrangeByIndex(problemTasks, machine1, machine2); // tu juz sa normalnie ukladane

        }
    }
}
