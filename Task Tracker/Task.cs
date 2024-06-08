using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracker
{
    internal class Task
    {
        public string title1;
        public string description1;
        //public DateTime date = new DateTime();



        static public List<task_to_do> tasks = new List<task_to_do>();

        static public void make_new_task()
        {
            bool flag = false;

            task_to_do temp = new task_to_do();

            temp.title1 = "";
            temp.description1 = "";

            foreach (task_to_do x1 in tasks)
            {
                if (x1.title1 == temp.title1)
                    flag = true;
            }
            if (!flag)
                tasks.Add(temp);
        }
    }
}
