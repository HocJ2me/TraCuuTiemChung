using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraCuuTiemChung
{
    public partial class DangKiTiem : Form
    {
        public DangKiTiem()
        {
            InitializeComponent();
        }

        string userID = "";
        private void listVaccin()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ql_vaccin;";
            // Select all
            string query = "SELECT * FROM vaccin";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 

                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(1) + userID);

                        if (reader.GetString(1) == userID)
                        {
                            ListViewItem lv = new ListViewItem(reader.GetString(0));
                            lv.SubItems.Add(reader.GetString(1));
                            lv.SubItems.Add(reader.GetString(2));
                            lv.SubItems.Add(reader.GetString(3));
                            Console.WriteLine(lv.ToString());
                            listView1.Items.Add(lv);


                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void infoSV()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ql_vaccin;";
            // Select all
            string query = "SELECT * FROM user";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // Success, now list 

                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetString(0) == userID)
                        {
                            lbName.Text = "Họ và tên: " + reader.GetString(1);
                            lbAdress.Text = "Địa chỉ: " + reader.GetString(2);
                            lbLevel.Text = "Trình độ sinh viên: " + reader.GetString(4);
                            lbClass.Text = "Lớp: " + reader.GetString(3);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ql_vaccin;";
            // Select all
            string query = "INSERT INTO `signupvaccin` (`id`, `iduser`, `date`) VALUES(NULL, '"+ userID + "', current_timestamp())";
            // Which could be translated manually to :
            // INSERT INTO user(`id`, `first_name`, `last_name`, `address`) VALUES (NULL, 'Bruce', 'Wayne', 'Wayne Manor')

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Gửi đơn đăng ký thành công");

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
            
        }

        public DangKiTiem(string Message) : this()
        {
            userID = Message;
        }
        private void DangKiTiem_Load(object sender, EventArgs e)
        {
            listVaccin();
            infoSV();
        }
    }
}
