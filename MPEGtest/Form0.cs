﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MPEGtest
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frame = new Form1();
            frame.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frame = new Form2();
            frame.Show();
        }
    }
}
