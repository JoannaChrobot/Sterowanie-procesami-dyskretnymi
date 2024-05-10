using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD
{
    internal class PTAS
    {
        private int nMachines = 2;
       
        public IEnumerable<Task> Sort(List<Task> problemTasks)
        {
            return problemTasks.OrderByDescending(item => item.processingTime).ToList();
        }
        

        public void PTAS_Algorithm(List<Task> problemTasks, Machine machine1, Machine machine2)
        {
            
            int k = problemTasks.Count/2;
            Bruteforce bruteforce = new Bruteforce();
            LSA lsa = new LSA();
            /*
             * sortowanie po processing time
             */
            IEnumerable<Task> sortedTask = Sort(problemTasks);
            
            IEnumerable<Task> kTasks = sortedTask.ToList().GetRange(0, k);
            IEnumerable<Task> remainingTasks = sortedTask.ToList().GetRange(k, problemTasks.Count-k);

            bruteforce.BruteforceAlgorithm(kTasks.ToList(), machine1, machine2);
            lsa.LsaAlgorithm(remainingTasks.ToList(), machine1, machine2); 

        }
    }
}
