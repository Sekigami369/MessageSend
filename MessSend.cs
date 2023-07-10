using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Security.Permissions;

namespace MessageSend
{
    public partial class MessSend : Form
    {
        public MessSend()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("�o�^���Ă���낵���ł����H", "�m�F", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string messtitleValue = textBox1.Text;
                string usernameValue = textBox2.Text;
                string messageValue = textBox4.Text;

                using (SqlConnection connection = DbConn.GetConnecton())
                {
                    string query = "INSERT INTO MessageInfo (messtitle, username, message_)VALUES(@messtitle, @username, @message_);";
                    //�ڑ��������ݒ�t�B�����ŕۑ����Ďg�������ς���
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@messtitle", messtitleValue);
                        command.Parameters.AddWithValue("@username", usernameValue);
                        command.Parameters.AddWithValue("@message_", messageValue);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("���b�Z�[�W���o�^����܂���");
                            this.Close();
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //button2.FlatAppearance.BorderColor = Color.CornflowerBlue;
            //button2.FlatAppearance.BorderSize = 6;
            this.Close();
        }
    }
}