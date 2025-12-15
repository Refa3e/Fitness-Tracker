using FitnessTrackerApp.Enumeration;
using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using FitnessTrackerApp.Utility;
using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class ProfileForm : UserControl
    {
        private readonly string username;
        private readonly UserService userService = new UserService();
        private User user;

        public ProfileForm(string username)
        {
            this.username = username;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            user = userService.GetUserByName(username);

            txtUserName.Text = user.UserName;
            txtUserName.Enabled = false;

            txtName.Text = user.Name;
            txtHeight.Text = user.Height.ToString();
            datePickerDOB.Value = user.DateofBirth;
            cmbGender.SelectedItem = user.Gender;

            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            decimal height = Convert.ToDecimal(txtHeight.Text.Trim());
            Gender gender = (Gender)cmbGender.SelectedItem;
            DateTime dob = datePickerDOB.Value.Date;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter name!");
                return;
            }

            if (height <= 0)
            {
                MessageBox.Show("Please enter valid height!");
                return;
            }

            if (dob >= DateTime.Now.Date)
            {
                MessageBox.Show("Invalid date of birth!");
                return;
            }

            user.Name = name;
            user.Height = height;
            user.Gender = gender;
            user.DateofBirth = dob;

            userService.UpdateUser(user);
            MessageBox.Show("Profile updated successfully!");
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Please fill both password fields!");
                return;
            }

            if (password != confirm)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            user.Password = PasswordManager.GetSaltedHash(password);
            userService.UpdateUser(user);

            LoadData();
            MessageBox.Show("Password updated successfully!");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void lblSep_Click(object sender, EventArgs e)
        {
            // Empty event handler
        }
    }
}