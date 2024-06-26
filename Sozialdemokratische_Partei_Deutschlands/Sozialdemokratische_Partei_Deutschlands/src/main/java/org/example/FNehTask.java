package org.example;

public class FNehTask extends Task{

        public Integer remainingTime;
        public Integer endTime;



//        public FNehTask(Integer rT, Integer eT) {
//            this.ID = ID;
//            this.t1 = t1;
//            this.t2 = t2;
//            this.t3 = t3;
//            this.remainingTime = rT;
//            this.endTime = eT;
//        }


        @Override
        public String toString() {
            return "Task ID: " + ID + ", t1: " + t1 + ", t2: " + t2 + ", t3: " + t3;
        }


}
