using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzisiaj_SPD_jutro_listonosz_w_DPD {
    internal class Task {
        public int ID {get; set; }
        public int processingTime { get; set; }
        public Task(int _ID, int _processingTime) {
            ID = _ID;
            processingTime = _processingTime;
        }

        public override string ToString() {
            return "ID: " + ID + " Processing Time: " + processingTime;
        }
    }
}
