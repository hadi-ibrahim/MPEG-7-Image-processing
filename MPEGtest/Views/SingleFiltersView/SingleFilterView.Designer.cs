using System.ComponentModel;

namespace MPEGtest.Views.SingleFiltersView
{
    partial class SingleFilterView
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
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.discardButton = new System.Windows.Forms.Button();
            this.ValueSlider = new System.Windows.Forms.TrackBar();
            this.numericUpDownCR = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCB = new System.Windows.Forms.NumericUpDown();
            this.labelCR = new System.Windows.Forms.Label();
            this.labelCG = new System.Windows.Forms.Label();
            this.labelCB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.ValueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCB)).BeginInit();
            this.SuspendLayout();
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.thresholdLabel.Location = new System.Drawing.Point(11, 8);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(310, 28);
            this.thresholdLabel.TabIndex = 2;
            this.thresholdLabel.Text = "Threshold";
            this.thresholdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(117, 96);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(91, 30);
            this.previewButton.TabIndex = 3;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(223, 96);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(91, 30);
            this.applyButton.TabIndex = 4;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(11, 96);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(91, 30);
            this.discardButton.TabIndex = 5;
            this.discardButton.Text = "Discard";
            this.discardButton.UseVisualStyleBackColor = true;
            // 
            // ValueSlider
            // 
            this.ValueSlider.Location = new System.Drawing.Point(14, 46);
            this.ValueSlider.Name = "ValueSlider";
            this.ValueSlider.Size = new System.Drawing.Size(299, 45);
            this.ValueSlider.TabIndex = 6;
            // 
            // numericUpDownCR
            // 
            this.numericUpDownCR.Location = new System.Drawing.Point(48, 46);
            this.numericUpDownCR.Name = "numericUpDownCR";
            this.numericUpDownCR.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCR.TabIndex = 7;
            // 
            // numericUpDownCG
            // 
            this.numericUpDownCG.Location = new System.Drawing.Point(154, 46);
            this.numericUpDownCG.Name = "numericUpDownCG";
            this.numericUpDownCG.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCG.TabIndex = 8;
            // 
            // numericUpDownCB
            // 
            this.numericUpDownCB.Location = new System.Drawing.Point(259, 46);
            this.numericUpDownCB.Name = "numericUpDownCB";
            this.numericUpDownCB.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCB.TabIndex = 9;
            // 
            // labelCR
            // 
            this.labelCR.Location = new System.Drawing.Point(14, 46);
            this.labelCR.Name = "labelCR";
            this.labelCR.Size = new System.Drawing.Size(34, 19);
            this.labelCR.TabIndex = 10;
            this.labelCR.Text = "CR %";
            // 
            // labelCG
            // 
            this.labelCG.Location = new System.Drawing.Point(117, 47);
            this.labelCG.Name = "labelCG";
            this.labelCG.Size = new System.Drawing.Size(34, 19);
            this.labelCG.TabIndex = 11;
            this.labelCG.Text = "CG %";
            // 
            // labelCB
            // 
            this.labelCB.Location = new System.Drawing.Point(223, 48);
            this.labelCB.Name = "labelCB";
            this.labelCB.Size = new System.Drawing.Size(34, 19);
            this.labelCB.TabIndex = 12;
            this.labelCB.Text = "CB %";
            // 
            // SingleFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 131);
            this.Controls.Add(this.labelCB);
            this.Controls.Add(this.labelCG);
            this.Controls.Add(this.labelCR);
            this.Controls.Add(this.numericUpDownCB);
            this.Controls.Add(this.numericUpDownCG);
            this.Controls.Add(this.numericUpDownCR);
            this.Controls.Add(this.ValueSlider);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.thresholdLabel);
            this.Name = "SingleFilterView";
            this.Text = "SingleFilterView";
            ((System.ComponentModel.ISupportInitialize) (this.ValueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCR)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label labelCB;
        private System.Windows.Forms.Label labelCG;
        private System.Windows.Forms.Label labelCR;

        private System.Windows.Forms.NumericUpDown numericUpDownCB;

        private System.Windows.Forms.NumericUpDown numericUpDownCG;

        private System.Windows.Forms.NumericUpDown numericUpDownCR;

        private System.Windows.Forms.TrackBar ValueSlider;

        private System.Windows.Forms.Button previewButton;

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Label thresholdLabel;

        #endregion
    }
}