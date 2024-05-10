using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD {
    internal class LoadInput {
        private List<Task> tasks {  get; set; }
        private string? line;
        private string[]? splitLine;

        public LoadInput(string path) {
            tasks = new List<Task>();
            line = string.Empty;
            using (StreamReader sr = new StreamReader(path)) {
                while ((line = sr.ReadLine()) != null) {
                    splitLine = line.Split(' ');
                    if (splitLine.Length == 2 && int.TryParse(splitLine[0], out int id) && int.TryParse(splitLine[1], out int processingTime)) {
                        tasks.Add(new Task(id, processingTime));
                    }
                }
            }
        }

        public List<Task> returnTaskList() {
            return tasks;
        }

        public void PrintInput() {
            Console.WriteLine("Input Data:");
            foreach (Task task in tasks) {
                Console.WriteLine(task);
            }
            Console.WriteLine();
        }
    }
}
