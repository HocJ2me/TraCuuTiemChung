using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using QRCoder;

namespace TraCuuTiemChung
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        string userID = "";


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DangKiTiem frMain = new DangKiTiem(userID);
            frMain.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ThongTinTiem frMain = new ThongTinTiem();
            frMain.ShowDialog();
            this.Hide();
        }
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
        void getCovidJson()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string json = (new WebClient()).DownloadString("https://api.covid19api.com/live/country/vietnam/status/confirmed/date/2020-03-21T13:13:30Z");
            string data = JsonConvert.DeserializeObject(json).ToString();
            Console.WriteLine(data);
        }
        void creatQR()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("Mã ID sinh viên: " + userID, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            pic.Image = qrCode.GetGraphic(5);
        }
        public MainForm(string Message) : this()
        {
            userID = Message;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            creatQR();
            listVaccin();
            infoSV();
            getCovidJson();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
