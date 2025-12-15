using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class FoodForm : UserControl
    {
        private readonly string _userName;
        private bool _isUpdate = false;
        private string _guid;

        public FoodForm(string userName)
        {
            _userName = userName;
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {
            ClearInputs();
            LoadTable();
            UpdateButton();
            UpdateStats();
        }

        private void ClearInputs()
        {
            txtFoodName.Text = "";
            numCalories.Value = 0;
            numProtein.Value = 0;
            _isUpdate = false;
            _guid = "";
        }

        private void LoadTable()
        {
            dataGridView.Rows.Clear();
            var foods = FoodService.Instance.GetDescending(_userName);
            
            foreach (var food in foods)
            {
                dataGridView.Rows.Add(
                    food.FoodName,
                    food.Calories.ToString("F2"),
                    food.Protein.ToString("F2"),
                    food.DateCreated.ToString("yyyy-MM-dd"),
                    food.GUID
                );
            }
        }

        private void UpdateButton()
        {
            if (_isUpdate)
            {
                btnSave.Text = "Update";
                btnSave.BackColor = System.Drawing.Color.Green;
            }
            else
            {
                btnSave.Text = "Add Food";
                btnSave.BackColor = System.Drawing.Color.Blue;
            }
        }

        private void UpdateStats()
        {
            decimal totalCal = FoodService.Instance.GetTotalCalories(_userName);
            decimal totalProtein = FoodService.Instance.GetTotalProtein(_userName);
            int totalFoods = FoodService.Instance.GetDescending(_userName).Count;

            lblTotalCal.Text = $"Total Calories: {totalCal:F2}";
            lblTotalProtein.Text = $"Total Protein: {totalProtein:F2}g";
            lblTotalFoods.Text = $"Total Foods: {totalFoods}";
        }

        private void ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                throw new Exception("Please enter food name!");
            }

            if (numCalories.Value <= 0)
            {
                throw new Exception("Please enter valid calories!");
            }

            if (numProtein.Value < 0)
            {
                throw new Exception("Please enter valid protein!");
            }
        }

        private void Save()
        {
            try
            {
                ValidateInputs();

                var food = new FoodEntry
                {
                    FoodName = txtFoodName.Text.Trim(),
                    Calories = numCalories.Value,
                    Protein = numProtein.Value,
                    UserName = _userName
                };

                FoodService.Instance.Add(food);
                MessageBox.Show("Food entry added successfully!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void UpdateEntry()
        {
            try
            {
                ValidateInputs();

                var food = new FoodEntry
                {
                    GUID = _guid,
                    FoodName = txtFoodName.Text.Trim(),
                    Calories = numCalories.Value,
                    Protein = numProtein.Value,
                    UserName = _userName
                };

                FoodService.Instance.Update(food);
                MessageBox.Show("Food entry updated successfully!");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Delete()
        {
            var selectedRows = dataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select a food to delete!");
                return;
            }

            var result = MessageBox.Show("Are you sure you want to delete this food?", 
                "Confirm Delete", MessageBoxButtons.YesNo);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    var selectedRow = selectedRows[0];
                    string id = selectedRow.Cells[4].Value.ToString();
                    
                    FoodService.Instance.Delete(id);
                    MessageBox.Show("Food deleted successfully!");
                    Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void Edit()
        {
            var selectedRows = dataGridView.SelectedRows;
            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select a food to edit!");
                return;
            }

            var selectedRow = selectedRows[0];
            _guid = selectedRow.Cells[4].Value.ToString();
            
            var food = FoodService.Instance.GetById(_guid);
            if (food != null)
            {
                txtFoodName.Text = food.FoodName;
                numCalories.Value = food.Calories;
                numProtein.Value = food.Protein;
                _isUpdate = true;
                UpdateButton();
            }
        }

        // Event Handlers
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_isUpdate)
            {
                UpdateEntry();
            }
            else
            {
                Save();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                LoadTable();
            }
            else
            {
                dataGridView.Rows.Clear();
                var results = FoodService.Instance.SearchByName(_userName, searchTerm);
                
                foreach (var food in results)
                {
                    dataGridView.Rows.Add(
                        food.FoodName,
                        food.Calories.ToString("F2"),
                        food.Protein.ToString("F2"),
                        food.DateCreated.ToString("yyyy-MM-dd"),
                        food.GUID
                    );
                }
            }
        }
    }
}