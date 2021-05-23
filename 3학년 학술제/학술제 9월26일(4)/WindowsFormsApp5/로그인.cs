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
    public partial class 로그인 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=222.116.108.117;User ID=201510466;Password=rlagmlxo");
        
        List<직원이름> receipts = new List<직원이름>();
        ComboBox qqq = new ComboBox();
        포스 frmReceipt = new 포스();
        public delegate void FormSendDataHandler(string sendstring);
        //이벤트 생성
        public event FormSendDataHandler FormSendEvent;
        public 로그인()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string qq = "select * from 학술제로그인 where 아이디 = '" + comboBox1.Text
            + "' and 비밀번호 = '" + textBox1.Text + "'";
            string q = comboBox1.Text;
            SqlCommand command = new SqlCommand();
            command.CommandText = qq;
            command.Connection = conn;
            SqlDataReader reader;
            conn.Open();
            reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                MessageBox.Show("환영합니다." + comboBox1.Text + "님" );
                this.Hide();
                포스 frm2 = new 포스(); // Form2형 frm2 인스턴스화(객체 생성)
                frm2.Passvalue = ("직원이름 : " + comboBox1.Text);  // 전달자(Passvalue)를 통해서 Form2 로 전달
                frm2.ShowDialog();
                포스 f2 = new 포스();
                this.Hide();
                conn.Close();
                if (comboBox1.Text.Length == 0)
                {
                    MessageBox.Show("값이 입력되지 않았습니다");
                    return;
                }

              
            }
            else
            {
                MessageBox.Show("비밀번호를 확인해주세요.");
                comboBox1.Text = "";
                textBox1.Clear();
                textBox1.Focus();
            }
            
            
        }
        private void DieaseUpdateEventMethod(object sender)
        {
            //폼2에서 델리게이트로 이벤트 발생하면 현재 함수 Call
            textBox1.Text = sender.ToString();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                button1_Click(sender, e);
            }
        }

        private void 로그인_Load(object sender, EventArgs e)
        {

        }
    }
    }
