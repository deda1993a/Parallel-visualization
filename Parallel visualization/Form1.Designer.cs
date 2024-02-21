namespace Parallel_visualization
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fájlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeSortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grahamScanForConvexHullToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mandelbrotSetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fájlToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(914, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fájlToolStripMenuItem
            // 
            this.fájlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mergeSortToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.erosionToolStripMenuItem,
            this.grahamScanForConvexHullToolStripMenuItem,
            this.mandelbrotSetToolStripMenuItem});
            this.fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            this.fájlToolStripMenuItem.Size = new System.Drawing.Size(45, 24);
            this.fájlToolStripMenuItem.Text = "Fájl";
            // 
            // mergeSortToolStripMenuItem
            // 
            this.mergeSortToolStripMenuItem.Name = "mergeSortToolStripMenuItem";
            this.mergeSortToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.mergeSortToolStripMenuItem.Text = "Merge Sort";
            this.mergeSortToolStripMenuItem.Click += new System.EventHandler(this.mergeSortToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // grahamScanForConvexHullToolStripMenuItem
            // 
            this.grahamScanForConvexHullToolStripMenuItem.Name = "grahamScanForConvexHullToolStripMenuItem";
            this.grahamScanForConvexHullToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.grahamScanForConvexHullToolStripMenuItem.Text = "Graham scan for Convex Hull";
            this.grahamScanForConvexHullToolStripMenuItem.Click += new System.EventHandler(this.grahamScanForConvexHullToolStripMenuItem_Click);
            // 
            // mandelbrotSetToolStripMenuItem
            // 
            this.mandelbrotSetToolStripMenuItem.Name = "mandelbrotSetToolStripMenuItem";
            this.mandelbrotSetToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.mandelbrotSetToolStripMenuItem.Text = "Mandelbrot set";
            this.mandelbrotSetToolStripMenuItem.Click += new System.EventHandler(this.mandelbrotSetToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fájlToolStripMenuItem;
        private ToolStripMenuItem mergeSortToolStripMenuItem;
        private ToolStripMenuItem grayscaleToolStripMenuItem;
        private ToolStripMenuItem erosionToolStripMenuItem;
        private ToolStripMenuItem grahamScanForConvexHullToolStripMenuItem;
        private ToolStripMenuItem mandelbrotSetToolStripMenuItem;
    }
}