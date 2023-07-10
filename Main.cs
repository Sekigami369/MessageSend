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
using System.Data.Common;

namespace MessageSend
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            MessLoadData();
            schedule();
            ActivityReport();
        }
       /*
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;

            if(dataGridView == dataGridView1)
            {

            }
            else if(dataGridView == dataGridView2)
            {

            }
        */
        private void MessLoadData()
        {
            try
            {
                using (SqlConnection connection = DbConn.GetConnecton())
                {
                    string query = "SELECT TOP 3 messtitle AS '件名', username AS 'from', message_ AS 'お知らせ内容' FROM MessageInfo ORDER BY inputDate DESC;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("データを呼び出せませんでした。" + ex.Message);
            }
        }

        private void schedule()
        {
            try
            {
                using (SqlConnection connection = DbConn.GetConnecton())
                {
                    string query = "SELECT TOP 3 schDate AS '日付', schTime AS '時間' FROM schedule";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ActivityReport()
        {
            try
            {
                using(SqlConnection connection = DbConn.GetConnecton())
                {
                    string query = "SELECT  schDate AS '日付', schTime AS '時間' FROM schedule ORDER BY RAND()";
                    using (SqlCommand  command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataGridView3.DataSource = dataTable;
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CellClick += DataGridView_CellClick;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessSend messSend = new MessSend();
            messSend.Show();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InfoList infoList = new InfoList();
            infoList.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.CellClick += DataGridView_CellClick;

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //検索用テキストボックス
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //検索実行用ボタン
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
