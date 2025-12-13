using System;
using System.Windows.Forms;

namespace FitnessTrackerApp.View
{
    public partial class MainForm : Form
    {

       
        private readonly string _userName;
        public MainForm(string UserName)
        {
            _userName = UserName;
            InitializeComponent();

            tabControl1.TabPages.Remove(tabReport); 
            tabControl1.TabPages.Remove(tabPrediction);
            LoadProfileTab();
            LoadWeightEntryTab();
            LoadWorkoutEntryTab();
            LoadCheatMealEntryTab();
            LoadDashboardTab();
        }

        private void LoadDashboardTab()
        {
            var Form = new DashBoardForm(this._userName);
            Form.Dock = System.Windows.Forms.DockStyle.Fill;
            Form.Location = new System.Drawing.Point(0, 0);
            Form.Name = "DashBoardForm";
            Form.Size = new System.Drawing.Size(1105, 592);
            Form.TabIndex = 0;
            this.tabDash.Controls.Add(Form);
        }

     

      

        private void LoadCheatMealEntryTab()
        {
            var Form = new CheatMealForm(this._userName);
            Form.Dock = System.Windows.Forms.DockStyle.Fill;
            Form.Location = new System.Drawing.Point(0, 0);
            Form.Name = "CheatMealForm";
            Form.Size = new System.Drawing.Size(1105, 592);
            Form.TabIndex = 0;
            this.tabCheatMeal.Controls.Add(Form);
        }

        private void LoadWorkoutEntryTab()
        {
            var Form = new WorkoutForm(this._userName);
            Form.Dock = System.Windows.Forms.DockStyle.Fill;
            Form.Location = new System.Drawing.Point(0, 0);
            Form.Name = "WorkoutForm";
            Form.Size = new System.Drawing.Size(1105, 592);
            Form.TabIndex = 0;
            this.tabWorkout.Controls.Add(Form);
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
