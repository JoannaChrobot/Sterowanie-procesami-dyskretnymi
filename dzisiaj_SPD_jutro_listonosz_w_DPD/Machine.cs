using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD {
    internal class Machine {
        public int machineID;
        public List<Task> tasks;
        public int totalTime {  get; set; }
        public Machine(int _machineID) {
            tasks = new List<Task>();
            machineID = _machineID;
            totalTime = 0;
        }
        public override string ToString() {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Machine {machineID} Tasks: ");
            foreach (Task task in tasks) {
                result.AppendLine(task.ToString());
            }
            result.AppendLine("Machining time: " + totalTime);
            result.AppendLine();
            return result.ToString();
        }
    }
}
