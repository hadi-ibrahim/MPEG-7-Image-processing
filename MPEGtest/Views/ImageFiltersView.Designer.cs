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
            this.dilatationButton = new System.Windows.Forms.Button();
            this.yCBCRButton = new System.Windows.Forms.Button();
            this.hSLButton = new System.Windows.Forms.Button();
            this.grayScaleButton = new System.Windows.Forms.Button();
            this.sobelEdgeDetectionButton = new System.Windows.Forms.Button();
            this.laplacianEdgeDetectionButton = new System.Windows.Forms.Button();
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
            this.gaussianButton.Click += new System.EventHandler(this.gaussianButton_Click);
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
            this.erosionButton.Text = "Erosion 3X3";
            this.erosionButton.UseVisualStyleBackColor = true;
            this.erosionButton.Click += new System.EventHandler(this.erosionButton_Click);
            // 
            // dilatationButton
            // 
            this.dilatationButton.Location = new System.Drawing.Point(276, 48);
            this.dilatationButton.Name = "dilatationButton";
            this.dilatationButton.Size = new System.Drawing.Size(80, 34);
            this.dilatationButton.TabIndex = 4;
            this.dilatationButton.Text = "Dilatation 3X3";
            this.dilatationButton.UseVisualStyleBackColor = true;
            this.dilatationButton.Click += new System.EventHandler(this.dilatationButton_Click);
            // 
            // yCBCRButton
            // 
            this.yCBCRButton.Location = new System.Drawing.Point(18, 104);
            this.yCBCRButton.Name = "yCBCRButton";
            this.yCBCRButton.Size = new System.Drawing.Size(80, 34);
            this.yCBCRButton.TabIndex = 5;
            this.yCBCRButton.Text = "YCBCR";
            this.yCBCRButton.UseVisualStyleBackColor = true;
            this.yCBCRButton.Click += new System.EventHandler(this.yCBCRButton_Click);
            // 
            // hSLButton
            // 
            this.hSLButton.Location = new System.Drawing.Point(104, 104);
            this.hSLButton.Name = "hSLButton";
            this.hSLButton.Size = new System.Drawing.Size(80, 34);
            this.hSLButton.TabIndex = 6;
            this.hSLButton.Text = "HSL Linear";
            this.hSLButton.UseVisualStyleBackColor = true;
            this.hSLButton.Click += new System.EventHandler(this.hSLButton_Click);
            // 
            // grayScaleButton
            // 
            this.grayScaleButton.Location = new System.Drawing.Point(190, 104);
            this.grayScaleButton.Name = "grayScaleButton";
            this.grayScaleButton.Size = new System.Drawing.Size(80, 34);
            this.grayScaleButton.TabIndex = 7;
            this.grayScaleButton.Text = "GrayScale";
            this.grayScaleButton.UseVisualStyleBackColor = true;
            this.grayScaleButton.Click += new System.EventHandler(this.grayScaleButton_Click);
            // 
            // sobelEdgeDetectionButton
            // 
            this.sobelEdgeDetectionButton.Location = new System.Drawing.Point(276, 104);
            this.sobelEdgeDetectionButton.Name = "sobelEdgeDetectionButton";
            this.sobelEdgeDetectionButton.Size = new System.Drawing.Size(80, 34);
            this.sobelEdgeDetectionButton.TabIndex = 8;
            this.sobelEdgeDetectionButton.Text = "Sobel Edge Detection";
            this.sobelEdgeDetectionButton.UseVisualStyleBackColor = true;
            this.sobelEdgeDetectionButton.Click += new System.EventHandler(this.sobelEdgeDetectionButton_Click);
            // 
            // laplacianEdgeDetectionButton
            // 
            this.laplacianEdgeDetectionButton.Location = new System.Drawing.Point(18, 161);
            this.laplacianEdgeDetectionButton.Name = "laplacianEdgeDetectionButton";
            this.laplacianEdgeDetectionButton.Size = new System.Drawing.Size(80, 34);
            this.laplacianEdgeDetectionButton.TabIndex = 9;
            this.laplacianEdgeDetectionButton.Text = "Laplacian Edge Detection";
            this.laplacianEdgeDetectionButton.UseVisualStyleBackColor = true;
            this.laplacianEdgeDetectionButton.Click += new System.EventHandler(this.laplacianEdgeDetectionButton_Click);
            // 
            // ImageFiltersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 226);
            this.Controls.Add(this.laplacianEdgeDetectionButton);
            this.Controls.Add(this.sobelEdgeDetectionButton);
            this.Controls.Add(this.grayScaleButton);
            this.Controls.Add(this.hSLButton);
            this.Controls.Add(this.yCBCRButton);
            this.Controls.Add(this.dilatationButton);
            this.Controls.Add(this.erosionButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gaussianButton);
            this.Controls.Add(this.medianButton);
            this.Name = "ImageFiltersView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ImageFiltersView";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button laplacianEdgeDetectionButton;

        private System.Windows.Forms.Button sobelEdgeDetectionButton;

        private System.Windows.Forms.Button grayScaleButton;

        private System.Windows.Forms.Button hSLButton;

        private System.Windows.Forms.Button yCBCRButton;

        private System.Windows.Forms.Button dilatationButton;

        private System.Windows.Forms.Button erosionButton;

        private System.Windows.Forms.Button gaussianButton;
        private System.Windows.Forms.Button medianButton;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}