namespace admission_office
{
    partial class Subject
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
            this.lblSubj = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSubj
            // 
            this.lblSubj.AutoSize = true;
            this.lblSubj.Location = new System.Drawing.Point(14, 4);
            this.lblSubj.Name = "lblSubj";
            this.lblSubj.Size = new System.Drawing.Size(66, 17);
            this.lblSubj.TabIndex = 0;
            this.lblSubj.Text = "Предмет";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 78);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 32);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(17, 34);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(100, 22);
            this.tbSubject.TabIndex = 2;
            // 
            // Subject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSubj);
            this.Name = "Subject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubj;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbSubject;
    }
}
