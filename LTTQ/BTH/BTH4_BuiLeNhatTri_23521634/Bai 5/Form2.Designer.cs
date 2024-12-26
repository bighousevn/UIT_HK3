namespace Bai_5
{
    partial class Form2
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
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 14.25F);
            label1.Location = new Point(126, 65);
            label1.Name = "label1";
            label1.Size = new Size(149, 22);
            label1.TabIndex = 0;
            label1.Text = "Mã Số Sinh Viên";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(292, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(400, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(292, 130);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(400, 27);
            textBox2.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F);
            label2.Location = new Point(126, 130);
            label2.Name = "label2";
            label2.Size = new Size(128, 22);
            label2.TabIndex = 2;
            label2.Text = "Tên Sinh Viên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 14.25F);
            label3.Location = new Point(126, 197);
            label3.Name = "label3";
            label3.Size = new Size(54, 22);
            label3.TabIndex = 4;
            label3.Text = "Khoa";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(292, 270);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(400, 27);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 14.25F);
            label4.Location = new Point(126, 270);
            label4.Name = "label4";
            label4.Size = new Size(85, 22);
            label4.TabIndex = 6;
            label4.Text = "Điểm TB";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(115, 181, 107);
            button1.Location = new Point(435, 319);
            button1.Name = "button1";
            button1.Size = new Size(126, 43);
            button1.TabIndex = 8;
            button1.Text = "Thêm Mới";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 109, 49);
            button2.Location = new Point(582, 319);
            button2.Name = "button2";
            button2.Size = new Size(126, 43);
            button2.TabIndex = 9;
            button2.Text = "Thoát";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Công Nghệ Thông Tin", "Công Nghệ Phần Mềm", "Hệ Thống Thông Tin", "Khoa Học Và Kỹ Thuật Thông Tin" });
            comboBox1.Location = new Point(292, 196);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(400, 28);
            comboBox1.TabIndex = 10;
            comboBox1.UseWaitCursor = true;
            comboBox1.ImeMode = ImeMode.Off;
            comboBox1.DropDownStyle=ComboBoxStyle.DropDownList;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
    }
}