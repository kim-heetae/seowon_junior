using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp5
{
    public partial class 포스 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=222.116.108.117;User ID=201510466;Password=rlagmlxo");
        
        List<Beverage> order = new List<Beverage>();
        List<Beverage> orderq = new List<Beverage>();
        DataGridView dgvTemp = new DataGridView();
        DataGridView dgvTempq = new DataGridView();
        DataGridView dgvTempw = new DataGridView();
        List<영수증> receipts = new List<영수증>();
        List<매출인쇄> receipt2s = new List<매출인쇄>();
        public int qq;
        private ComboBox qqq;
        private string Form2_value;
        public string Passvalue
        {
            get { return this.Form2_value; }
            set { this.Form2_value = value; }  // 다른폼(Form1)에서 전달받은 값을 쓰기
        }
        
        public 포스()
        {
            InitializeComponent();
        }

        public 포스(ComboBox qqq)
        {
            this.qqq = qqq;
        }

        private void refreshDGV()
        {
            dataGridView1.DataSource = order.ToList();
            dataGridView2.DataSource = order.ToList();
        }
        private void calcOrder()
        {
            var order메뉴 = from o in order
                          group o by o.메뉴 into g
                          select new { 메뉴 = g.Key, 수량 = g.Count(), 금액합계 = g.Sum(o => o.가격) };
            int 금액합계s = order
                .GroupBy(o => o.메뉴)
                .Select(g => g.Sum(o => o.가격))
                .Sum();
            int Quantities = order
                .GroupBy(o => o.메뉴)
                .Select(g => g.Count())
                .Sum();
            var orderList = order메뉴.ToList();
            orderList.Add(new { 메뉴 = "합계", 수량 = Quantities, 금액합계 = 금액합계s });
            textBox1.Text = 금액합계s.ToString();
            dataGridView2.DataSource = orderList;
        }
        private void setDGV(object sender, int price)
        {
            order.Add(new Beverage(((Button)sender).Text, price));
            refreshDGV();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "영업일자 : " + DateTime.Now.ToString("F");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("F");
        }

        private void tableLayoutPanel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button43_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox13.Text);
                int y = 10;
                int sum = x - y;
                textBox13.Text = sum.ToString();
                string sql = "UPDATE 회원관리1 SET " +

                  "전화번호 = '" + textBox11.Text + "'," +
                  "생년월일 = '" + textBox12.Text + "'," +
                  "쿠폰 = '" + sum.ToString() + "'" +
                  " WHERE 회원이름 = '" + textBox10.Text + "'";
                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                button44.PerformClick();

                string sql2 = "SELECT 회원이름, 전화번호, 생년월일, 쿠폰, 성별 FROM 회원관리1 WHERE 회원이름 LIKE '%" + (textBox10.Text) + "%'";
                SqlCommand command2 = new SqlCommand();
                command2.CommandText = sql2;
                command2.Connection = conn;
                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                dataGridView3.DataSource = table2;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
            }
            catch
            {
                MessageBox.Show("고객을 선택해 주세요.");
            }
        }
        private void dgvOrder_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string item = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show(item + " 선택을 삭제하겠습니까?", "선택삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                order.RemoveAt(e.RowIndex);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = order;
                dataGridView1.Refresh();
            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 50000;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 30000;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Format = "N0";
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            label1.Text = Passvalue;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 20000;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 10000;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 5000;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 1000;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 500;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox7.Text);
            int y = 100;
            int sum = x + y;
            textBox7.Text = sum.ToString();
        }

        private void button35_Click(object sender, EventArgs e)
        {
            
            textBox7.Text = "0";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            setDGV(sender, 11000);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            calcOrder();
            double discount = 0;
            int y = Convert.ToInt32(textBox1.Text);
            int z = Convert.ToInt32(textBox2.Text);
            int x = Convert.ToInt32(textBox3.Text);
            textBox3.Text = (y - z).ToString();
            textBox5.Text = z.ToString();
            textBox4.Text = x.ToString();
            int q = Convert.ToInt32(textBox4.Text);
            int w = Convert.ToInt32(textBox5.Text);
            textBox2.Text = discount.ToString();
            textBox6.Text = (q + w).ToString();
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            textBox20.Text = textBox18.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int z = dataGridView1.RowCount - 1;
            string items = dataGridView1.Rows[z].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show(" 전체삭제하겠습니까?", "전체삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
                {
                    string item = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    order.RemoveAt(i);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = order;
                    dataGridView1.Refresh();
                }
                textBox1.Text = "0";
                textBox2.Text = "0";
                textBox3.Text = "0";
            }
            else { };
        }
        
        private void btn_delete_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string item = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            DialogResult result = MessageBox.Show(item + " 선택을 삭제하겠습니까?", "선택삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                order.RemoveAt(e.RowIndex);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = order;
                dataGridView1.Refresh();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            {
                calcOrder();
                double discount = 0;
                int y = Convert.ToInt32(textBox1.Text);
                int w = Convert.ToInt32(textBox6.Text);
                textBox2.Text = discount.ToString();
                int q = Convert.ToInt32(textBox2.Text);
                int r = Convert.ToInt32(textBox5.Text);
                textBox3.Text = (y - q).ToString();
                setDGV(sender, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setDGV(sender, 13000);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setDGV(sender, 11000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setDGV(sender, 14000);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setDGV(sender, 12000);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setDGV(sender, 16000);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setDGV(sender, 20000);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setDGV(sender, 10000);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setDGV(sender, 2000);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            setDGV(sender, 500);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            setDGV(sender, 300);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            setDGV(sender, 300);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            setDGV(sender, 8000);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            setDGV(sender, 3000);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            setDGV(sender, 7000);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            setDGV(sender, 2000);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {

                int changeAmount = (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox6.Text));
                int x = Convert.ToInt32(textBox7.Text);
                int y = Convert.ToInt32(textBox6.Text);
                if (changeAmount < 0)
                {
                    changeAmount *= -1;
                    MessageBox.Show(changeAmount.ToString("N0") + " 원이 부족합니다.");
                }
                else
                {
                    textBox8.Text = changeAmount.ToString("N0");
                    int z = Convert.ToInt32(textBox5.Text);
                    int w = Convert.ToInt32(textBox7.Text);
                    int v = Convert.ToInt32(textBox6.Text);
                    int q = v - z;
                    string sql = "INSERT INTO 학술제매출 (날짜, 매출금액, 결제방법) VALUES('"
            + toolStripStatusLabel1.Text + "', '"
            + q.ToString() + "', '"
            + "현금" + "')";

                    SqlCommand command = new SqlCommand();
                    command.CommandText = sql;
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("매출이 추가되었습니다.");
                }
                textBox8.Text = (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox4.Text)).ToString();
                textBox4.Text = (Convert.ToInt32(textBox6.Text) - Convert.ToInt32(textBox5.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("계산할 항목이 없습니다.", ex.Message);
            }

        }

        private void button19_Click(object sender, EventArgs e)
        {
            calcOrder();
            double discount = 0;
            int w = 2000;
            int y = Convert.ToInt32(textBox1.Text);
            textBox2.Text = discount.ToString();
            int q = Convert.ToInt32(textBox2.Text);
            textBox1.Text = (y + w).ToString();
            textBox3.Text = (y+w).ToString();
            setDGV(sender, 2000);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            calcOrder();
            double discount = 0;
            int y = Convert.ToInt32(textBox1.Text);
            discount += (Convert.ToInt32(textBox1.Text) * 0.1);
            textBox2.Text = discount.ToString();
            int q = Convert.ToInt32(textBox2.Text);
            textBox3.Text = (y - q).ToString();
            
            setDGV(sender, -q);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            
        }

        private void button24_Click(object sender, EventArgs e)
        {


            {

                int changeAmount = (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox6.Text));
                int x = Convert.ToInt32(textBox7.Text);
                int y = Convert.ToInt32(textBox6.Text);
                int z = Convert.ToInt32(textBox5.Text);
                int q = y - z;
                string sql = "INSERT INTO 학술제매출 (날짜, 매출금액, 결제방법) VALUES('"
        + toolStripStatusLabel1.Text + "', '"
        + q.ToString() + "', '"
            + "카드" + "')";

                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("매출이 추가되었습니다.");
                textBox7.Text = "카드";
                textBox8.Text = "0";
                textBox4.Text = (y - z).ToString();
            }
        }

        private void button22_Click_1(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabControl1.TabPages[2];
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {

                int changeAmount = (Convert.ToInt32(textBox7.Text) - Convert.ToInt32(textBox6.Text));
                int x = Convert.ToInt32(textBox7.Text);
                int y = Convert.ToInt32(textBox6.Text);
                
                    int z = Convert.ToInt32(textBox5.Text);
                    int w = Convert.ToInt32(textBox7.Text);
                    int v = Convert.ToInt32(textBox6.Text);
                    int q = v - z;
                    string sql = "INSERT INTO 학술제매출 (날짜, 매출금액, 결제방법) VALUES('"
            + toolStripStatusLabel1.Text + "', '"
            + q.ToString() + "', '"
            + "쿠폰" + "')";

                    SqlCommand command = new SqlCommand();
                    command.CommandText = sql;
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("매출이 추가되었습니다.");

                textBox8.Text = "0";
                textBox5.Text = (Convert.ToInt32(textBox6.Text).ToString());
                textBox4.Text = (Convert.ToInt32(textBox6.Text) - Convert.ToInt32(textBox5.Text)).ToString();
                textBox7.Text = "쿠폰";
            }
            catch (Exception ex)
            {
                MessageBox.Show("계산할 항목이 없습니다.", ex.Message);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            int y = Convert.ToInt32(textBox6.Text);
            dgvTempq.DataSource = dataGridView2.DataSource;
            계산영수증 frmReceipt = new 계산영수증(dgvTempq);
            frmReceipt.label4.Text = String.Format("{0:#,#}", textBox7.Text);
            frmReceipt.label5.Text = String.Format("{0:#,#}", Convert.ToInt32(textBox5.Text));
            frmReceipt.label6.Text = String.Format("{0:#,#}", Convert.ToInt32(textBox4.Text));
            frmReceipt.label8.Text = String.Format("{0:#,#}", Convert.ToInt32(textBox6.Text));
            frmReceipt.textBox1.Text = String.Format("{0:#,#}", textBox20.Text);
            frmReceipt.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void button41_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 회원이름, 전화번호, 생년월일, 쿠폰, 성별 FROM 회원관리1 WHERE 회원이름 LIKE '%" + (textBox9.Text) + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView3.DataSource = table;
            textBox9.Clear();
        }

        private void button44_Click(object sender, EventArgs e)
        {
            string sql = "select 회원이름,전화번호,생년월일,쿠폰,성별 from 회원관리1";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView3.DataSource = table;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            string q;
            if (radioButton1.Checked)
            {
                q = radioButton1.Text;
            }
            else
            {
                q = radioButton2.Text;
            }

            string sql = "INSERT INTO 회원관리1 (회원이름, 전화번호, 생년월일, 쿠폰, 성별) VALUES('"
            + textBox10.Text + "', '"//회원이름
            + textBox11.Text + "', '"//전화번호
            + textBox12.Text + "', '"//생년월일
            + textBox13.Text + "', '"//쿠폰
            + q + "')";//성별

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            button44.PerformClick(); //버튼4를 이용   

            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE 회원관리1 SET " +

               "전화번호 = '" + textBox11.Text + "'," +
               "생년월일 = '" + textBox12.Text + "'," +
               "쿠폰 = '" + textBox13.Text + "'" +
               " WHERE 회원이름 = '" + textBox10.Text + "'";

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            button44.PerformClick(); //버튼4를 이용   

            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();

        }

        private void button47_Click(object sender, EventArgs e)
        {
            string sql = "DELETE 회원관리1 " +
   " WHERE 회원이름 = '" + textBox10.Text + "'";

            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            button44.PerformClick(); //버튼4를 이용   

            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(textBox13.Text);
                int y = 1;
                int sum = x + y;
                textBox13.Text = sum.ToString();
                string sql = "UPDATE 회원관리1 SET " +

                  " 전화번호 = '" + textBox11.Text + "'," +
                  " 생년월일 = '" + textBox12.Text + "'," +
                  " 쿠폰 = '" + sum.ToString() + "'" +
                  " WHERE 회원이름 = '" + textBox10.Text + "'";
                SqlCommand command = new SqlCommand();
                command.CommandText = sql;
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                button44.PerformClick();
                string sql2 = "SELECT 회원이름, 전화번호, 생년월일, 쿠폰, 성별 FROM 회원관리1 WHERE 회원이름 LIKE '%" + (textBox10.Text) + "%'";
                SqlCommand command2 = new SqlCommand();
                command2.CommandText = sql2;
                command2.Connection = conn;
                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                dataGridView3.DataSource = table2;
            }
            catch
            { }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 날짜,매출금액,결제방법 FROM 학술제매출 WHERE 날짜 LIKE '%" + (textBox14.Text + "일") + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            textBox14.Clear();
        }

        private void button37_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (DataGridViewRow r in dataGridView4.Rows)
            {
                sum += Convert.ToInt32(r.Cells[1].Value);
            }
            textBox19.Text = sum.ToString("N0");
        }

        private void button38_Click(object sender, EventArgs e)
        {
            int sum = 0;
            int w = Convert.ToInt32(dataGridView4.Rows.Count);
            int q = 0;

            foreach (DataGridViewRow r in dataGridView4.Rows)
            {
                sum += Convert.ToInt32(r.Cells[1].Value);
            }
            q = Convert.ToInt32(sum / (w - 1));
            textBox19.Text = q.ToString("N0");
        }

        private void button39_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 날짜,매출금액,결제방법 FROM 학술제매출 WHERE 날짜 LIKE '%" + (textBox15.Text + "월") + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            textBox15.Clear();
        }

        private void button40_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (DataGridViewRow r in dataGridView4.Rows)
            {
                sum += Convert.ToInt32(r.Cells[1].Value);
            }
            textBox19.Text = sum.ToString("N0");
        }

        private void button48_Click(object sender, EventArgs e)
        {
            int sum = 0;
            int w = Convert.ToInt32(dataGridView4.Rows.Count);
            int q = 0;

            foreach (DataGridViewRow r in dataGridView4.Rows)
            {
                sum += Convert.ToInt32(r.Cells[1].Value);
            }
            q = Convert.ToInt32(sum / (w - 1));
            textBox19.Text = q.ToString("N0");
        }

        private void button49_Click(object sender, EventArgs e)
        {
            string sql = "SELECT 날짜,매출금액,결제방법 FROM 학술제매출 WHERE 날짜 LIKE '%" + (textBox16.Text + "년") + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            textBox16.Clear();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (DataGridViewRow r in dataGridView4.Rows)
            {
                sum += Convert.ToInt32(r.Cells[1].Value);
            }
            textBox19.Text = sum.ToString("N0");
        }

        private void button51_Click(object sender, EventArgs e)
        {
            int sum = 0;
            int w = Convert.ToInt32(dataGridView4.Rows.Count);
            int q = 0;

            foreach (DataGridViewRow r in dataGridView4.Rows)
            {
                sum += Convert.ToInt32(r.Cells[1].Value);
            }
            q = Convert.ToInt32(sum / (w - 1));
            textBox19.Text = q.ToString("N0");
        }

        private void button52_Click(object sender, EventArgs e)
        {
            
        }

        private void button54_Click(object sender, EventArgs e)
        {
            
        }

        private void button52_Click_1(object sender, EventArgs e)
        {
            string sql = "SELECT 날짜,매출금액,결제방법 FROM 학술제매출 WHERE 결제방법 LIKE '%" + (textBox17.Text) + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandText = sql;
            command.Connection = conn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView4.DataSource = table;
            textBox17.Clear();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            dgvTempw.DataSource = dataGridView4.DataSource;
            매출영수증 frmReceiptq = new 매출영수증(dgvTempw);
            frmReceiptq.ShowDialog();
        }

        private void tableLayoutPanel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process program = System.Diagnostics.Process.Start(@"C:\Users\MIS26\Desktop\Melon Player4\Melon.exe");
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X,
                                e.RowBounds.Location.Y,
                                dataGridView1.RowHeadersWidth - 4,
                                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                                (e.RowIndex + 1).ToString(),
                                dataGridView1.RowHeadersDefaultCellStyle.Font,
                                rect,
                                dataGridView1.RowHeadersDefaultCellStyle.ForeColor,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

        }

        private void dataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X,
                                e.RowBounds.Location.Y,
                                dataGridView2.RowHeadersWidth - 4,
                                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                                (e.RowIndex + 1).ToString(),
                                dataGridView2.RowHeadersDefaultCellStyle.Font,
                                rect,
                                dataGridView2.RowHeadersDefaultCellStyle.ForeColor,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void dataGridView3_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X,
                                e.RowBounds.Location.Y,
                                dataGridView3.RowHeadersWidth - 4,
                                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                                (e.RowIndex + 1).ToString(),
                                dataGridView3.RowHeadersDefaultCellStyle.Font,
                                rect,
                                dataGridView3.RowHeadersDefaultCellStyle.ForeColor,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void dataGridView4_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X,
                                e.RowBounds.Location.Y,
                                dataGridView4.RowHeadersWidth - 4,
                                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics,
                                (e.RowIndex + 1).ToString(),
                                dataGridView4.RowHeadersDefaultCellStyle.Font,
                                rect,
                                dataGridView4.RowHeadersDefaultCellStyle.ForeColor,
                                TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        private void tableLayoutPanel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button54_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox18.Clear();
            textBox20.Clear();
        }

        private void DataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox10.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox11.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox12.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox13.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
            }
        }

        private void tableLayoutPanel22_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
