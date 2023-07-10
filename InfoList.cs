using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageSend
{
    public partial class InfoList : Form
    {
        public InfoList()
        {
            InitializeComponent();
            MessLoadData();
        }

        private void MessLoadData()
        {
            try
            {
                using (SqlConnection connection = DbConn.GetConnecton())
                {
                    string query = "SELECT id AS '受付番号', messtitle AS '件名'," +
                        "username AS 'from', message_ AS 'お知らせ内容'," +
                        "inputDate AS '受付日時' FROM MessageInfo ORDER BY inputDate DESC;";
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
                MessageBox.Show("データが呼び出せませんでした。" + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
/*
using System;
using System.Windows.Forms;

public class MainForm : Form
{
    private DataGridView dataGridView;

    public MainForm()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // DataGridViewの作成と設定
        dataGridView = new DataGridView();
        // データを設定するなどの処理...

        // DataGridViewのCellClickイベントを処理
        dataGridView.CellClick += DataGridView_CellClick;

        // DataGridViewをフォームに配置
        Controls.Add(dataGridView);
    }

    private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        // クリックされた行のデータを取得
        DataGridViewRow clickedRow = dataGridView.Rows[e.RowIndex];

        // さらに詳細を表示するフォームの作成と表示
        DetailForm detailForm = new DetailForm(clickedRow);
        detailForm.ShowDialog();
    }
}

public class DetailForm : Form
{
    public DetailForm(DataGridViewRow row)
    {
        // フォームに詳細内容を表示するためのコントロールを追加する処理...
    }
}
*/