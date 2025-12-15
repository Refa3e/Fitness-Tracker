using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using FitnessTrackerApp.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class WorkoutForm : UserControl
    {
        private readonly string username;
        private readonly WorkoutService workoutService = new WorkoutService();
        private readonly WeightEntryService weightService = new WeightEntryService();

        private bool isUpdateMode = false;
        private string currentGuid = "";

        public WorkoutForm(string username)
        {
            this.username = username;
            InitializeComponent();
            RefreshForm();
        }

        private void RefreshForm()
        {
            WeightEntry latest = weightService.GetLatestEntry(username);
            txtWeight.Text = latest.Weight.ToString();

            datePickerWeightEntryDate.Value = DateTime.Now;
            txtWorkoutName.Text = "";
            txtColoriesBurnt.Text = "0.00";
            cmbIntensity.DataSource = Util.GetIntensityTypes();

            LoadTable();
            UpdateButtonText();
        }

        private void LoadTable()
        {
            dataGridView.Rows.Clear();

            List<WorkoutEntry> workouts = workoutService.GetWorkoutsDescending(username);

            foreach (WorkoutEntry workout in workouts)
            {
                WeightEntry weight = weightService.GetEntryByGuid(workout.WeightEntryGUID);

                dataGridView.Rows.Add(
                    workout.WorkoutName,
                    workout.Intensity,
                    workout.CaloriesBurned,
                    weight?.Weight ?? 0,
                    workout.Date.ToShortDateString(),
                    workout.GUID
                );
            }
        }

        private void UpdateButtonText()
        {
            if (isUpdateMode)
            {
                btnAddEntry.Text = "Update";
                btnAddEntry.BackColor = Color.Green;
            }
            else
            {
                btnAddEntry.Text = "Save";
                btnAddEntry.BackColor = Color.Blue;
            }
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            if (isUpdateMode)
            {
                UpdateWorkout();
            }
            else
            {
                SaveNewWorkout();
            }
        }

        private void SaveNewWorkout()
        {
            if (string.IsNullOrEmpty(txtWorkoutName.Text.Trim()) ||
                Convert.ToDecimal(txtColoriesBurnt.Text) <= 0 ||
                Convert.ToDecimal(txtWeight.Text) <= 0 ||
                string.IsNullOrEmpty(cmbIntensity.Text) ||
                datePickerWeightEntryDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please fill all fields correctly and choose a valid date!");
                return;
            }

            WorkoutEntry newWorkout = new WorkoutEntry
            {
                UserName = username,
                WorkoutName = txtWorkoutName.Text,
                Intensity = cmbIntensity.Text,
                CaloriesBurned = Convert.ToDecimal(txtColoriesBurnt.Text),
                Date = datePickerWeightEntryDate.Value
            };

            WeightEntry newWeight = new WeightEntry
            {
                UserName = username,
                Weight = Convert.ToDecimal(txtWeight.Text),
                Date = datePickerWeightEntryDate.Value
            };

            workoutService.AddNewWorkout(newWorkout, newWeight);
            MessageBox.Show("Workout saved successfully!");
            RefreshForm();
        }

        private void UpdateWorkout()
        {
            if (string.IsNullOrEmpty(txtWorkoutName.Text.Trim()) ||
                Convert.ToDecimal(txtColoriesBurnt.Text) <= 0 ||
                Convert.ToDecimal(txtWeight.Text) <= 0 ||
                string.IsNullOrEmpty(cmbIntensity.Text))
            {
                MessageBox.Show("Please fill all fields correctly!");
                return;
            }

            WorkoutEntry workout = workoutService.GetWorkoutByGuid(currentGuid);

            workout.WorkoutName = txtWorkoutName.Text;
            workout.Intensity = cmbIntensity.Text;
            workout.CaloriesBurned = Convert.ToDecimal(txtColoriesBurnt.Text);
            workout.Date = datePickerWeightEntryDate.Value;

            WeightEntry weight = new WeightEntry
            {
                UserName = username,
                Weight = Convert.ToDecimal(txtWeight.Text),
                Date = datePickerWeightEntryDate.Value
            };

            workoutService.UpdateWorkout(workout, weight);
            MessageBox.Show("Workout updated successfully!");
            isUpdateMode = false;
            RefreshForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update!");
                return;
            }

            DataGridViewRow row = dataGridView.SelectedRows[0];
            currentGuid = row.Cells[5].Value.ToString();

            txtWorkoutName.Text = row.Cells[0].Value.ToString();
            cmbIntensity.Text = row.Cells[1].Value.ToString();
            txtColoriesBurnt.Text = row.Cells[2].Value.ToString();
            txtWeight.Text = row.Cells[3].Value.ToString();
            datePickerWeightEntryDate.Value = Convert.ToDateTime(row.Cells[4].Value);

            isUpdateMode = true;
            UpdateButtonText();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this workout?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            string guid = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            workoutService.DeleteWorkout(guid);

            MessageBox.Show("Workout deleted successfully!");
            LoadTable();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void WorkoutForm_Load(object sender, EventArgs e)
        {
            // Empty handler for designer
        }
    }
}