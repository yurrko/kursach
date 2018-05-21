namespace admission_office
{
    partial class NewEntrant
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbExamRes3 = new System.Windows.Forms.TextBox();
            this.tbExamRes2 = new System.Windows.Forms.TextBox();
            this.tbExamRes1 = new System.Windows.Forms.TextBox();
            this.lblExam3 = new System.Windows.Forms.Label();
            this.lblExam2 = new System.Windows.Forms.Label();
            this.cbExam3 = new System.Windows.Forms.ComboBox();
            this.cbExam2 = new System.Windows.Forms.ComboBox();
            this.cbExam1 = new System.Windows.Forms.ComboBox();
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.lblExam1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblMidName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbExamRes3
            // 
            this.tbExamRes3.Location = new System.Drawing.Point(310, 144);
            this.tbExamRes3.Name = "tbExamRes3";
            this.tbExamRes3.Size = new System.Drawing.Size(57, 22);
            this.tbExamRes3.TabIndex = 36;
            this.tbExamRes3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExamRes3_KeyPress);
            // 
            // tbExamRes2
            // 
            this.tbExamRes2.Location = new System.Drawing.Point(310, 89);
            this.tbExamRes2.Name = "tbExamRes2";
            this.tbExamRes2.Size = new System.Drawing.Size(57, 22);
            this.tbExamRes2.TabIndex = 35;
            this.tbExamRes2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExamRes2_KeyPress);
            // 
            // tbExamRes1
            // 
            this.tbExamRes1.Location = new System.Drawing.Point(310, 33);
            this.tbExamRes1.Name = "tbExamRes1";
            this.tbExamRes1.Size = new System.Drawing.Size(57, 22);
            this.tbExamRes1.TabIndex = 34;
            this.tbExamRes1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExamRes1_KeyPress);
            // 
            // lblExam3
            // 
            this.lblExam3.AutoSize = true;
            this.lblExam3.Location = new System.Drawing.Point(164, 118);
            this.lblExam3.Name = "lblExam3";
            this.lblExam3.Size = new System.Drawing.Size(76, 17);
            this.lblExam3.TabIndex = 33;
            this.lblExam3.Text = "Экзамен 3";
            // 
            // lblExam2
            // 
            this.lblExam2.AutoSize = true;
            this.lblExam2.Location = new System.Drawing.Point(164, 66);
            this.lblExam2.Name = "lblExam2";
            this.lblExam2.Size = new System.Drawing.Size(76, 17);
            this.lblExam2.TabIndex = 32;
            this.lblExam2.Text = "Экзамен 2";
            // 
            // cbExam3
            // 
            this.cbExam3.FormattingEnabled = true;
            this.cbExam3.Location = new System.Drawing.Point(167, 144);
            this.cbExam3.Name = "cbExam3";
            this.cbExam3.Size = new System.Drawing.Size(121, 24);
            this.cbExam3.TabIndex = 31;
            // 
            // cbExam2
            // 
            this.cbExam2.FormattingEnabled = true;
            this.cbExam2.Location = new System.Drawing.Point(167, 89);
            this.cbExam2.Name = "cbExam2";
            this.cbExam2.Size = new System.Drawing.Size(121, 24);
            this.cbExam2.TabIndex = 30;
            // 
            // cbExam1
            // 
            this.cbExam1.FormattingEnabled = true;
            this.cbExam1.Location = new System.Drawing.Point(167, 33);
            this.cbExam1.Name = "cbExam1";
            this.cbExam1.Size = new System.Drawing.Size(121, 24);
            this.cbExam1.TabIndex = 29;
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.CustomFormat = "yyyy.MM.dd";
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthdate.Location = new System.Drawing.Point(20, 209);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(116, 22);
            this.dtpBirthdate.TabIndex = 28;
            // 
            // lblExam1
            // 
            this.lblExam1.AutoSize = true;
            this.lblExam1.Location = new System.Drawing.Point(164, 10);
            this.lblExam1.Name = "lblExam1";
            this.lblExam1.Size = new System.Drawing.Size(76, 17);
            this.lblExam1.TabIndex = 27;
            this.lblExam1.Text = "Экзамен 1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 278);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 27);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(17, 178);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(111, 17);
            this.lblBirthDate.TabIndex = 25;
            this.lblBirthDate.Text = "Дата рождения";
            // 
            // lblMidName
            // 
            this.lblMidName.AutoSize = true;
            this.lblMidName.Location = new System.Drawing.Point(17, 118);
            this.lblMidName.Name = "lblMidName";
            this.lblMidName.Size = new System.Drawing.Size(71, 17);
            this.lblMidName.TabIndex = 24;
            this.lblMidName.Text = "Отчество";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(17, 66);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(35, 17);
            this.lblFirstName.TabIndex = 23;
            this.lblFirstName.Text = "Имя";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(17, 10);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(70, 17);
            this.lblLastName.TabIndex = 22;
            this.lblLastName.Text = "Фамилия";
            // 
            // tbMiddleName
            // 
            this.tbMiddleName.Location = new System.Drawing.Point(17, 144);
            this.tbMiddleName.Name = "tbMiddleName";
            this.tbMiddleName.Size = new System.Drawing.Size(100, 22);
            this.tbMiddleName.TabIndex = 21;
            // 
            // tbFirstName
            // 
            this.tbFirstName.Location = new System.Drawing.Point(17, 89);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(100, 22);
            this.tbFirstName.TabIndex = 20;
            // 
            // tbLastname
            // 
            this.tbLastname.Location = new System.Drawing.Point(17, 33);
            this.tbLastname.Name = "tbLastname";
            this.tbLastname.Size = new System.Drawing.Size(100, 22);
            this.tbLastname.TabIndex = 19;
            // 
            // NewEntrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbExamRes3);
            this.Controls.Add(this.tbExamRes2);
            this.Controls.Add(this.tbExamRes1);
            this.Controls.Add(this.lblExam3);
            this.Controls.Add(this.lblExam2);
            this.Controls.Add(this.cbExam3);
            this.Controls.Add(this.cbExam2);
            this.Controls.Add(this.cbExam1);
            this.Controls.Add(this.dtpBirthdate);
            this.Controls.Add(this.lblExam1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.lblMidName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.tbMiddleName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.tbLastname);
            this.Name = "NewEntrant";
            this.Size = new System.Drawing.Size(386, 313);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbExamRes3;
        private System.Windows.Forms.TextBox tbExamRes2;
        private System.Windows.Forms.TextBox tbExamRes1;
        private System.Windows.Forms.Label lblExam3;
        private System.Windows.Forms.Label lblExam2;
        private System.Windows.Forms.ComboBox cbExam3;
        private System.Windows.Forms.ComboBox cbExam2;
        private System.Windows.Forms.ComboBox cbExam1;
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Label lblExam1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblMidName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox tbMiddleName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastname;
    }
}
