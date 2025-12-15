namespace FitnessTrackerApp.View
{
    partial class CheatMealForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtColories = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMealName = new System.Windows.Forms.Label();
            this.txtMealName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.MealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calories = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWeight = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.datePickerWeightEntryDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.Undoo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtColories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // txtColories
            // 
            this.txtColories.DecimalPlaces = 2;
            this.txtColories.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColories.Location = new System.Drawing.Point(170, 72);
            this.txtColories.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtColories.Name = "txtColories";
            this.txtColories.Size = new System.Drawing.Size(238, 30);
            this.txtColories.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 23);
            this.label2.TabIndex = 72;
            this.label2.Text = "Calories Gained :";
            // 
            // lblMealName
            // 
            this.lblMealName.AutoSize = true;
            this.lblMealName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMealName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMealName.Location = new System.Drawing.Point(59, 26);
            this.lblMealName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMealName.Name = "lblMealName";
            this.lblMealName.Size = new System.Drawing.Size(116, 23);
            this.lblMealName.TabIndex = 69;
            this.lblMealName.Text = "Meal Name:";
            // 
            // txtMealName
            // 
            this.txtMealName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMealName.Location = new System.Drawing.Point(170, 22);
            this.txtMealName.Margin = new System.Windows.Forms.Padding(4);
            this.txtMealName.Name = "txtMealName";
            this.txtMealName.Size = new System.Drawing.Size(238, 30);
            this.txtMealName.TabIndex = 68;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(764, 297);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(142, 34);
            this.btnDelete.TabIndex = 67;
            this.btnDelete.TabStop = false;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.btnUpdate.BackColor = System.Drawing.Color.Green;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(764, 237);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(142, 34);
            this.btnUpdate.TabIndex = 66;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(764, 140);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(142, 34);
            this.btnClear.TabIndex = 65;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MealName,
            this.Calories,
            this.weight,
            this.Date,
            this.GUID});
            this.dataGridView.Location = new System.Drawing.Point(69, 208);
            this.dataGridView.MultiSelect = false;
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(627, 392);
            this.dataGridView.TabIndex = 64;
            // 
            // MealName
            // 
            this.MealName.HeaderText = "Workout Name";
            this.MealName.MinimumWidth = 6;
            this.MealName.Name = "MealName";
            this.MealName.ReadOnly = true;
            this.MealName.Width = 125;
            // 
            // Calories
            // 
            this.Calories.HeaderText = "Calories Gained";
            this.Calories.MinimumWidth = 6;
            this.Calories.Name = "Calories";
            this.Calories.ReadOnly = true;
            this.Calories.Width = 125;
            // 
            // weight
            // 
            this.weight.HeaderText = "Weight (KG)";
            this.weight.MinimumWidth = 6;
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 125;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date Time";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 200;
            // 
            // GUID
            // 
            this.GUID.HeaderText = "GUID";
            this.GUID.MinimumWidth = 6;
            this.GUID.Name = "GUID";
            this.GUID.ReadOnly = true;
            this.GUID.Visible = false;
            this.GUID.Width = 125;
            // 
            // txtWeight
            // 
            this.txtWeight.DecimalPlaces = 2;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.Location = new System.Drawing.Point(668, 23);
            this.txtWeight.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(238, 30);
            this.txtWeight.TabIndex = 63;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(472, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 23);
            this.label6.TabIndex = 62;
            this.label6.Text = "Weight(KG) After Meal:";
            // 
            // datePickerWeightEntryDate
            // 
            this.datePickerWeightEntryDate.Cursor = System.Windows.Forms.Cursors.Default;
            this.datePickerWeightEntryDate.CustomFormat = "yyyy-MM-dd hh:mm:ss";
            this.datePickerWeightEntryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerWeightEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePickerWeightEntryDate.Location = new System.Drawing.Point(668, 72);
            this.datePickerWeightEntryDate.Name = "datePickerWeightEntryDate";
            this.datePickerWeightEntryDate.Size = new System.Drawing.Size(238, 30);
            this.datePickerWeightEntryDate.TabIndex = 61;
            this.datePickerWeightEntryDate.Value = new System.DateTime(2023, 7, 11, 3, 19, 57, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(541, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 23);
            this.label3.TabIndex = 60;
            this.label3.Text = "Date and Time:";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.BackColor = System.Drawing.Color.Blue;
            this.btnAddEntry.FlatAppearance.BorderSize = 0;
            this.btnAddEntry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddEntry.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEntry.ForeColor = System.Drawing.Color.White;
            this.btnAddEntry.Location = new System.Drawing.Point(582, 140);
            this.btnAddEntry.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(142, 34);
            this.btnAddEntry.TabIndex = 59;
            this.btnAddEntry.TabStop = false;
            this.btnAddEntry.Text = "Save";
            this.btnAddEntry.UseVisualStyleBackColor = false;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // Undoo
            // 
            this.Undoo.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.Undoo.BackColor = System.Drawing.Color.Gray;
            this.Undoo.FlatAppearance.BorderSize = 0;
            this.Undoo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Undoo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Undoo.ForeColor = System.Drawing.Color.White;
            this.Undoo.Location = new System.Drawing.Point(764, 360);
            this.Undoo.Margin = new System.Windows.Forms.Padding(4);
            this.Undoo.Name = "Undoo";
            this.Undoo.Size = new System.Drawing.Size(142, 34);
            this.Undoo.TabIndex = 74;
            this.Undoo.TabStop = false;
            this.Undoo.Text = "Undo";
            this.Undoo.UseVisualStyleBackColor = false;
            this.Undoo.Click += new System.EventHandler(this.Undoo_Click);
            // 
            // CheatMealForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Undoo);
            this.Controls.Add(this.txtColories);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMealName);
            this.Controls.Add(this.txtMealName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.txtWeight);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datePickerWeightEntryDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddEntry);
            this.Name = "CheatMealForm";
            this.Size = new System.Drawing.Size(959, 631);
            ((System.ComponentModel.ISupportInitialize)(this.txtColories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtColories;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMealName;
        private System.Windows.Forms.TextBox txtMealName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.NumericUpDown txtWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker datePickerWeightEntryDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.DataGridViewTextBoxColumn MealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calories;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.Button Undoo;
    }
}
