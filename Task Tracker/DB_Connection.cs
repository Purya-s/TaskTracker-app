using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_Tracker
{
    internal class DB_Connection
    {
        static MySqlConnection conn;
        static MySqlCommand cmd = null;
        static MySqlDataReader reader = null;

        static string myConnectionString = "server=localhost;uid=root;" +
                                           "pwd=bl93$mo276;database=task_tracker_db";



        public static void WritetoDB(string tname, string tdescription, string ttime, string tdate, int rep, string wdays)
        {
            string query = "";

            if (Form2_user_input.rs)
            {
                 query = $"INSERT INTO tasks (task_name, task_description, task_date, task_time, repeating, weekdays) " +
                           $"VALUES( \'{tname}\', \'{tdescription}\', {tdate}, \'{ttime}\', \'{rep}\',\'{wdays}\')";
            }
            else
            {
                 query = $"INSERT INTO tasks (task_name, task_description, task_date, task_time, repeating, weekdays) " +
                           $"VALUES( \'{tname}\', \'{tdescription}\', \'{tdate}\', \'{ttime}\', \'{rep}\',{wdays})";
            }
            

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            cmd.Dispose();
            conn.Close();
        }

        public static void DeletefromDB(string s)
        {
            string query = $"DELETE from tasks WHERE task_name = \'{s}\'";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            cmd.Dispose();
            conn.Close();
        }

        public static List<string> taskslist = new List<string>();

        public static void ExtractWeekTasks()
        {
            string query1 = "select task_name, task_date from tasks where " +
                            "task_date is not null";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

                cmd = new MySqlCommand(query1, conn);
                reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    DateTime dt = (DateTime)reader["task_date"];
                    DayOfWeek dow = dt.DayOfWeek;

                    switch (dow)
                    {
                        case DayOfWeek.Saturday:
                            taskslist.Add($"sat{reader["task_name"]}");
                            break;

                        case DayOfWeek.Sunday:
                            taskslist.Add($"sun{reader["task_name"]}");
                            break;

                        case DayOfWeek.Monday:
                            taskslist.Add($"mon{reader["task_name"]}");
                            break;

                        case DayOfWeek.Tuesday:
                            taskslist.Add($"tue{reader["task_name"]}");
                            break;

                        case DayOfWeek.Wednesday:
                            taskslist.Add($"wed{reader["task_name"]}");
                            break;

                        case DayOfWeek.Thursday:
                            taskslist.Add($"thu{reader["task_name"]}");
                            break;

                        case DayOfWeek.Friday:
                            taskslist.Add($"fri{reader["task_name"]}");
                            break;
                    }
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            cmd.Dispose();
            conn.Close();
        }

        public static void PopulateDataGridView(DataGridView dgv)
        {
            string query = "SELECT task_name ,task_description FROM tasks"; 

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);

                    dgv.DataSource = dataTable;
                }
            }
        }
    }
}
