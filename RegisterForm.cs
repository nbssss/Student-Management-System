using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace StudentMangementSystem
{
    public partial class RegisterForm : Form
    {
        StudentClass student = new StudentClass();
        public RegisterForm()
        {
            StudentClass student = new StudentClass();
            InitializeComponent();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            // browse photo from computer
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select photo (*.jpg;*.png;*.gif)|*.jpg;*,png;*.gif";
      
            if (opf.ShowDialog() == DialogResult.OK) 
            {
                pictureBox_student.Image = Image.FromFile(opf.FileName);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            // przypisanie wartości pól do odpowiednich zmiennych
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            string phone = textBox_phone.Text;
            DateTime bdate = dateTimePicker1.Value;
            string gender = radioButton_male.Checked ? "Male" : "Female";
            string address = textBox_address.Text;

            int born_year = dateTimePicker1.Value.Year;
            int current_year = DateTime.Now.Year;

            if ( (current_year - born_year) < 10 || (current_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be beetwen 10 and 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ( verify() )
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    if ( student.insertStudent(fname, lname, bdate, gender, phone, address, img) )
                    {
                        showTable();
                        MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                } catch (Exception ex) 
                {  
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // fun to verify if the box is empty
        bool verify()
        {
            if (textBox_Fname.Text == "" || textBox_Lname.Text == "" || textBox_phone.Text == "" || 
                textBox_address.Text == "" || pictureBox_student.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            textBox_address.Clear();
        }
        
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
        
        // to show student list
        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentList(new MySqlCommand("SELECT * FROM `student`"));
            //DataGridView_student.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
    }
}
