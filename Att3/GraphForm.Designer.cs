namespace Att3
{
    partial class GraphForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GetWayBtn = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.ComboBox();
            this.Image = new System.Windows.Forms.PictureBox();
            this.GetDist = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetDist)).BeginInit();
            this.SuspendLayout();
            // 
            // GetWayBtn
            // 
            this.GetWayBtn.Location = new System.Drawing.Point(582, 12);
            this.GetWayBtn.Name = "GetWayBtn";
            this.GetWayBtn.Size = new System.Drawing.Size(104, 23);
            this.GetWayBtn.TabIndex = 4;
            this.GetWayBtn.Text = "получить путь ";
            this.GetWayBtn.UseVisualStyleBackColor = true;
            this.GetWayBtn.Click += new System.EventHandler(this.GetWayBtn_Click);
            // 
            // select
            // 
            this.select.FormattingEnabled = true;
            this.select.Items.AddRange(new object[] {
            "добавить ноду",
            "удалить ноду",
            "добавить грань",
            "удалить грань"});
            this.select.Location = new System.Drawing.Point(12, 14);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(141, 21);
            this.select.TabIndex = 5;
            this.select.SelectedIndexChanged += new System.EventHandler(this.select_SelectedIndexChanged);
            // 
            // Image
            // 
            this.Image.Location = new System.Drawing.Point(12, 41);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(674, 389);
            this.Image.TabIndex = 6;
            this.Image.TabStop = false;
            this.Image.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Image_MouseClick);
            // 
            // GetDist
            // 
            this.GetDist.Location = new System.Drawing.Point(159, 15);
            this.GetDist.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GetDist.Name = "GetDist";
            this.GetDist.Size = new System.Drawing.Size(120, 20);
            this.GetDist.TabIndex = 7;
            this.GetDist.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GetDist.Visible = false;
            // 
            // GraphForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 442);
            this.Controls.Add(this.GetDist);
            this.Controls.Add(this.Image);
            this.Controls.Add(this.select);
            this.Controls.Add(this.GetWayBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GraphForm";
            this.Text = "граф";
            this.Load += new System.EventHandler(this.GraphForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GetDist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button GetWayBtn;
        private System.Windows.Forms.ComboBox select;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.NumericUpDown GetDist;
    }
}

