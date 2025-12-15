using FitnessTrackerApp.Enumeration;
using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using FitnessTrackerApp.Utility;
using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class SignUpForm : Form
    {
        private readonly UserService userService = new UserService();
        private readonly WeightEntryService weightService = new WeightEntryService();

        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            Gender gender = (Gender)cmbGender.SelectedItem;
            decimal weight = Convert.ToDecimal(txtWeight.Text.Trim());
            decimal height = Convert.ToDecimal(txtHeight.Text.Trim());
            DateTime dob = datePickerDOB.Value.Date;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (weight <= 0 || height <= 0)
            {
                MessageBox.Show("Weight and height must be greater than zero!");
                return;
            }

            if (dob >= DateTime.Now.Date)
            {
                MessageBox.Show("Invalid date of birth!");
                return;
            }

            User newUser = new User
            {
                Name = name,
                UserName = username,
                Password = password,
                Height = height,
                Gender = gender,
                DateofBirth = dob
            };

            WeightEntry firstWeight = new WeightEntry
            {
                UserName = username,
                Weight = weight,
                Date = DateTime.Now.Date
            };

            try
            {
                userService.AddNewUser(newUser);
                weightService.AddNewEntry(firstWeight);

                MessageBox.Show("Account created successfully!");

                this.Hide();

                LoginForm loginForm = new LoginForm();
                loginForm.Location = this.Location;
                loginForm.StartPosition = FormStartPosition.Manual;
                loginForm.FormClosing += (s, args) => Application.Exit();
                loginForm.ShowDialog();

                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}