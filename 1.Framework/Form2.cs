using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace LYDTOPDP
{
    public partial class Form2 : Form
    {
        public delegate void ShowProDelegate(int value);

        public void ShowPro(int value, ShowProDelegate s)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(s, new object[] { value });
            }
            else
            {
                s(value);
            }
        }

        public void abc(int value)
        {
            progressBarX1.Value = value;
            progressBarX1.Text = value + "%";
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //new Thread(new ThreadStart(delegate()
            //{
            //    for (int i = 0; i <= 100; i++)
            //    {
            //        this.Invoke(new MethodInvoker(delegate()
            //        {
            //            progressBarX1.Value = i;
            //            progressBarX1.Text = i + "%";
            //        }));
            //        Thread.Sleep(50);
            //    }
            //})).Start();

            new Thread(new ThreadStart(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    this.Invoke(new MethodInvoker(delegate()
                    {
                        progressBarX1.Value = i;
                        progressBarX1.Text = i + "%";
                    }));
                    Thread.Sleep(50);
                }
            })).Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Form.CheckForIllegalCrossThreadCalls = false;
        }
    }
}
