using FitnessTrackerApp.Service;
using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class LoginForm : Form
    {
        private readonly UserService userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text.Trim();
            string password = passwordField.Text.Trim();

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter username!");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter password!");
                return;
            }

            if (userService.Login(username, password))
            {
                this.Hide();

                MainForm mainForm = new MainForm(username);
                mainForm.Location = this.Location;
                mainForm.StartPosition = FormStartPosition.Manual;
                mainForm.FormClosing += (s, args) => Application.Exit();
                mainForm.ShowDialog();

                this.Dispose();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        private void lblSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            signUpForm.Location = this.Location;
            signUpForm.StartPosition = FormStartPosition.Manual;
            signUpForm.FormClosing += (s, args) => this.Show();
            signUpForm.Show();
            this.Hide();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        // Empty event handlers to avoid designer errors
        private void LoginForm_Load(object sender, EventArgs e) { }
        private void passwordField_TextChanged(object sender, EventArgs e) { }
        private void usernameField_TextChanged(object sender, EventArgs e) { }
    }
}