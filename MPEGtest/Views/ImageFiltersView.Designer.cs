using System.ComponentModel;

namespace MPEGtest.Views
{
    partial class ImageFiltersView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.medianButton = new System.Windows.Forms.Button();
            this.gaussianButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.erosionButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // medianButton
            // 
            this.medianButton.Location = new System.Drawing.Point(18, 48);
            this.medianButton.Name = "medianButton";
            this.medianButton.Size = new System.Drawing.Size(80, 34);
            this.medianButton.TabIndex = 0;
            this.medianButton.Text = "Median";
            this.medianButton.UseVisualStyleBackColor = true;
            this.medianButton.Click += new System.EventHandler(this.medianButton_Click);
            // 
            // gaussianButton
            // 
            this.gaussianButton.Location = new System.Drawing.Point(104, 48);
            this.gaussianButton.Name = "gaussianButton";
            this.gaussianButton.Size = new System.Drawing.Size(80, 34);
            this.gaussianButton.TabIndex = 1;
            this.gaussianButton.Text = "Gaussian";
            this.gaussianButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Filters\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // erosionButton
            // 
            this.erosionButton.Location = new System.Drawing.Point(190, 48);
            this.erosionButton.Name = "erosionButton";
            this.erosionButton.Size = new System.Drawing.Size(80, 34);
            this.erosionButton.TabIndex = 3;
            this.erosionButton.Text = "Erosion";
            this.erosionButton.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(276, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 34);
            this.button4.TabIndex = 4;
            this.button4.Text = "Gaussian";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ImageFiltersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 226);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.erosionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaussianButton);
            this.Controls.Add(this.medianButton);
            this.Name = "ImageFiltersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageFiltersView";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button erosionButton;

        private System.Windows.Forms.Button gaussianButton;
        private System.Windows.Forms.Button medianButton;

        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}