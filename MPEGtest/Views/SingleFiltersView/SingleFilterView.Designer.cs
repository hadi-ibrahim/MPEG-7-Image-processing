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
            System.Windows.Forms.TrackBar thresholdSlider;
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.discardButton = new System.Windows.Forms.Button();
            thresholdSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize) (thresholdSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // thresholdSlider
            // 
            thresholdSlider.Location = new System.Drawing.Point(11, 39);
            thresholdSlider.Maximum = 30;
            thresholdSlider.Minimum = 1;
            thresholdSlider.Name = "thresholdSlider";
            thresholdSlider.Size = new System.Drawing.Size(310, 45);
            thresholdSlider.TabIndex = 1;
            thresholdSlider.Value = 1;
            thresholdSlider.Scroll += new System.EventHandler(this.thresholdSlider_Scroll);
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
            // SingleFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 131);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(thresholdSlider);
            this.Name = "SingleFilterView";
            this.Text = "SingleFilterView";
            ((System.ComponentModel.ISupportInitialize) (thresholdSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button previewButton;

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Label thresholdLabel;

        #endregion
    }
}