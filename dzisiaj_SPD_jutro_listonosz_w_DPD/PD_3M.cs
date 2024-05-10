using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD
{
    internal class PD_3M
    {
        int totalTime;
        private int[,] T;// = new int[n, 3];

        public void PD_3M_Algorithm(List<Task> problemTasks, Machine machine1, Machine machine2, Machine machine3)
        {

            int nRows = problemTasks.Count + 1;
            int sum_proccess = 0;

            foreach (Task task in problemTasks)
            {
                sum_proccess += task.processingTime;
            }
            int nCols = sum_proccess / 2 + 1;

            T = new int[nRows, nCols];

            for (int row = 0; row < nRows; row++)
            {
                T[row, 0] = 1;
                for (int col = 1; col < nCols; col++)
                {
                    T[row, col] = 0;
                }
            }

            show_table(T, nCols, nRows);

            for (int row = 1; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    if (T[row - 1, col] == 1)
                    {
                        T[row, col] = 1;
                        if (col + problemTasks[row - 1].processingTime < nCols)
                        {
                            T[row, col + problemTasks[row - 1].processingTime] = 1;
                        }
                    }
                }
            }
            Console.WriteLine("Uzupełniony syf:");
            show_table(T, nCols, nRows);

            var idx = (nRows - 1, nCols - 1);
            int row_2 = nRows - 1;

            while (true)
            {

                idx = FindHighestOne(T, idx.Item1, idx.Item2);

                if (idx.Item1 - 1 < 0) break;

                machine1.tasks.Add(problemTasks[idx.Item1 - 1]);
                machine1.totalTime += problemTasks[idx.Item1 - 1].processingTime;
                /*
                 * Druga maszyna
                 */
                for (int i = row_2; i > idx.Item1; i--)
                {
                    machine2.tasks.Add(problemTasks[i - 1]);
                    machine2.totalTime += problemTasks[i - 1].processingTime;
                }

                row_2 = idx.Item1 - 1;

                Console.WriteLine(idx.Item1 + " " + idx.Item2);

                int wartosc = problemTasks[idx.Item1 - 1].processingTime;

                if (idx.Item2 - wartosc < 0)
                {
                    break;
                }
                idx.Item2 -= wartosc;

            }
            /*
             * Maszyna 2 - dodajemy reszte ktora zostala
             */

            for (int i = row_2; i > 0; i--)
            {
                machine2.tasks.Add(problemTasks[i - 1]);
                machine2.totalTime += problemTasks[i - 1].processingTime;
            }



            totalTime = Math.Max(machine1.totalTime, machine2.totalTime);


        }
        public string Wypisz(Machine machine1, Machine machine2)
        {

            StringBuilder result = new StringBuilder();

            result.Append(machine1.ToString());
            result.Append(machine2.ToString());

            result.AppendLine("Total machining time: " + totalTime);
            result.AppendLine();

            return result.ToString();
        }

        public void show_table(int[,] T, int nCols, int nRows)
        {
            for (int row = 0; row < nRows; ++row)
            {
                for (int col = 0; col < nCols; ++col)
                {
                    Console.Write($"{T[row, col]} ");
                }
                Console.Write("\n");
            }
        }
        public (int, int) FindHighestOne(int[,] T, int nRows, int nCols)
        {
            for (int col = nCols; col >= 0; col--)
            {
                for (int row = nRows; row >= 0; row--)
                {
                    if (T[row, col] == 1 && (row - 1 < 0 || T[row - 1, col] == 0)) return (row, col);
                }
            }
            return (-1, -1); // blad 
        }

    }
}
