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

namespace StudentMangementSystem
{
    public partial class ScoreForm : Form
    {
        CourseClass course = new CourseClass();
        StudentClass student = new StudentClass();
        ScoreClass score = new ScoreClass();
        public ScoreForm()
        {
            InitializeComponent();
        }

        // fun to show data on DataGridView score
        private void showScore()
        {
            DataGridView_student.DataSource = score.getList(new MySqlCommand("SELECT score.StudentId AS 'ID', student.StdFirstName AS 'First Name', student.StdLastName AS 'Last Name', score.CourseName AS 'Course Name', score.Score, score.Description FROM student INNER JOIN score ON score.StudentId=student.StdId"));
        }
        private void ScoreForm_Load(object sender, EventArgs e)
        {
            comboBox_course.DataSource = course.getCourse(new MySqlCommand("SELECT * FROM `course`"));
            comboBox_course.DisplayMember = "CourseName";
            comboBox_course.ValueMember = "CourseName";

            // to display student list on DataGridView
            DataGridView_student.DataSource = student.getList(new MySqlCommand("SELECT `StdId` AS 'ID', `StdFirstName` AS 'First Name', `StdLastName` AS 'Last Name' FROM `student`"));
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_stdId.Text == "" || textBox_score.Text == "")
            {
                MessageBox.Show("Need Score data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int stdId = Convert.ToInt32(textBox_stdId.Text);
                string cName = comboBox_course.Text;
                double sco = Convert.ToDouble(textBox_score.Text);
                string desc = textBox_description.Text;

                if (!score.checkScore(stdId, cName))
                {
                    if (score.insertScore(stdId, cName, sco, desc))
                    {
                        button_clear.PerformClick();
                        MessageBox.Show("New score added", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Score not inserted", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("The score for this course already exists", "Add Score", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            textBox_stdId.Clear();
            textBox_score.Clear();
            textBox_description.Clear();
            comboBox_course.SelectedIndex = 0;
        }

        private void DataGridView_student_Click(object sender, DataGridViewCellEventArgs e)
        {
            textBox_stdId.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
        }

        private void button_sStudent_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = student.getList(new MySqlCommand("SELECT `StdId` AS 'ID', `StdFirstName` AS 'First Name', `StdLastName` AS 'Last Name' FROM `student`"));
        }

        private void button_sScore_Click(object sender, EventArgs e)
        {
            showScore();
        }
    }
}
