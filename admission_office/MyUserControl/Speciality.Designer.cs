namespace admission_office
{
    partial class Speciality
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.lblSpec = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbDaily = new System.Windows.Forms.CheckBox();
            this.mtbFree = new System.Windows.Forms.MaskedTextBox();
            this.mtbPaid = new System.Windows.Forms.MaskedTextBox();
            this.lblNumOfFree = new System.Windows.Forms.Label();
            this.lblNumOfPaid = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(179, 116);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 45);
            this.panel3.TabIndex = 42;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(179, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 45);
            this.panel2.TabIndex = 41;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(179, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 45);
            this.panel1.TabIndex = 40;
            // 
            // tbSpec
            // 
            this.tbSpec.Location = new System.Drawing.Point(7, 26);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.Size = new System.Drawing.Size(138, 22);
            this.tbSpec.TabIndex = 43;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Location = new System.Drawing.Point(4, 4);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(109, 17);
            this.lblSpec.TabIndex = 44;
            this.lblSpec.Text = "Специальность";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(4, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 30);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbDaily
            // 
            this.cbDaily.AutoSize = true;
            this.cbDaily.Location = new System.Drawing.Point(7, 54);
            this.cbDaily.Name = "cbDaily";
            this.cbDaily.Size = new System.Drawing.Size(73, 21);
            this.cbDaily.TabIndex = 46;
            this.cbDaily.Text = "Очное";
            this.cbDaily.UseVisualStyleBackColor = true;
            // 
            // mtbFree
            // 
            this.mtbFree.Location = new System.Drawing.Point(4, 111);
            this.mtbFree.Mask = "00";
            this.mtbFree.Name = "mtbFree";
            this.mtbFree.Size = new System.Drawing.Size(100, 22);
            this.mtbFree.TabIndex = 47;
            this.mtbFree.ValidatingType = typeof(int);
            // 
            // mtbPaid
            // 
            this.mtbPaid.Location = new System.Drawing.Point(4, 164);
            this.mtbPaid.Mask = "00";
            this.mtbPaid.Name = "mtbPaid";
            this.mtbPaid.Size = new System.Drawing.Size(100, 22);
            this.mtbPaid.TabIndex = 48;
            this.mtbPaid.ValidatingType = typeof(int);
            // 
            // lblNumOfFree
            // 
            this.lblNumOfFree.AutoSize = true;
            this.lblNumOfFree.Location = new System.Drawing.Point(4, 89);
            this.lblNumOfFree.Name = "lblNumOfFree";
            this.lblNumOfFree.Size = new System.Drawing.Size(128, 17);
            this.lblNumOfFree.TabIndex = 49;
            this.lblNumOfFree.Text = "Бюджетные места";
            // 
            // lblNumOfPaid
            // 
            this.lblNumOfPaid.AutoSize = true;
            this.lblNumOfPaid.Location = new System.Drawing.Point(4, 144);
            this.lblNumOfPaid.Name = "lblNumOfPaid";
            this.lblNumOfPaid.Size = new System.Drawing.Size(110, 17);
            this.lblNumOfPaid.TabIndex = 50;
            this.lblNumOfPaid.Text = "Платные места";
            // 
            // Speciality
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNumOfPaid);
            this.Controls.Add(this.lblNumOfFree);
            this.Controls.Add(this.mtbPaid);
            this.Controls.Add(this.mtbFree);
            this.Controls.Add(this.cbDaily);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblSpec);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Speciality";
            this.Size = new System.Drawing.Size(395, 277);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbDaily;
        private System.Windows.Forms.MaskedTextBox mtbFree;
        private System.Windows.Forms.MaskedTextBox mtbPaid;
        private System.Windows.Forms.Label lblNumOfFree;
        private System.Windows.Forms.Label lblNumOfPaid;
    }
}
