using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;

namespace TraCuuTiemChung
{
    public partial class QuanLySinhVien : Form
    {
        public QuanLySinhVien()
        {
            InitializeComponent();
        }
        int numberSV = 0;
        int numberSVVaccin1 = 0;
        int numberSVVaccin2 = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        private void listSV()
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
                            numberSV++;
                            string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), 
                                                reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7) };
                            var listViewItem = new ListViewItem(row);
                            listView1.Items.Add(listViewItem);
                            if (reader.GetString(6) == "1")
                            {
                                numberSVVaccin1++;
                            }
                            if (reader.GetString(6) == "2")
                            {
                                numberSVVaccin2++;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                lbNumber1.Text = numberSV.ToString();
                lbNumber2.Text = numberSV.ToString();
                lbVaccin1.Text = numberSVVaccin1.ToString();
                lbVaccin2.Text = numberSVVaccin2.ToString();
                lbPredic1.Text = "Mũi 1: " + (numberSVVaccin1*100 / numberSV).ToString() + "%";
                lbPredic2.Text = "Mũi 2: " + (numberSVVaccin2*100 / numberSV).ToString() + "%";

                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void QuanLySinhVien_Load(object sender, EventArgs e)
        {
            listSV();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=ql_vaccin;";
            // Select all
            string query = "SELECT * FROM user";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            int numRes = 0;
        
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
                        if ((reader.GetString(0) == tboxID.Text) || (reader.GetString(1) == tboxName.Text) || (reader.GetString(2) == tboxAdd.Text))
                        {
                            numRes++;
                            string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                                reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7) };
                            var listViewItem = new ListViewItem(row);
                            listView1.Items.Add(listViewItem);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                MessageBox.Show("Có " + numRes.ToString() + " kết quả", "Kết quả");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(listView1.Columns.Count);

            pdfTable.DefaultCell.Padding = 0;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 0;
            
            //Write some text, the last character is 0x0278 - LATIN SMALL LETTER PHI
            PdfPCell cell = new PdfPCell(new Phrase("BAO CAO THONG TIN TIEM CHUNG CUA SINH VIEN"));
            cell.Colspan = 8;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.AddCell(cell);

            //Write some text, the last character is 0x0278 - LATIN SMALL LETTER PHI
            cell = new PdfPCell(new Phrase("SU DUNG PHAN MEM QUAN LY TIEM VACCIN"));
            cell.Colspan = 8;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.AddCell(cell);
            //Write some more text, the last character is 0x0682 - ARABIC LETTER HAH WITH TWO DOTS VERTICAL ABOVE


            pdfTable.DefaultCell.Padding = 0;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 0;

            //Write some text, the last character is 0x0278 - LATIN SMALL LETTER PHI
            cell = new PdfPCell(new Phrase("Danh sach sinh vien"));
            cell.Colspan = 8;
            cell.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.AddCell(cell);



            pdfTable.DefaultCell.Padding = 10;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;


            //Adding Header row
            foreach (ColumnHeader column in listView1.Columns)
            {
                 cell = new PdfPCell(new Phrase(column.Text));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (ListViewItem itemRow in listView1.Items)
            {
                int i = 0;
                for (i = 0; i < itemRow.SubItems.Count ; i++)
                {
                    pdfTable.AddCell(itemRow.SubItems[i].Text);
                }
            }

            //Exporting to PDF
            string folderPath = @"D:/QuanLyVaccin/";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "fileDuLieu.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("Đã tạo báo cáo vào địa chỉ D:/QuanLyVaccin/fileDuLieu.pdf");
        }
    }
}
