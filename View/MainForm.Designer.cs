namespace FitnessTrackerApp.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabPrediction = new System.Windows.Forms.TabPage();
            this.tabReport = new System.Windows.Forms.TabPage();
            this.tabWeight = new System.Windows.Forms.TabPage();
            this.tabCheatMeal = new System.Windows.Forms.TabPage();
            this.tabWorkout = new System.Windows.Forms.TabPage();
            this.tabDash = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Location = new System.Drawing.Point(900, -2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(74, 28);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // tabProfile
            // 
            this.tabProfile.Location = new System.Drawing.Point(4, 25);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(966, 592);
            this.tabProfile.TabIndex = 3;
            this.tabProfile.Text = "Profile";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // tabPrediction
            // 
            this.tabPrediction.Location = new System.Drawing.Point(4, 25);
            this.tabPrediction.Name = "tabPrediction";
            this.tabPrediction.Size = new System.Drawing.Size(966, 592);
            this.tabPrediction.TabIndex = 6;
            this.tabPrediction.Text = "Prediction";
            this.tabPrediction.UseVisualStyleBackColor = true;
            // 
            // tabReport
            // 
            this.tabReport.Location = new System.Drawing.Point(4, 25);
            this.tabReport.Name = "tabReport";
            this.tabReport.Size = new System.Drawing.Size(966, 592);
            this.tabReport.TabIndex = 5;
            this.tabReport.Text = "Reports";
            this.tabReport.UseVisualStyleBackColor = true;
            // 
            // tabWeight
            // 
            this.tabWeight.Location = new System.Drawing.Point(4, 25);
            this.tabWeight.Name = "tabWeight";
            this.tabWeight.Size = new System.Drawing.Size(966, 592);
            this.tabWeight.TabIndex = 4;
            this.tabWeight.Text = "Weight";
            this.tabWeight.UseVisualStyleBackColor = true;
            // 
            // tabCheatMeal
            // 
            this.tabCheatMeal.Location = new System.Drawing.Point(4, 25);
            this.tabCheatMeal.Name = "tabCheatMeal";
            this.tabCheatMeal.Size = new System.Drawing.Size(966, 592);
            this.tabCheatMeal.TabIndex = 2;
            this.tabCheatMeal.Text = "Cheat Meal";
            this.tabCheatMeal.UseVisualStyleBackColor = true;
            // 
            // tabWorkout
            // 
            this.tabWorkout.Location = new System.Drawing.Point(4, 25);
            this.tabWorkout.Name = "tabWorkout";
            this.tabWorkout.Padding = new System.Windows.Forms.Padding(3);
            this.tabWorkout.Size = new System.Drawing.Size(966, 592);
            this.tabWorkout.TabIndex = 1;
            this.tabWorkout.Text = "Workout";
            this.tabWorkout.UseVisualStyleBackColor = true;
            // 
            // tabDash
            // 
            this.tabDash.Location = new System.Drawing.Point(4, 25);
            this.tabDash.Name = "tabDash";
            this.tabDash.Size = new System.Drawing.Size(966, 592);
            this.tabDash.TabIndex = 7;
            this.tabDash.Text = "Dashboard";
            this.tabDash.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDash);
            this.tabControl1.Controls.Add(this.tabWorkout);
            this.tabControl1.Controls.Add(this.tabCheatMeal);
            this.tabControl1.Controls.Add(this.tabWeight);
            this.tabControl1.Controls.Add(this.tabReport);
            this.tabControl1.Controls.Add(this.tabPrediction);
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(974, 621);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 620);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Personal Fitness Tracker App";
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabPrediction;
        private System.Windows.Forms.TabPage tabReport;
        private System.Windows.Forms.TabPage tabWeight;
        private System.Windows.Forms.TabPage tabCheatMeal;
        private System.Windows.Forms.TabPage tabWorkout;
        private System.Windows.Forms.TabPage tabDash;
        private System.Windows.Forms.TabControl tabControl1;
    }
}