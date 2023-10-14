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
            this.getAllTeachersBtn = new System.Windows.Forms.Button();
            this.studentIdValue = new System.Windows.Forms.TextBox();
            this.getSingleTeacherBtn = new System.Windows.Forms.Button();
            this.teacherName = new System.Windows.Forms.Label();
            this.StudentsGroup = new System.Windows.Forms.GroupBox();
            this.StudentsGroup.SuspendLayout();
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
            // getAllTeachersBtn
            // 
            this.getAllTeachersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getAllTeachersBtn.Location = new System.Drawing.Point(6, 33);
            this.getAllTeachersBtn.Name = "getAllTeachersBtn";
            this.getAllTeachersBtn.Size = new System.Drawing.Size(332, 32);
            this.getAllTeachersBtn.TabIndex = 1;
            this.getAllTeachersBtn.Text = "ყველა მასწავლებელი";
            this.getAllTeachersBtn.UseVisualStyleBackColor = true;
            this.getAllTeachersBtn.Click += new System.EventHandler(this.getAllTeachersBtn_Click);
            // 
            // studentIdValue
            // 
            this.studentIdValue.Location = new System.Drawing.Point(6, 71);
            this.studentIdValue.Name = "studentIdValue";
            this.studentIdValue.Size = new System.Drawing.Size(332, 23);
            this.studentIdValue.TabIndex = 2;
            // 
            // getSingleTeacherBtn
            // 
            this.getSingleTeacherBtn.Location = new System.Drawing.Point(6, 100);
            this.getSingleTeacherBtn.Name = "getSingleTeacherBtn";
            this.getSingleTeacherBtn.Size = new System.Drawing.Size(332, 23);
            this.getSingleTeacherBtn.TabIndex = 3;
            this.getSingleTeacherBtn.Text = "კონკრეტული მასწავლებელი";
            this.getSingleTeacherBtn.UseVisualStyleBackColor = true;
            this.getSingleTeacherBtn.Click += new System.EventHandler(this.getSingleTeacherBtn_Click);
            // 
            // teacherName
            // 
            this.teacherName.AutoSize = true;
            this.teacherName.Location = new System.Drawing.Point(6, 126);
            this.teacherName.Name = "teacherName";
            this.teacherName.Size = new System.Drawing.Size(150, 15);
            this.teacherName.TabIndex = 4;
            this.teacherName.Text = "ნაპოვნი მასწავლებელი";
            this.teacherName.Visible = false;
            // 
            // StudentsGroup
            // 
            this.StudentsGroup.Controls.Add(this.getAllTeachersBtn);
            this.StudentsGroup.Controls.Add(this.teacherName);
            this.StudentsGroup.Controls.Add(this.studentIdValue);
            this.StudentsGroup.Controls.Add(this.getSingleTeacherBtn);
            this.StudentsGroup.Location = new System.Drawing.Point(12, 56);
            this.StudentsGroup.Name = "StudentsGroup";
            this.StudentsGroup.Size = new System.Drawing.Size(344, 269);
            this.StudentsGroup.TabIndex = 5;
            this.StudentsGroup.TabStop = false;
            this.StudentsGroup.Text = "სტუდენტები";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 595);
            this.Controls.Add(this.StudentsGroup);
            this.Controls.Add(this.headerLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "სტუდენტები";
            this.StudentsGroup.ResumeLayout(false);
            this.StudentsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private Button getAllTeachersBtn;
        private TextBox studentIdValue;
        private Button getSingleTeacherBtn;
        private Label teacherName;
        private GroupBox StudentsGroup;
    }
}