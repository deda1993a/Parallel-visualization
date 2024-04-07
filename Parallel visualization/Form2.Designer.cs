namespace Parallel_visualization
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
            button1 = new Button();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label3 = new Label();
            numericUpDown3 = new NumericUpDown();
            label4 = new Label();
            button3 = new Button();
            label5 = new Label();
            label6 = new Label();
            numericUpDown4 = new NumericUpDown();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(52, 70);
            button1.Name = "button1";
            button1.Size = new Size(169, 23);
            button1.TabIndex = 0;
            button1.Text = "Szekvenciálisan végrehajtott";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 74);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // button2
            // 
            button2.Location = new Point(399, 70);
            button2.Name = "button2";
            button2.Size = new Size(168, 23);
            button2.TabIndex = 2;
            button2.Text = "Párhuzamosan végrehajtott";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(573, 74);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "label2";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(36, 159);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(340, 308);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(399, 159);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(362, 308);
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(133, 12);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 6;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(259, 12);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(120, 23);
            numericUpDown2.TabIndex = 7;
            numericUpDown2.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 14);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 8;
            label3.Text = "Véletlenszámok:";
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(133, 40);
            numericUpDown3.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(120, 23);
            numericUpDown3.TabIndex = 9;
            numericUpDown3.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown3.ValueChanged += numericUpDown3_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 41);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 10;
            label4.Text = "Tömb méret:";
            // 
            // button3
            // 
            button3.Location = new Point(261, 43);
            button3.Name = "button3";
            button3.Size = new Size(118, 23);
            button3.TabIndex = 11;
            button3.Text = "Tömb feltöltés";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 96);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 14;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(399, 96);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 15;
            label6.Text = "label6";
            // 
            // numericUpDown4
            // 
            numericUpDown4.Location = new Point(556, 33);
            numericUpDown4.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numericUpDown4.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDown4.Name = "numericUpDown4";
            numericUpDown4.Size = new Size(120, 23);
            numericUpDown4.TabIndex = 16;
            numericUpDown4.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(475, 35);
            label7.Name = "label7";
            label7.Size = new Size(75, 15);
            label7.TabIndex = 17;
            label7.Text = "Szálak száma";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 765);
            Controls.Add(label7);
            Controls.Add(numericUpDown4);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(button3);
            Controls.Add(label4);
            Controls.Add(numericUpDown3);
            Controls.Add(label3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Merge Sort";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button2;
        private Label label2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label3;
        private NumericUpDown numericUpDown3;
        private Label label4;
        private Button button3;
        private Label label5;
        private Label label6;
        private NumericUpDown numericUpDown4;
        private Label label7;
    }
}