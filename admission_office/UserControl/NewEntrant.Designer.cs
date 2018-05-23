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
            this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblMidName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.tbMiddleName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.tbLastname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblSpec = new System.Windows.Forms.Label();
            this.cbSpec = new System.Windows.Forms.ComboBox();
            this.cbEduType = new System.Windows.Forms.ComboBox();
            this.lblEduType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpBirthdate
            // 
            this.dtpBirthdate.CustomFormat = "yyyy.MM.dd";
            this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthdate.Location = new System.Drawing.Point(20, 203);
            this.dtpBirthdate.Name = "dtpBirthdate";
            this.dtpBirthdate.Size = new System.Drawing.Size(116, 22);
            this.dtpBirthdate.TabIndex = 28;
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
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(169, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 45);
            this.panel1.TabIndex = 37;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(169, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 45);
            this.panel2.TabIndex = 38;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(169, 121);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 45);
            this.panel3.TabIndex = 39;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(169, 178);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(109, 17);
            this.lblSpec.TabIndex = 40;
            this.lblSpec.Text = "Специальность";
            // 
            // cbSpec
            // 
            this.cbSpec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpec.FormattingEnabled = true;
            this.cbSpec.Location = new System.Drawing.Point(169, 202);
            this.cbSpec.Name = "cbSpec";
            this.cbSpec.Size = new System.Drawing.Size(200, 24);
            this.cbSpec.TabIndex = 41;
            // 
            // cbEduType
            // 
            this.cbEduType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEduType.FormattingEnabled = true;
            this.cbEduType.Location = new System.Drawing.Point(169, 262);
            this.cbEduType.Name = "cbEduType";
            this.cbEduType.Size = new System.Drawing.Size(200, 24);
            this.cbEduType.TabIndex = 43;
            // 
            // lblEduType
            // 
            this.lblEduType.AutoSize = true;
            this.lblEduType.Location = new System.Drawing.Point(169, 238);
            this.lblEduType.Name = "lblEduType";
            this.lblEduType.Size = new System.Drawing.Size(118, 17);
            this.lblEduType.TabIndex = 42;
            this.lblEduType.Text = "Бюджет/Договор";
            // 
            // NewEntrant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbEduType);
            this.Controls.Add(this.lblEduType);
            this.Controls.Add(this.cbSpec);
            this.Controls.Add(this.lblSpec);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpBirthdate);
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
        private System.Windows.Forms.DateTimePicker dtpBirthdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblMidName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox tbMiddleName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.TextBox tbLastname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.ComboBox cbSpec;
        private System.Windows.Forms.ComboBox cbEduType;
        private System.Windows.Forms.Label lblEduType;
    }
}
