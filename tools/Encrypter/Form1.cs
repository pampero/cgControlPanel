using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Services.Security.impl;

namespace Encrypter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            var key = txtKey.Text;

            try
            {
                txtValue2.Text = EncryptionService.Encrypt(txtValue1.Text, key);
            }
            catch (Exception exception)
            {
                    MessageBox.Show("Error: " + exception.Message);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var key = txtKey.Text;
                txtValue1.Text = EncryptionService.Decrypt(txtValue2.Text, key);
            }
            catch (Exception exception)
            {
                    MessageBox.Show("Error: " + exception.Message);
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            txtKey.Text = "j7Of5RiyZAXDWSiDlC6BDrs7oCtExIo=";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                txtKey.Text = EncryptionService.GenerateAPassKey(txtPassPhrase.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
        }
    }
}
