using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;

namespace StudentMangementSystem
{
    public partial class PrintStudent : Form
    {
        StudentClass student = new StudentClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintStudent()
        {
            InitializeComponent();
        }

        private void PrintStudent_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand("SELECT `StdId` AS 'ID', `StdFirstName` AS 'First Name', `StdLastName` AS 'Last Name', `Birthdate`, `Gender`, `Phone`, `Address`, `Photo` FROM `student`"));
        }

        // fun to show the student list in datagridview
        public void showData(MySqlCommand command)
        {
            DataGridView_student.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            DataGridView_student.DataSource = student.getList(command);

            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            // check the radio button
            string selectQuery;
            if (radioButton_all.Checked == true) 
            {
                selectQuery = "SELECT * FROM `student`";
            }
            else if (radioButton_male.Checked== true) 
            {
                selectQuery = "SELECT * FROM `student` WHERE `Gender` = 'Male'";
            }
            else
            {
                selectQuery = "SELECT * FROM `student` WHERE `Gender` = 'Female'";
            }
            showData(new MySqlCommand(selectQuery));
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            printer.Title = "NBS School Students list";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip; // tekst ograniczony do jednej linii | tekst nie będzie przycinany jęsli wykroczy poza granice prostokąta
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxlearn";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_student);
        }
    }
}
