using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class 매출영수증 : Form
    {
        public 매출영수증(DataGridView 매출인쇄)
        {
            InitializeComponent();
            dataGridView1.DataSource = 매출인쇄.DataSource;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int width;
            int height;
            int realwidth = 100;
            int realheight = 100;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                width = dataGridView1.Columns[i].Width;
                height = dataGridView1.Rows[i].Height;
                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, dataGridView1.Font, Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                realwidth = 100;
                realheight = realheight + dataGridView1.Rows[i].Height;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    width = dataGridView1.Columns[j].Width;
                    height = dataGridView1.Rows[j].Height;
                    e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);
                    e.Graphics.DrawString(dataGridView1.Rows[i].Cells[j].Value.ToString(), dataGridView1.Font, Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
            }
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 매출영수증_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Format = "N0";
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoResizeColumns();
        }
    }
}
