namespace admission_office
{
    partial class TextBoxExams
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
            this.tbExamRes = new System.Windows.Forms.TextBox();
            this.cbExam = new System.Windows.Forms.ComboBox();
            this.lblExam1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbExamRes
            // 
            this.tbExamRes.Location = new System.Drawing.Point(146, 23);
            this.tbExamRes.Name = "tbExamRes";
            this.tbExamRes.Size = new System.Drawing.Size(57, 22);
            this.tbExamRes.TabIndex = 43;
            this.tbExamRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbExamRes1_KeyPress);
            // 
            // cbExam
            // 
            this.cbExam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExam.FormattingEnabled = true;
            this.cbExam.Location = new System.Drawing.Point(3, 23);
            this.cbExam.Name = "cbExam";
            this.cbExam.Size = new System.Drawing.Size(121, 24);
            this.cbExam.TabIndex = 38;
            // 
            // lblExam1
            // 
            this.lblExam1.AutoSize = true;
            this.lblExam1.Location = new System.Drawing.Point(0, 0);
            this.lblExam1.Name = "lblExam1";
            this.lblExam1.Size = new System.Drawing.Size(68, 17);
            this.lblExam1.TabIndex = 37;
            this.lblExam1.Text = "Экзамен ";
            // 
            // TextBoxExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbExamRes);
            this.Controls.Add(this.cbExam);
            this.Controls.Add(this.lblExam1);
            this.Name = "TextBoxExams";
            this.Size = new System.Drawing.Size(214, 59);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbExamRes;
        private System.Windows.Forms.ComboBox cbExam;
        private System.Windows.Forms.Label lblExam1;
    }
}
