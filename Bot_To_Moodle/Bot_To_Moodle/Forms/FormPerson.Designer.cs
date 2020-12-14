namespace Bot_To_Moodle
{
    partial class FormPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textGroup = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textTime = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textURL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textGroup
            // 
            this.textGroup.Location = new System.Drawing.Point(15, 25);
            this.textGroup.Name = "textGroup";
            this.textGroup.Size = new System.Drawing.Size(227, 20);
            this.textGroup.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Введите название группы";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Интервал перехода в миллисекундах";
            // 
            // textTime
            // 
            this.textTime.Location = new System.Drawing.Point(15, 108);
            this.textTime.Name = "textTime";
            this.textTime.Size = new System.Drawing.Size(224, 20);
            this.textTime.TabIndex = 2;
            this.textTime.Text = "2000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Путь URL (нужно указать URL курса)";
            // 
            // textURL
            // 
            this.textURL.Location = new System.Drawing.Point(12, 69);
            this.textURL.Name = "textURL";
            this.textURL.Size = new System.Drawing.Size(227, 20);
            this.textURL.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "Вперед!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(254, 190);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textGroup);
            this.MaximizeBox = false;
            this.Name = "FormPerson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заполнить курс студентами";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPerson_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textURL;
        private System.Windows.Forms.Button button1;
    }
}