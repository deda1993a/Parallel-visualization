﻿namespace Parallel_visualization
{
    partial class Form3
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
            openFileDialog1 = new OpenFileDialog();
            textBox1 = new TextBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            button4 = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(43, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(149, 11);
            button1.Name = "button1";
            button1.Size = new Size(95, 23);
            button1.TabIndex = 1;
            button1.Text = "Kép beolvasás";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(29, 88);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(284, 232);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(449, 90);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(306, 230);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(43, 47);
            button2.Name = "button2";
            button2.Size = new Size(149, 23);
            button2.TabIndex = 4;
            button2.Text = "Szekvenciális egy képen";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(438, 43);
            button3.Name = "button3";
            button3.Size = new Size(145, 23);
            button3.TabIndex = 5;
            button3.Text = "Párhuzamos egy képen";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(364, 55);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 6;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(745, 51);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 7;
            label2.Text = "label2";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(438, 11);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 8;
            // 
            // button4
            // 
            button4.Location = new Point(544, 11);
            button4.Name = "button4";
            button4.Size = new Size(195, 23);
            button4.TabIndex = 9;
            button4.Text = "Képeknek való mappa megadása";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(198, 47);
            button5.Name = "button5";
            button5.Size = new Size(163, 23);
            button5.TabIndex = 10;
            button5.Text = "Szekvenciális több képen";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(589, 43);
            button6.Name = "button6";
            button6.Size = new Size(150, 23);
            button6.TabIndex = 11;
            button6.Text = "Párhuzamos több képen";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(826, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form3";
            Text = "Grayscale";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button button4;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button5;
        private Button button6;
    }
}