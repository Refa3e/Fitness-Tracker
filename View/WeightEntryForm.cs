using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class WeightEntryForm : UserControl
    {
        private readonly string username;
        private readonly WeightEntryService weightService = new WeightEntryService();
        private readonly WorkoutService workoutService = new WorkoutService();
        private readonly CheatMealService cheatMealService = new CheatMealService();

        private bool isUpdateMode = false;
        private string currentGuid = "";

        public WeightEntryForm(string username)
        {
            this.username = username;
            InitializeComponent();
            RefreshForm();
        }

        private void RefreshForm()
        {
            WeightEntry latest = weightService.GetLatestEntry(username);
            txtWeight.Text = latest.Weight.ToString();

            datePickerWeightEntryDate.Value = DateTime.Now.Date;

            LoadTable();
            UpdateButtonText();
        }

        private void LoadTable()
        {
            dataGridViewWeightEntry.Rows.Clear();

            List<WeightEntry> entries = weightService.GetEntriesDescending(username);

            foreach (WeightEntry entry in entries)
            {
                dataGridViewWeightEntry.Rows.Add(
                    entry.Weight,
                    entry.Date.ToShortDateString(),
                    entry.GUID
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
                UpdateWeight();
            }
            else
            {
                SaveNewWeight();
            }
        }

        private void SaveNewWeight()
        {
            decimal weight = Convert.ToDecimal(txtWeight.Text);

            if (weight <= 0)
            {
                MessageBox.Show("Please enter valid weight!");
                return;
            }

            if (datePickerWeightEntryDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Invalid date!");
                return;
            }

            WeightEntry newEntry = new WeightEntry
            {
                UserName = username,
                Weight = weight,
                Date = datePickerWeightEntryDate.Value.Date
            };

            weightService.AddNewEntry(newEntry);
            MessageBox.Show("Weight saved successfully!");
            RefreshForm();
        }

        private void UpdateWeight()
        {
            decimal weight = Convert.ToDecimal(txtWeight.Text);

            if (weight <= 0)
            {
                MessageBox.Show("Please enter valid weight!");
                return;
            }

            WeightEntry updatedEntry = new WeightEntry
            {
                Weight = weight,
                Date = datePickerWeightEntryDate.Value.Date,
                UserName = username
            };

            weightService.UpdateEntry(updatedEntry, currentGuid);
            MessageBox.Show("Weight updated successfully!");
            isUpdateMode = false;
            RefreshForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridViewWeightEntry.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update!");
                return;
            }

            DataGridViewRow row = dataGridViewWeightEntry.SelectedRows[0];
            currentGuid = row.Cells[2].Value.ToString();

            txtWeight.Text = row.Cells[0].Value.ToString();
            datePickerWeightEntryDate.Value = Convert.ToDateTime(row.Cells[1].Value);

            isUpdateMode = true;
            UpdateButtonText();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewWeightEntry.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete this weight entry?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            string guid = dataGridViewWeightEntry.SelectedRows[0].Cells[2].Value.ToString();

            if (workoutService.IsWeightUsedInWorkout(guid))
            {
                MessageBox.Show("This weight is used in a workout. Delete the workout first!");
                return;
            }

            if (cheatMealService.IsWeightUsedInMeal(guid))
            {
                MessageBox.Show("This weight is used in a cheat meal. Delete the cheat meal first!");
                return;
            }

            weightService.DeleteEntry(guid);
            MessageBox.Show("Weight entry deleted successfully!");
            LoadTable();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            RefreshForm();
        }
    }
}