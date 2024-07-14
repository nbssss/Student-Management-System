namespace StudentMangementSystem
{
    public partial class MainForm : Form
    {
        StudentClass student = new StudentClass();
        public MainForm()
        {
            InitializeComponent();
            customizeDesign();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            studentCount();
        }

        private void studentCount()
        {
            // display the labels
            label_totalStd.Text = "Total Students: " + student.totalStudent();
            label_maleStd.Text = "Male: " + student.maleStudent();
            label_femaleStd.Text = "Female: " + student.femaleStudent();
        }
        private void customizeDesign()
        {
            panel_stdSubmenu.Visible = false;
            panel_courseSubmenu.Visible = false;
            panel_scoreSubmenu.Visible = false;
        }
        private void hideSubmenu()
        {
            if (panel_stdSubmenu.Visible == true) 
            {
                panel_stdSubmenu.Visible = false;
            }

            if (panel_courseSubmenu.Visible == true)
            {
                panel_courseSubmenu.Visible = false;
            }

            if (panel_scoreSubmenu.Visible == true)
            {
                panel_scoreSubmenu.Visible = false;
            }
        }

        private void showSubmenu(Panel submenu) 
        {
            if (submenu.Visible == false) 
            {
                hideSubmenu();
                submenu.Visible = true;
            }
            else
            {
                submenu.Visible = false;
            }
        }

        private void button_std_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_stdSubmenu);
        }

        #region StdSubmenu
        private void button_registration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterForm());
            // ...

            hideSubmenu();
        }
        private void button_manageStd_Click(object sender, EventArgs e)
        {
            openChildForm(new ManagerStudentForm());
            // ...

            hideSubmenu();
        }
        private void button_status_Click(object sender, EventArgs e)
        {
            // ...

            hideSubmenu();
        }
        private void button_stdPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintStudent());
            // ...

            hideSubmenu();
        }
        #endregion StdSubmenu


        private void button_course_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_courseSubmenu);
        }
        
        #region CourseSubmenu
        private void button_newCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new CourseForm());
            
            // ...

            hideSubmenu();
        }
        private void button_manageCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageCourseFormcs());
            // ...

            hideSubmenu();
        }
        private void button_coursePrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCourseForm());

            // ...

            hideSubmenu();
        }

        #endregion CourseSubmenu

        private void button_score_Click(object sender, EventArgs e)
        {
            showSubmenu(panel_scoreSubmenu);
        }
        #region ScoreSubmenu
        private void button_newScore_Click(object sender, EventArgs e)
        {
            openChildForm(new ScoreForm());

            // ...

            hideSubmenu();
        }
        private void button_manageScore_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageScoreForm());

            // ...

            hideSubmenu();
        }
        private void button_scorePrint_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintScoreForm());
            // ...

            hideSubmenu();
        }
        #endregion ScoreSubmenu

        // showing dashboard
        /*
        private void button_exit_Click(object sender, EventArgs e)
        {
            // ...

            //hideSubmenu();
        }
        */
        // to show register form in mainform

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null) 
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            panel_main.Controls.Add(panel_cover);
            studentCount();
        }

        private void button_exit_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.Show();
        }
    }
}