using System.ComponentModel;

namespace MPEGtest.Views.SingleFiltersView
{
    partial class GaussianFilterView
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
            this.ValueSlider = new System.Windows.Forms.TrackBar();
            this.discardButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            this.SquareValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.ValueSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // ValueSlider
            // 
            this.ValueSlider.Location = new System.Drawing.Point(12, 54);
            this.ValueSlider.Maximum = 100;
            this.ValueSlider.Name = "ValueSlider";
            this.ValueSlider.Size = new System.Drawing.Size(360, 45);
            this.ValueSlider.TabIndex = 16;
            this.ValueSlider.Value = 3;
            // 
            // discardButton
            // 
            this.discardButton.Location = new System.Drawing.Point(12, 120);
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(91, 30);
            this.discardButton.TabIndex = 15;
            this.discardButton.Text = "Discard";
            this.discardButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(281, 120);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(91, 30);
            this.applyButton.TabIndex = 14;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(143, 120);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(91, 30);
            this.previewButton.TabIndex = 13;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            // 
            // SquareValueLabel
            // 
            this.SquareValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.SquareValueLabel.Location = new System.Drawing.Point(12, 10);
            this.SquareValueLabel.Name = "SquareValueLabel";
            this.SquareValueLabel.Size = new System.Drawing.Size(360, 28);
            this.SquareValueLabel.TabIndex = 12;
            this.SquareValueLabel.Text = "Square Value";
            this.SquareValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GaussianFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.ValueSlider);
            this.Controls.Add(this.discardButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.SquareValueLabel);
            this.Name = "GaussianFilterView";
            this.Text = "GuassianFilterView";
            ((System.ComponentModel.ISupportInitialize) (this.ValueSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button discardButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Label SquareValueLabel;
        private System.Windows.Forms.TrackBar ValueSlider;

        #endregion
    }
}