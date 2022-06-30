﻿using Senaka.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Senaka.component
{
    public partial class BookingPasswordForm : Form
    {
        public BookingPasswordForm()
        {
            InitializeComponent();
        }

        public string InputBox()
        {
            if (ShowDialog() == DialogResult.OK)
            {
                return textBoxPassword.Text;
            }
            return "";
        }
    }
}
