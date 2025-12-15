using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class CheatMealForm : UserControl
    {
        private readonly string username;
        private readonly CheatMealService cheatMealService = new CheatMealService();
        private readonly WeightEntryService weightService = new WeightEntryService();

        private bool isUpdateMode = false;
        private string currentGuid = "";

        private Stack<CheatMealEntry> deletedMeals = new Stack<CheatMealEntry>();

        public CheatMealForm(string username)
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
            txtMealName.Text = "";
            txtColories.Text = "0.00";

            LoadTable();
            UpdateButtonText();
        }

        private void LoadTable()
        {
            dataGridView.Rows.Clear();

            List<CheatMealEntry> meals = cheatMealService.GetMealsDescending(username);

            foreach (CheatMealEntry meal in meals)
            {
                WeightEntry weight = weightService.GetEntryByGuid(meal.WeightEntryGUID);

                dataGridView.Rows.Add(
                    meal.MealName,
                    meal.Calories,
                    weight?.Weight ?? 0,
                    meal.Date.ToShortDateString(),
                    meal.GUID
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
                UpdateMeal();
            }
            else
            {
                SaveNewMeal();
            }
        }

        private void SaveNewMeal()
        {
            if (string.IsNullOrEmpty(txtMealName.Text.Trim()) ||
                Convert.ToDecimal(txtColories.Text) <= 0 ||
                Convert.ToDecimal(txtWeight.Text) <= 0 ||
                datePickerWeightEntryDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please fill all fields correctly and choose a valid date!");
                return;
            }

            CheatMealEntry newMeal = new CheatMealEntry
            {
                UserName = username,
                MealName = txtMealName.Text,
                Calories = Convert.ToDecimal(txtColories.Text),
                Date = datePickerWeightEntryDate.Value
            };

            WeightEntry newWeight = new WeightEntry
            {
                UserName = username,
                Weight = Convert.ToDecimal(txtWeight.Text),
                Date = datePickerWeightEntryDate.Value
            };

            cheatMealService.AddNewMeal(newMeal, newWeight);
            MessageBox.Show("Cheat meal added successfully!");
            RefreshForm();
        }

        private void UpdateMeal()
        {
            if (string.IsNullOrEmpty(txtMealName.Text.Trim()) ||
                Convert.ToDecimal(txtColories.Text) <= 0 ||
                Convert.ToDecimal(txtWeight.Text) <= 0 ||
                datePickerWeightEntryDate.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Please fill all fields correctly!");
                return;
            }

            CheatMealEntry meal = cheatMealService.GetMealByGuid(currentGuid);

            meal.MealName = txtMealName.Text;
            meal.Calories = Convert.ToDecimal(txtColories.Text);
            meal.Date = datePickerWeightEntryDate.Value;

            WeightEntry weight = new WeightEntry
            {
                UserName = username,
                Weight = Convert.ToDecimal(txtWeight.Text),
                Date = datePickerWeightEntryDate.Value
            };

            cheatMealService.UpdateMeal(meal, weight);
            MessageBox.Show("Cheat meal updated successfully!");
            isUpdateMode = false;
            RefreshForm();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
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
            currentGuid = row.Cells[4].Value.ToString();

            txtMealName.Text = row.Cells[0].Value.ToString();
            txtColories.Text = row.Cells[1].Value.ToString();
            txtWeight.Text = row.Cells[2].Value.ToString();
            datePickerWeightEntryDate.Value = Convert.ToDateTime(row.Cells[3].Value);

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

            if (MessageBox.Show("Are you sure you want to delete this cheat meal?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            string guid = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            CheatMealEntry meal = cheatMealService.GetMealByGuid(guid);

            deletedMeals.Push(meal);
            cheatMealService.DeleteMeal(guid);

            LoadTable();
            MessageBox.Show("Cheat meal deleted successfully!");
        }

        private void Undoo_Click(object sender, EventArgs e)
        {
            if (deletedMeals.Count == 0)
            {
                MessageBox.Show("Nothing to undo!");
                return;
            }

            CheatMealEntry meal = deletedMeals.Pop();

            WeightEntry weight = new WeightEntry
            {
                UserName = username,
                Date = meal.Date,
                Weight = weightService.GetLatestEntry(username).Weight
            };

            cheatMealService.AddNewMeal(meal, weight);
            LoadTable();
            MessageBox.Show("Undo successful!");
        }
    }
}