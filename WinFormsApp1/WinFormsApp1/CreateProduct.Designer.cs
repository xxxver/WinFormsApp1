namespace WinFormsApp1
{
    partial class CreateProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProduct));
            button1 = new Button();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            comboBox2 = new ComboBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(53, 92, 189);
            button1.Font = new Font("Candara", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.ForeColor = Color.White;
            button1.Location = new Point(82, 503);
            button1.Name = "button1";
            button1.Size = new Size(494, 79);
            button1.TabIndex = 24;
            button1.Text = "Сохранить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Candara", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.ForeColor = Color.FromArgb(53, 92, 189);
            label6.Location = new Point(79, 421);
            label6.Name = "label6";
            label6.Size = new Size(138, 35);
            label6.TabIndex = 23;
            label6.Text = "Материал";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Candara", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.ForeColor = Color.FromArgb(53, 92, 189);
            label5.Location = new Point(79, 356);
            label5.Name = "label5";
            label5.Size = new Size(205, 35);
            label5.TabIndex = 22;
            label5.Text = "Мин.стоимость";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Candara", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.ForeColor = Color.FromArgb(53, 92, 189);
            label4.Location = new Point(82, 278);
            label4.Name = "label4";
            label4.Size = new Size(131, 35);
            label4.TabIndex = 21;
            label4.Text = "Название";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Candara", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.ForeColor = Color.FromArgb(53, 92, 189);
            label3.Location = new Point(82, 212);
            label3.Name = "label3";
            label3.Size = new Size(58, 35);
            label3.TabIndex = 20;
            label3.Text = "Тип";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Candara", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.ForeColor = Color.FromArgb(53, 92, 189);
            label2.Location = new Point(82, 147);
            label2.Name = "label2";
            label2.Size = new Size(116, 35);
            label2.TabIndex = 19;
            label2.Text = "Артикул";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(290, 428);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(286, 28);
            comboBox2.TabIndex = 18;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(290, 363);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(286, 27);
            textBox3.TabIndex = 17;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(290, 285);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(286, 27);
            textBox2.TabIndex = 16;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(290, 154);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 27);
            textBox1.TabIndex = 15;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(290, 219);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(286, 28);
            comboBox1.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Candara", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.ForeColor = Color.FromArgb(53, 92, 189);
            label1.Location = new Point(136, 49);
            label1.Name = "label1";
            label1.Size = new Size(372, 58);
            label1.TabIndex = 13;
            label1.Text = "Создание товара";
            // 
            // CreateProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(647, 650);
            Controls.Add(button1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "CreateProduct";
            Text = "Создание продукта";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboBox2;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label1;
    }
}