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
            menuStrip1 = new MenuStrip();
            fájlToolStripMenuItem = new ToolStripMenuItem();
            mergeSortToolStripMenuItem = new ToolStripMenuItem();
            imageToolStripMenuItem = new ToolStripMenuItem();
            grayscaleToolStripMenuItem = new ToolStripMenuItem();
            erosionToolStripMenuItem = new ToolStripMenuItem();
            grahamScanForConvexHullToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fájlToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fájlToolStripMenuItem
            // 
            fájlToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mergeSortToolStripMenuItem, imageToolStripMenuItem, grayscaleToolStripMenuItem, erosionToolStripMenuItem, grahamScanForConvexHullToolStripMenuItem });
            fájlToolStripMenuItem.Name = "fájlToolStripMenuItem";
            fájlToolStripMenuItem.Size = new Size(37, 20);
            fájlToolStripMenuItem.Text = "Fájl";
            // 
            // mergeSortToolStripMenuItem
            // 
            mergeSortToolStripMenuItem.Name = "mergeSortToolStripMenuItem";
            mergeSortToolStripMenuItem.Size = new Size(229, 22);
            mergeSortToolStripMenuItem.Text = "Merge Sort";
            mergeSortToolStripMenuItem.Click += mergeSortToolStripMenuItem_Click;
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new Size(229, 22);
            imageToolStripMenuItem.Text = "Image";
            // 
            // grayscaleToolStripMenuItem
            // 
            grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            grayscaleToolStripMenuItem.Size = new Size(229, 22);
            grayscaleToolStripMenuItem.Text = "Grayscale";
            grayscaleToolStripMenuItem.Click += grayscaleToolStripMenuItem_Click;
            // 
            // erosionToolStripMenuItem
            // 
            erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            erosionToolStripMenuItem.Size = new Size(229, 22);
            erosionToolStripMenuItem.Text = "Erosion";
            erosionToolStripMenuItem.Click += erosionToolStripMenuItem_Click;
            // 
            // grahamScanForConvexHullToolStripMenuItem
            // 
            grahamScanForConvexHullToolStripMenuItem.Name = "grahamScanForConvexHullToolStripMenuItem";
            grahamScanForConvexHullToolStripMenuItem.Size = new Size(229, 22);
            grahamScanForConvexHullToolStripMenuItem.Text = "Graham scan for Convex Hull";
            grahamScanForConvexHullToolStripMenuItem.Click += grahamScanForConvexHullToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fájlToolStripMenuItem;
        private ToolStripMenuItem mergeSortToolStripMenuItem;
        private ToolStripMenuItem imageToolStripMenuItem;
        private ToolStripMenuItem grayscaleToolStripMenuItem;
        private ToolStripMenuItem erosionToolStripMenuItem;
        private ToolStripMenuItem grahamScanForConvexHullToolStripMenuItem;
    }
}