using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_Tracker
{
    public partial class Form3_delete_items : Form
    {
        public Form3_delete_items()
        {
            InitializeComponent();

            DB_Connection.PopulateDataGridView(dataGridView1);
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridViewCell clickedCell;

            DataGridView.HitTestInfo hit = dataGridView1.HitTest(e.X, e.Y);

            //if (hit.ColumnIndex == 1)
            {
                if (hit.Type == DataGridViewHitTestType.Cell)
                {
                    clickedCell = dataGridView1.Rows[hit.RowIndex].Cells[hit.ColumnIndex];

                    DialogResult result = MessageBox.Show("Delete Item ?", "CONFIRM", MessageBoxButtons.YesNo);
                    
                    if(result == DialogResult.Yes)
                    {
                        DB_Connection.DeletefromDB((string)clickedCell.Value);

                        dataGridView1.Rows.RemoveAt(hit.RowIndex);
                    }

                    
                }
            }
        }

        private void Form3_delete_items_Load(object sender, EventArgs e)
        {

        }
    }
}
