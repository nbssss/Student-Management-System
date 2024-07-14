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
using System.IO;

namespace StudentMangementSystem
{
    public partial class ManagerStudentForm : Form
    {
        StudentClass student = new StudentClass();
        public ManagerStudentForm()
        {
            InitializeComponent();
        }

        private void ManagerStudentForm_Load(object sender, EventArgs e)
        {
            showTable();
        }

        public void showTable()
        {
            DataGridView_student.DataSource = student.getStudentList(new MySqlCommand("SELECT `StdId` AS 'ID', `StdFirstName` AS 'First Name', `StdLastName` AS 'Last Name', `Birthdate`, `Gender`, `Phone`, `Address`, `Photo` FROM `student`"));
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        // display student data from student to textbox
        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            textBox_id.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            textBox_Fname.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            textBox_Lname.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Value = (DateTime)DataGridView_student.CurrentRow.Cells[3].Value;

            if (DataGridView_student.CurrentRow.Cells[4].Value.ToString() == "Male")
            {
                radioButton_male.Checked = true;
            }
            else
            {
                radioButton_female.Checked = true;
            }

            textBox_phone.Text = DataGridView_student.CurrentRow.Cells[5].Value.ToString();
            textBox_address.Text = DataGridView_student.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])DataGridView_student.CurrentRow.Cells[7].Value;

            MemoryStream ms = new MemoryStream(img);
            pictureBox_student.Image = Image.FromStream(ms);
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clear Start");
            textBox_Fname.Clear();
            textBox_Lname.Clear();
            textBox_phone.Clear();
            dateTimePicker1.Value = DateTime.Now;
            radioButton_male.Checked = true;
            textBox_address.Clear();
            textBox_id.Clear();
            pictureBox_student.Image = null;
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

        private void button_search_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = student.searchStudent(textBox_search.Text);
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            textBox_search.Clear();
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

        // fun to update student record
        private void button_update_Click(object sender, EventArgs e)
        {
            // przypisanie wartości pól do odpowiednich zmiennych
            int id = Convert.ToInt32(textBox_id.Text);
            string fname = textBox_Fname.Text;
            string lname = textBox_Lname.Text;
            string phone = textBox_phone.Text;
            DateTime bdate = dateTimePicker1.Value;
            string gender = radioButton_male.Checked ? "Male" : "Female";
            string address = textBox_address.Text;

            int born_year = dateTimePicker1.Value.Year;
            int current_year = DateTime.Now.Year;

            if ((current_year - born_year) < 10 || (current_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be beetwen 10 and 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (verify())
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox_student.Image.Save(ms, pictureBox_student.Image.RawFormat);
                    byte[] img = ms.ToArray();

                    if (student.updateStudent(id, fname, lname, bdate, gender, phone, address, img))
                    {
                        showTable();
                        MessageBox.Show("Student data update", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            // removing selected student
            int id = Convert.ToInt32(textBox_id.Text);

            if (MessageBox.Show("Are you sure you want to remove this student?", "Remove Student", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) 
            {
                if (student.deleteStudent(id))
                {
                    showTable();
                    MessageBox.Show("Student Removed", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("About to clear fields");
                    button_clear.PerformClick();
                    MessageBox.Show("Fields should be cleared now");
                }
            }
        }
    }
}
