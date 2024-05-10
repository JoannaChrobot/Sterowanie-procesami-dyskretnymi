using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD
{
    internal class PTAS_3M
    {
        private int nMachines = 3;

        public IEnumerable<Task> Sort(List<Task> problemTasks)
        {
            return problemTasks.OrderByDescending(item => item.processingTime).ToList();
        }


        public void PTAS_3M_Algorithm(List<Task> problemTasks, Machine machine1, Machine machine2, Machine machine3)
        {

            int k = problemTasks.Count / 2;
            Bruteforce_3M bruteforce = new Bruteforce_3M();
            LSA_3M lsa = new LSA_3M();
            /*
             * sortowanie po processing time
             */
            IEnumerable<Task> sortedTask = Sort(problemTasks);

            IEnumerable<Task> kTasks = sortedTask.ToList().GetRange(0, k);
            IEnumerable<Task> remainingTasks = sortedTask.ToList().GetRange(k, problemTasks.Count - k);

            bruteforce.BruteforceAlgorithm(kTasks.ToList(), machine1, machine2, machine3);
            lsa.LsaAlgorithm(remainingTasks.ToList(), machine1, machine2, machine3);

        }
    }
}
