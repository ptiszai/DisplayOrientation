using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisplayOrientation
{
    public partial class Form1 : Form , IDisposable
    {
        #region private variables 
        private Thread thread1 = null;
        private int width = 0;
        private int height = 0;
        private bool _result = false;
        #endregion
        #region public functions
        public Form1()
        {
            InitializeComponent();
        }
        public void Dispose()
        {
            if (thread1.IsAlive)
            {
                thread1.Abort();
            }
        }
        #endregion
        #region private functions
        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            landscapeRadioBtn_Click(null, null);
            thread1 = new Thread(executor);
            thread1.Start();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();        
        }

        private void landscapeRadioBtn_Click(object sender, EventArgs e)
        {
            _result = RotateDisplay.Running(0, 0, true, false, ref width, ref height);
            result.Text = _result.ToString();
            width_value.Text = width.ToString();
            height_value.Text = height.ToString();
            return;
        }

        private void portraitinvertedRadioBtn_Click(object sender, EventArgs e)
        {         
            _result = RotateDisplay.Running(0, 90, true, false, ref width, ref height);
            result.Text = _result.ToString();
            width_value.Text = width.ToString();
            height_value.Text = height.ToString();
            return;
        }

        private void landscapeinvertedRadioBtn_Click(object sender, EventArgs e)
        {
            _result = RotateDisplay.Running(0, 180, true, false, ref width, ref height);
            result.Text = _result.ToString();
            return;
        }

        private void portraidradioBtn_Click(object sender, EventArgs e)
        {
            _result = RotateDisplay.Running(0, 270, true, false, ref width, ref height);
            result.Text = _result.ToString();
            return;
        }

        private void executor()
        {
            while (true)
            {
                Thread.Sleep(1000);
            }
        }
        #endregion

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            thread1.Abort();          
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {

            }
            else 
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else
            if (e.KeyCode == Keys.F2)
            {
                _result = RotateDisplay.Running(0, 0, true, false, ref width, ref height);
                result.Text = _result.ToString();
                width_value.Text = width.ToString();
                height_value.Text = height.ToString();
                landscapeRadioBtn.Checked = true;
            }
            e.SuppressKeyPress = true;
        }
    }
}
