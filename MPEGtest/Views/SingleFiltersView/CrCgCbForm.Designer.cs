using System.ComponentModel;

namespace MPEGtest.Views.SingleFiltersView
{
    partial class CrCgCbForm
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
            this.labelCB = new System.Windows.Forms.Label();
            this.labelCG = new System.Windows.Forms.Label();
            this.labelCR = new System.Windows.Forms.Label();
            this.numericUpDownCB = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCG = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCR = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCR)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCB
            // 
            this.labelCB.Location = new System.Drawing.Point(252, 49);
            this.labelCB.Name = "labelCB";
            this.labelCB.Size = new System.Drawing.Size(34, 19);
            this.labelCB.TabIndex = 18;
            this.labelCB.Text = "CB %";
            this.labelCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCG
            // 
            this.labelCG.Location = new System.Drawing.Point(146, 48);
            this.labelCG.Name = "labelCG";
            this.labelCG.Size = new System.Drawing.Size(34, 19);
            this.labelCG.TabIndex = 17;
            this.labelCG.Text = "CG %";
            this.labelCG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCR
            // 
            this.labelCR.Location = new System.Drawing.Point(43, 47);
            this.labelCR.Name = "labelCR";
            this.labelCR.Size = new System.Drawing.Size(34, 19);
            this.labelCR.TabIndex = 16;
            this.labelCR.Text = "CR %";
            this.labelCR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownCB
            // 
            this.numericUpDownCB.Location = new System.Drawing.Point(292, 49);
            this.numericUpDownCB.Name = "numericUpDownCB";
            this.numericUpDownCB.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCB.TabIndex = 15;
            this.numericUpDownCB.ValueChanged += new System.EventHandler(this.numericUpDownCB_ValueChanged);
            // 
            // numericUpDownCG
            // 
            this.numericUpDownCG.Location = new System.Drawing.Point(183, 47);
            this.numericUpDownCG.Name = "numericUpDownCG";
            this.numericUpDownCG.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCG.TabIndex = 14;
            this.numericUpDownCG.ValueChanged += new System.EventHandler(this.numericUpDownCG_ValueChanged);
            // 
            // numericUpDownCR
            // 
            this.numericUpDownCR.Location = new System.Drawing.Point(77, 47);
            this.numericUpDownCR.Name = "numericUpDownCR";
            this.numericUpDownCR.ReadOnly = true;
            this.numericUpDownCR.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCR.TabIndex = 13;
            this.numericUpDownCR.ValueChanged += new System.EventHandler(this.numericUpDownCR_ValueChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(22, 108);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(109, 41);
            this.cancelButton.TabIndex = 20;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(248, 110);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(111, 40);
            this.applyButton.TabIndex = 19;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            // 
            // CrCgCbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.labelCB);
            this.Controls.Add(this.labelCG);
            this.Controls.Add(this.labelCR);
            this.Controls.Add(this.numericUpDownCB);
            this.Controls.Add(this.numericUpDownCG);
            this.Controls.Add(this.numericUpDownCR);
            this.Name = "CrCgCbForm";
            this.Text = "CrCgCbForm";
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCB)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCG)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownCR)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button cancelButton;

        private System.Windows.Forms.Label labelCB;
        private System.Windows.Forms.Label labelCG;
        private System.Windows.Forms.Label labelCR;
        private System.Windows.Forms.NumericUpDown numericUpDownCB;
        private System.Windows.Forms.NumericUpDown numericUpDownCG;
        private System.Windows.Forms.NumericUpDown numericUpDownCR;

        #endregion
    }
}