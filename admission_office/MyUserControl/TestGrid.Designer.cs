namespace admission_office
{
    partial class TestGrid
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
            this.dgvEntrants = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrants)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEntrants
            // 
            this.dgvEntrants.AllowUserToOrderColumns = true;
            this.dgvEntrants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEntrants.Location = new System.Drawing.Point(3, 3);
            this.dgvEntrants.Name = "dgvEntrants";
            this.dgvEntrants.RowTemplate.Height = 24;
            this.dgvEntrants.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEntrants.Size = new System.Drawing.Size(988, 526);
            this.dgvEntrants.TabIndex = 0;
            // 
            // TestGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvEntrants);
            this.Name = "TestGrid";
            this.Size = new System.Drawing.Size(994, 532);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntrants)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEntrants;
    }
}
