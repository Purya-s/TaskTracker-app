using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            toolTip1.SetToolTip(this.DeleteTask, "this will delete selected tasks.");

            //DB_Connection.PopulateDataGridView(dataGridView1);

            DB_Connection.ExtractWeekTasks();
            PopulateWeekTasksDGV(DB_Connection.taskslist);
            //foreach (var task in DB_Connection.taskslist)
            //{
            //    dataGridView1.Rows.Add(task);
            //}
        }
            
            


        private void AddnewTask_Click(object sender, EventArgs e)
        {
            LoadForm(new Form2_user_input());
        }

        private void DeleteTask_Click(object sender, EventArgs e)
        {
            LoadForm(new Form3_delete_items());
        }

        private void MarkAsDone_Click(object sender, EventArgs e)
        {

        }

        

        private void PopulateWeekTasksDGV(List<string> tl)
        {
            int rowcount = 1;

            foreach (var task in tl)
            {
                string dayofweek = task.Substring(0, 3);
                string nameoftask = task.Substring(3);

                int columnindex = 0;

                switch (dayofweek)
                {
                    case "sat":
                        columnindex = 0;
                        break;

                    case "sun":
                        columnindex = 1;
                        break;

                    case "mon":
                        columnindex = 2;
                        break;

                    case "tue":
                        columnindex = 3;
                        break;

                    case "wed":
                        columnindex = 4;
                        break;

                    case "thu":
                        columnindex = 5;
                        break;

                    case "fri":
                        columnindex = 6;
                        break;
                }

                if (dataGridView1[columnindex,rowcount-1].Value==null)
                {
                    dataGridView1[columnindex, rowcount - 1].Value = nameoftask;
                }
                else
                {
                    dataGridView1.Rows.Add();
                    dataGridView1[columnindex, rowcount-1].Value = nameoftask;
                    rowcount++;
                }
            }
        }



        private void LoadForm(Form frm)
        {
            frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
            this.Hide();
            // Here you can set a bunch of properties, apply skins, save logs...
            // before you show any form
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        void GetWeekTasks()
        {

        }
    }



    public class task_to_do
    {
        public string title1;
        public string description1;
        //public DateTime date = new DateTime();
    }
}
