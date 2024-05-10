using System.Text;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD
{
    internal class Program
    {
        public string Wypisz(Machine machine1, Machine machine2)
        {
            StringBuilder result = new StringBuilder();

            result.Append(machine1.ToString());
            result.Append(machine2.ToString());

            result.AppendLine("Total machining time: " + Math.Max(machine1.totalTime, machine2.totalTime));
            result.AppendLine();

            return result.ToString();
        }
        public string Wypisz3M(Machine machine1, Machine machine2, Machine machine3)
        {
            StringBuilder result = new StringBuilder();

            result.Append(machine1.ToString());
            result.Append(machine2.ToString());
            result.Append(machine3.ToString());

            //result.AppendLine("Total machining time: " + Math.Max(machine1.totalTime, machine2.totalTime, machine3.totalTime));
            result.AppendLine();

            return result.ToString();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Machine machine1 = new Machine(1);
            Machine machine2 = new Machine(2);
            Machine machine3 = new Machine(3);
            string fileName = "Data1.txt";
            string path = Path.Combine(Environment.CurrentDirectory, @"Testing_Data\", fileName);
            LoadInput input = new LoadInput(path);
            input.PrintInput();


            /*LSA lsa = new LSA();
            lsa.LsaAlgorithm(input.returnTaskList(), machine1, machine2);
            //Console.WriteLine(lsa.ToString());*/

            /*LPT lpt = new LPT();
            lpt.LptAlgorithm(input.returnTaskList(), machine1, machine2);
            //Console.WriteLine(lpt.ToString());*/

            /*Bruteforce bruteforce = new Bruteforce();
            bruteforce.BruteforceAlgorithm(input.returnTaskList(), machine1, machine2);
            */
            //Console.WriteLine(bruteforce.ToString());

            /*PD pd = new PD();
            pd.PD_Algorithm(input.returnTaskList(), machine1, machine2);
            //Console.WriteLine(pd.Wypisz(machine1, machine2));*/

            /*PTAS ptas = new PTAS();
            ptas.PTAS_Algorithm(input.returnTaskList(), machine1, machine2);
        */
             /*FPTAS fptas = new FPTAS();
             fptas.FPTAS_Algorithm(input.returnTaskList(), machine1, machine2);
            */


            /*
             * 3 MASZYNY
             */

            /*Bruteforce_3M bruteforce_3m = new Bruteforce_3M();
            bruteforce_3m.BruteforceAlgorithm(input.returnTaskList(), machine1, machine2, machine3);
        */

            /*LSA_3M lsa_3M = new LSA_3M();
            lsa_3M.LsaAlgorithm(input.returnTaskList(), machine1, machine2, machine3);
            */

            /*PTAS_3M ptas_3M = new PTAS_3M();
            ptas_3M.PTAS_3M_Algorithm(input.returnTaskList(), machine1, machine2, machine3);
            */




            /*PD_3M pd_3M = new PD_3M();
            pd_3M.PD_3M_Algorithm(input.returnTaskList(), machine1, machine2, machine3);
        */


            //Console.WriteLine(program.Wypisz3M(machine1, machine2, machine3));
            //Console.WriteLine(program.Wypisz(machine1, machine2));
        }
    }
}
