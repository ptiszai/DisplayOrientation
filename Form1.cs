using System;
using System.Threading;
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
        private bool display1 = false;
        private bool display2 = false;
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
            var (_display1, _display2) = RotateDisplay.IsDisplays();
            display1 = _display1;
            display2 = _display2;
            if (display1)
            { 
                display1Chbx.Enabled = true;
                display1Chbx.Checked = true;               
            }
            if (display2)
            {
                display2Chbx.Enabled = true;              
            }
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
            _result = RotateDisplay.Running(0, 0, display1, display2, ref width, ref height);
            result.Text = _result.ToString();
            width_value.Text = width.ToString();
            height_value.Text = height.ToString();
            return;
        }

        private void portraitinvertedRadioBtn_Click(object sender, EventArgs e)
        {         
            _result = RotateDisplay.Running(0, 90, display1, display2, ref width, ref height);
            result.Text = _result.ToString();
            width_value.Text = width.ToString();
            height_value.Text = height.ToString();
            return;
        }

        private void landscapeinvertedRadioBtn_Click(object sender, EventArgs e)
        {
            _result = RotateDisplay.Running(0, 180, display1, display2, ref width, ref height);
            result.Text = _result.ToString();
            return;
        }

        private void portraidradioBtn_Click(object sender, EventArgs e)
        {
            _result = RotateDisplay.Running(0, 270, display1, display2, ref width, ref height);
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
                _result = RotateDisplay.Running(0, 0, display1, display2, ref width, ref height);
                result.Text = _result.ToString();
                width_value.Text = width.ToString();
                height_value.Text = height.ToString();
                landscapeRadioBtn.Checked = true;
            }
            e.SuppressKeyPress = true;
        }

        private void display1Chbx_Click(object sender, EventArgs e)
        {
            display1 = display1Chbx.Checked;
            landscapeRadioBtn_Click(null, null);
        }

        private void display2Chbx_Click(object sender, EventArgs e)
        {
            display2 = display2Chbx.Checked;
            landscapeRadioBtn_Click(null, null);
        }
        #endregion
    }
}
