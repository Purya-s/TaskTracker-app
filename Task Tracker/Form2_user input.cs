using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Tracker
{
    public partial class Form2_user_input : Form
    {
        public static bool rs = false;
        bool Repetion_State = false;

        public bool repetion_state{get { return Repetion_State; } } 

        enum WeekDays
        {
            sat = 1,
            sun,
            mon,
            tue,
            wed,
            thu,
            fri,
        }

        List<WeekDays>selected_wd = new List<WeekDays>();


        public Form2_user_input()
        {
            InitializeComponent();
        }

        private void Finish_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (this.textBox1.Text == "")
                flag = true;

            try
            {
                if (this.textBox1.Text == "")
                {
                    throw new Exception("Title can not be empty !!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (!flag)
            {
                string wdays = "";
                int rep_state;

                for (int i = 0; i < selected_wd.Count; i++)
                {
                    if (i < selected_wd.Count - 1)
                        wdays += selected_wd[i].ToString() + ',';
                    else
                        wdays += selected_wd[i].ToString();
                }

                if (Repetion_State)
                    rep_state = 1;
                else
                    rep_state = 0;


                if(Repetion_State)
                {
                    DB_Connection.WritetoDB(textBox1.Text, textBox2.Text,
                                        dateTimePicker2.Value.ToString("HH:mm:ss"),
                                        "null", rep_state, wdays);
                }

                else
                {
                    DB_Connection.WritetoDB(textBox1.Text, textBox2.Text,
                                        dateTimePicker2.Value.ToString("HH:mm:ss"),
                                        dateTimePicker1.Value.ToString("yyyy-MM-dd"),
                                        rep_state, "null");
                }

                this.Close();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submitdatetime_click(object sender, EventArgs e)
        {
            DateTime dt1 = dateTimePicker1.Value.Date + dateTimePicker2.Value.TimeOfDay;

            string wdays = "";
            for (int i = 0; i < selected_wd.Count; i++)
            {
                if (i < selected_wd.Count - 1)
                    wdays += selected_wd[i].ToString() + ',';
                else
                    wdays += selected_wd[i].ToString();
            }

            label4.Text = dt1.ToString("f") + "\n" + wdays;
            
            
        }

        private void repeat_state_Click(object sender, EventArgs e)
        {
            if(!Repetion_State)
            {
                button1.Visible=true;
                button2.Visible=true;
                button3.Visible=true;
                button4.Visible=true;
                button5.Visible=true;
                button6.Visible=true;
                button7.Visible=true;

                

                repeat_state.Text = "REPEATING";

                Repetion_State = true;
                rs = true;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;

                repeat_state.Text = "NOT_REPEATING";

                Repetion_State = false;
                rs = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!selected_wd.Contains(WeekDays.sat))
                selected_wd.Add(WeekDays.sat);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!selected_wd.Contains(WeekDays.sun))
                selected_wd.Add(WeekDays.sun);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!selected_wd.Contains(WeekDays.mon))
                selected_wd.Add(WeekDays.mon);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!selected_wd.Contains(WeekDays.tue))
                selected_wd.Add(WeekDays.tue);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!selected_wd.Contains(WeekDays.wed))
                selected_wd.Add(WeekDays.wed);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!selected_wd.Contains(WeekDays.thu))
                selected_wd.Add(WeekDays.thu);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!selected_wd.Contains(WeekDays.fri))
                selected_wd.Add(WeekDays.fri);
        }

        
    }
}
