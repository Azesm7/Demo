using MySql.Data.MySqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DeveliriClab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            GC.Collect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string UserName = textBox1.Text;// ������ �� ���� ����� ������ ��� ������������
            string Password = textBox2.Text; //  ������ �� ���� ����� ������ ������
            BD db = new BD(); // ����������� ������ BD
            DataTable table = new DataTable(); // �������� ������� 
            MySqlDataAdapter adapter = new MySqlDataAdapter(); // �������� ������� 
            MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE `nick` = @UN AND `password` = @Pass", db.getConnection()); // ������� �� �������� � MySql
            command.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName; // ����������� �������� 
            command.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// ����������� �������� 
            adapter.SelectCommand = command; // ��������� ����� ������� ����� ��������� ,� ��������� 
            adapter.Fill(table); // �������� � ���������� � ����� ������ (� table)
            if (table.Rows.Count > 0) // �������� ������� ���� ������� 
            {

                string id = "";
                MySqlCommand command1 = new MySqlCommand("SELECT id FROM users WHERE `nick` = @UN AND `password` = @Pass", db.getConnection()); // ������� �� ����� � MySql
                command1.Parameters.Add("@UN", MySqlDbType.VarChar).Value = UserName; // ����������� �������� 
                command1.Parameters.Add("@Pass", MySqlDbType.VarChar).Value = Password;// ����������� �������� 
                db.openConnection(); // �����������
                MySqlDataReader reader = command1.ExecuteReader(); // �������� ������ � ������ ����� �������� ������
                List<string[]> data = new List<string[]>();//�������� ���������� ������
                if (reader.Read()) // ���� ������ ��� ������� ��
                {
                    data.Add(new string[1]); // ���������� ����� ������ � ������ 
                    id = reader[0].ToString(); // ��������� ������ ��� ������ ���������
                }
                reader.Close(); // �������� ������ 
                db.CloseConnection(); // ���������

                string Post = "";
                MySqlCommand command2 = new MySqlCommand("SELECT post_name FROM post WHERE `id_user` = @idus", db.getConnection()); // ������� �� ����� � MySql
                command2.Parameters.Add("@idus", MySqlDbType.VarChar).Value = id; // ����������� �������� 
                db.openConnection(); // �����������
                MySqlDataReader reader2 = command2.ExecuteReader(); // �������� ������ � ������ ����� �������� ������
                List<string[]> data2 = new List<string[]>();//�������� ���������� ������
                if (reader2.Read()) // ���� ������ ��� ������� ��
                {
                    data2.Add(new string[1]); // ���������� ����� ������ � ������ 
                    Post = reader2[0].ToString(); // ��������� ������ ��� ������ ���������
                }
                reader2.Close(); // �������� ������ 

                if (Post == "Admin")
                {
                    db.CloseConnection(); // ���������
                    this.Hide();
                    MessageBox.Show("����������� ������ �������");
                    Form4 form = new Form4();
                    //    form.ID1 = id;
                    form.ShowDialog();
                    GC.Collect();
                    Close();
                }
                else
                {

                    db.CloseConnection(); // ���������
                    this.Hide();
                    MessageBox.Show("����������� ������ �������");
                    Form3 form = new Form3();
                    form.ID1 = id;
                    form.ShowDialog();
                    GC.Collect();
                    Close();
                }
            }
            else // ���� ������� ���
            {
                MessageBox.Show("��� �� ���� �����");
            }
        }
    }
}