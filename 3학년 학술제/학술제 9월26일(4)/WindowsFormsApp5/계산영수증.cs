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
    public partial class 계산영수증 : Form
    {
        public 계산영수증(DataGridView dgv)
        {
            InitializeComponent();
            dataGridView1.DataSource = dgv.DataSource;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Format = "N0";
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
        }
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int width;
            int height;
            int realwidth = 100;
            int realheight = 100;
            int q = 200;
            int z = 200;
            int w = 400;
            int x = 400;
            Graphics gf = e.Graphics;
            SizeF sf = gf.MeasureString(textBox1.Text, new Font(new FontFamily("Arial"), 200F), 250);
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                width = dataGridView1.Columns[i].Width;
                height = dataGridView1.Rows[i].Height;
                e.Graphics.FillRectangle(Brushes.AliceBlue, realwidth, realheight, width, height);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height);
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, dataGridView1.Font, Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
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
                Font font = new Font("Lucida Console", 12);
                e.Graphics.FillRectangle(Brushes.AliceBlue, 100F,4.0F,250F,70);
                e.Graphics.DrawRectangle(Pens.Black, 100F, 4.0F, 250F, 70);
                e.Graphics.DrawString("배달주소 : " + textBox1.Text, font, Brushes.Black, new RectangleF(new PointF(100F, 10F), sf), StringFormat.GenericTypographic);
                realwidth = w + z;
            }
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
