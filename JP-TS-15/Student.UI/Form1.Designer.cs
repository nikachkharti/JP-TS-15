namespace Student.UI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.headerLabel = new System.Windows.Forms.Label();
            this.TeachersGroup = new System.Windows.Forms.GroupBox();
            this.clearFormBtn = new System.Windows.Forms.Button();
            this.updateTeacherBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addTeacherBtn = new System.Windows.Forms.Button();
            this.DOBValue = new System.Windows.Forms.DateTimePicker();
            this.emailLabel = new System.Windows.Forms.Label();
            this.salaryLabel = new System.Windows.Forms.Label();
            this.pinLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.emailValue = new System.Windows.Forms.TextBox();
            this.DOBLabel = new System.Windows.Forms.Label();
            this.salaryValue = new System.Windows.Forms.TextBox();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.pinValue = new System.Windows.Forms.TextBox();
            this.lastNameValue = new System.Windows.Forms.TextBox();
            this.firstNameValue = new System.Windows.Forms.TextBox();
            this.TeachersList = new System.Windows.Forms.ListBox();
            this.TeachersGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Showcard Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.Orange;
            this.headerLabel.Location = new System.Drawing.Point(220, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(265, 44);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "STUDENTS APP";
            // 
            // TeachersGroup
            // 
            this.TeachersGroup.Controls.Add(this.clearFormBtn);
            this.TeachersGroup.Controls.Add(this.updateTeacherBtn);
            this.TeachersGroup.Controls.Add(this.deleteBtn);
            this.TeachersGroup.Controls.Add(this.addTeacherBtn);
            this.TeachersGroup.Controls.Add(this.DOBValue);
            this.TeachersGroup.Controls.Add(this.emailLabel);
            this.TeachersGroup.Controls.Add(this.salaryLabel);
            this.TeachersGroup.Controls.Add(this.pinLabel);
            this.TeachersGroup.Controls.Add(this.lastNameLabel);
            this.TeachersGroup.Controls.Add(this.emailValue);
            this.TeachersGroup.Controls.Add(this.DOBLabel);
            this.TeachersGroup.Controls.Add(this.salaryValue);
            this.TeachersGroup.Controls.Add(this.firstNameLabel);
            this.TeachersGroup.Controls.Add(this.pinValue);
            this.TeachersGroup.Controls.Add(this.lastNameValue);
            this.TeachersGroup.Controls.Add(this.firstNameValue);
            this.TeachersGroup.Controls.Add(this.TeachersList);
            this.TeachersGroup.Location = new System.Drawing.Point(12, 56);
            this.TeachersGroup.Name = "TeachersGroup";
            this.TeachersGroup.Size = new System.Drawing.Size(460, 486);
            this.TeachersGroup.TabIndex = 5;
            this.TeachersGroup.TabStop = false;
            this.TeachersGroup.Text = "მასწავლებლები";
            // 
            // clearFormBtn
            // 
            this.clearFormBtn.Location = new System.Drawing.Point(293, 457);
            this.clearFormBtn.Name = "clearFormBtn";
            this.clearFormBtn.Size = new System.Drawing.Size(161, 23);
            this.clearFormBtn.TabIndex = 4;
            this.clearFormBtn.Text = "ფორმის გასუფთავება";
            this.clearFormBtn.UseVisualStyleBackColor = true;
            // 
            // updateTeacherBtn
            // 
            this.updateTeacherBtn.Location = new System.Drawing.Point(87, 457);
            this.updateTeacherBtn.Name = "updateTeacherBtn";
            this.updateTeacherBtn.Size = new System.Drawing.Size(110, 23);
            this.updateTeacherBtn.TabIndex = 4;
            this.updateTeacherBtn.Text = "რედაქტირება";
            this.updateTeacherBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(203, 457);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 4;
            this.deleteBtn.Text = "წაშლა";
            this.deleteBtn.UseVisualStyleBackColor = true;
            // 
            // addTeacherBtn
            // 
            this.addTeacherBtn.Location = new System.Drawing.Point(6, 457);
            this.addTeacherBtn.Name = "addTeacherBtn";
            this.addTeacherBtn.Size = new System.Drawing.Size(75, 23);
            this.addTeacherBtn.TabIndex = 4;
            this.addTeacherBtn.Text = "დამატება";
            this.addTeacherBtn.UseVisualStyleBackColor = true;
            this.addTeacherBtn.Click += new System.EventHandler(this.addTeacherBtn_Click);
            // 
            // DOBValue
            // 
            this.DOBValue.Location = new System.Drawing.Point(6, 305);
            this.DOBValue.Name = "DOBValue";
            this.DOBValue.Size = new System.Drawing.Size(191, 23);
            this.DOBValue.TabIndex = 3;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(6, 354);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(73, 15);
            this.emailLabel.TabIndex = 2;
            this.emailLabel.Text = "ელ-ფოსტა";
            // 
            // salaryLabel
            // 
            this.salaryLabel.AutoSize = true;
            this.salaryLabel.Location = new System.Drawing.Point(263, 354);
            this.salaryLabel.Name = "salaryLabel";
            this.salaryLabel.Size = new System.Drawing.Size(64, 15);
            this.salaryLabel.TabIndex = 2;
            this.salaryLabel.Text = "ხელფასი";
            // 
            // pinLabel
            // 
            this.pinLabel.AutoSize = true;
            this.pinLabel.Location = new System.Drawing.Point(263, 287);
            this.pinLabel.Name = "pinLabel";
            this.pinLabel.Size = new System.Drawing.Size(101, 15);
            this.pinLabel.TabIndex = 2;
            this.pinLabel.Text = "პირადი ნომერი";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(263, 221);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(42, 15);
            this.lastNameLabel.TabIndex = 2;
            this.lastNameLabel.Text = "გვარი";
            // 
            // emailValue
            // 
            this.emailValue.Location = new System.Drawing.Point(6, 372);
            this.emailValue.Name = "emailValue";
            this.emailValue.Size = new System.Drawing.Size(191, 23);
            this.emailValue.TabIndex = 1;
            // 
            // DOBLabel
            // 
            this.DOBLabel.AutoSize = true;
            this.DOBLabel.Location = new System.Drawing.Point(6, 287);
            this.DOBLabel.Name = "DOBLabel";
            this.DOBLabel.Size = new System.Drawing.Size(83, 15);
            this.DOBLabel.TabIndex = 2;
            this.DOBLabel.Text = "დაბ.თარიღი";
            // 
            // salaryValue
            // 
            this.salaryValue.Location = new System.Drawing.Point(263, 372);
            this.salaryValue.Name = "salaryValue";
            this.salaryValue.Size = new System.Drawing.Size(191, 23);
            this.salaryValue.TabIndex = 1;
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(6, 221);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(53, 15);
            this.firstNameLabel.TabIndex = 2;
            this.firstNameLabel.Text = "სახელი";
            // 
            // pinValue
            // 
            this.pinValue.Location = new System.Drawing.Point(263, 305);
            this.pinValue.Name = "pinValue";
            this.pinValue.Size = new System.Drawing.Size(191, 23);
            this.pinValue.TabIndex = 1;
            // 
            // lastNameValue
            // 
            this.lastNameValue.Location = new System.Drawing.Point(263, 239);
            this.lastNameValue.Name = "lastNameValue";
            this.lastNameValue.Size = new System.Drawing.Size(191, 23);
            this.lastNameValue.TabIndex = 1;
            // 
            // firstNameValue
            // 
            this.firstNameValue.Location = new System.Drawing.Point(6, 239);
            this.firstNameValue.Name = "firstNameValue";
            this.firstNameValue.Size = new System.Drawing.Size(191, 23);
            this.firstNameValue.TabIndex = 1;
            // 
            // TeachersList
            // 
            this.TeachersList.FormattingEnabled = true;
            this.TeachersList.ItemHeight = 15;
            this.TeachersList.Location = new System.Drawing.Point(6, 34);
            this.TeachersList.Name = "TeachersList";
            this.TeachersList.Size = new System.Drawing.Size(448, 184);
            this.TeachersList.TabIndex = 0;
            this.TeachersList.SelectedIndexChanged += new System.EventHandler(this.TeachersList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 595);
            this.Controls.Add(this.TeachersGroup);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "სტუდენტები";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TeachersGroup.ResumeLayout(false);
            this.TeachersGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private GroupBox TeachersGroup;
        private ListBox TeachersList;
        private Label firstNameLabel;
        private TextBox firstNameValue;
        private Label lastNameLabel;
        private TextBox lastNameValue;
        private DateTimePicker DOBValue;
        private Label DOBLabel;
        private Label pinLabel;
        private TextBox pinValue;
        private Label salaryLabel;
        private TextBox salaryValue;
        private Label emailLabel;
        private TextBox emailValue;
        private Button addTeacherBtn;
        private Button updateTeacherBtn;
        private Button clearFormBtn;
        private Button deleteBtn;
    }
}