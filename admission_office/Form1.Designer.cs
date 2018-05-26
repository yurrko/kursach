namespace admission_office
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.btnAuthorize = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.cbSelectDB = new System.Windows.Forms.ComboBox();
            this.lblSelectDB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(35, 40);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(100, 22);
            this.tbLogin.TabIndex = 0;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(35, 101);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(100, 22);
            this.tbPass.TabIndex = 1;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // btnAuthorize
            // 
            this.btnAuthorize.Location = new System.Drawing.Point(35, 139);
            this.btnAuthorize.Name = "btnAuthorize";
            this.btnAuthorize.Size = new System.Drawing.Size(75, 23);
            this.btnAuthorize.TabIndex = 2;
            this.btnAuthorize.Text = "Войти";
            this.btnAuthorize.UseVisualStyleBackColor = true;
            this.btnAuthorize.Click += new System.EventHandler(this.btnAuthorize_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(35, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 17);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Логин";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(35, 78);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(57, 17);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Пароль";
            // 
            // cbSelectDB
            // 
            this.cbSelectDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectDB.Items.AddRange(new object[] {
            "Продуктивная БД",
            "Архивная БД"});
            this.cbSelectDB.Location = new System.Drawing.Point(35, 239);
            this.cbSelectDB.Name = "cbSelectDB";
            this.cbSelectDB.Size = new System.Drawing.Size(197, 24);
            this.cbSelectDB.TabIndex = 0;
            // 
            // lblSelectDB
            // 
            this.lblSelectDB.AutoSize = true;
            this.lblSelectDB.Location = new System.Drawing.Point(36, 209);
            this.lblSelectDB.Name = "lblSelectDB";
            this.lblSelectDB.Size = new System.Drawing.Size(196, 17);
            this.lblSelectDB.TabIndex = 6;
            this.lblSelectDB.Text = "Выбор БД для подключения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 278);
            this.Controls.Add(this.lblSelectDB);
            this.Controls.Add(this.cbSelectDB);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnAuthorize);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button btnAuthorize;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.ComboBox cbSelectDB;
        private System.Windows.Forms.Label lblSelectDB;
    }
}

