﻿using Fall2020_CSC403_Project.code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project
{
    public partial class FrmWinLevelTwo : Form
    {
        public static FrmWinLevelTwo instance = null;
        public FrmWinLevelTwo()
        {
            InitializeComponent();
        }

        public static FrmWinLevelTwo GetInstance()
        {
            if (instance == null)
            {
                instance = new FrmWinLevelTwo();
                //instance.Setup();
            }
            return instance;
        }

        private void FrmWinLevel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {   
            //this flips the visibility value for every tick of the timer;
            //so the big red X flashes
            //pictureBox3.Visible = !pictureBox3.Visible;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}