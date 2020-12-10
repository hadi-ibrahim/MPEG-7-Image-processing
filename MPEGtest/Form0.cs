using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MPEGtest.Common.Helpers;

namespace MPEGtest
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void ExitButtonOnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewImageButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView(new Form1());
        }

        private void SearchForImageButtonOnClick(object sender, EventArgs e)
        {
            this.ReplaceView(new Form2());
        }
    }
}