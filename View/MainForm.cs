using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class MainForm : Form
    {
        private readonly string _userName;

        public MainForm(string userName)
        {
            _userName = userName;
            InitializeComponent();

            // Remove unused tabs
            tabControl1.TabPages.Remove(tabReport);
            tabControl1.TabPages.Remove(tabPrediction);
            tabControl1.TabPages.Remove(tabDash);

            LoadProfileTab();
            LoadWeightEntryTab();
            LoadWorkoutEntryTab();
            LoadCheatMealEntryTab();
        }

        private void LoadCheatMealEntryTab()
        {
            var cheatMealForm = new CheatMealForm(this._userName);
            cheatMealForm.Dock = System.Windows.Forms.DockStyle.Fill;
            cheatMealForm.Location = new System.Drawing.Point(0, 0);
            cheatMealForm.Name = "CheatMealForm";
            cheatMealForm.Size = new System.Drawing.Size(1105, 592);
            cheatMealForm.TabIndex = 0;
            this.tabCheatMeal.Controls.Add(cheatMealForm);
        }

        private void LoadWorkoutEntryTab()
        {
            var workoutForm = new WorkoutForm(this._userName);
            workoutForm.Dock = System.Windows.Forms.DockStyle.Fill;
            workoutForm.Location = new System.Drawing.Point(0, 0);
            workoutForm.Name = "WorkoutForm";
            workoutForm.Size = new System.Drawing.Size(1105, 592);
            workoutForm.TabIndex = 0;
            this.tabWorkout.Controls.Add(workoutForm);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form = new LoginForm();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { Application.Exit(); };
            form.ShowDialog();
            this.Dispose();
        }

        private void LoadProfileTab()
        {
            var profileForm = new ProfileForm(this._userName);
            profileForm.Dock = System.Windows.Forms.DockStyle.Fill;
            profileForm.Location = new System.Drawing.Point(0, 0);
            profileForm.Name = "profileForm";
            profileForm.Size = new System.Drawing.Size(1105, 592);
            profileForm.TabIndex = 0;
            this.tabProfile.Controls.Add(profileForm);
        }

        private void LoadWeightEntryTab()
        {
            var weightEntryForm = new WeightEntryForm(this._userName);
            weightEntryForm.AutoScaleMode = AutoScaleMode.Dpi;
            weightEntryForm.Dock = System.Windows.Forms.DockStyle.Fill;
            weightEntryForm.Name = "weightEntryForm";

            this.tabWeight.AutoSize = true;
            this.tabWeight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.tabWeight.Controls.Add(weightEntryForm);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*TabControl tabControl = sender as TabControl;
            TabPage currentTabPage = tabControl.SelectedTab;

            Form form = currentTabPage.Controls[0] as Form;

            if (form != null && form.GetType() == typeof(WorkoutForm))
            {
                WorkoutForm workoutForm = (WorkoutForm)form;
                workoutForm.Clear(); // Assuming `Clear` is the correct method name in WorkoutForm
            }*/
        }
    }
}
