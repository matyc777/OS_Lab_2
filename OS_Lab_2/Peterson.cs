using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace OS_Lab_2
{
    public partial class Peterson : Form
    {
        public static Peterson peterson = null;

        public Peterson()
        {
            InitializeComponent();
            peterson = this;
        }

        public void ChangeTxtBox(string Value)
        {
            richTextBox1.Text += Value;
        }

        void TestFunction()
        {
            int Number = 0;
            textBox1.Invoke(new Action(() => { Number = int.Parse(textBox1.Text.ToString()); }));
            long Result = 1;
            for (int i = Number; i >= 1; i--)
            {
                Result *= i;
            }
            textBox2.Invoke(new Action(() => { textBox2.Text = Result.ToString(); }));
            Scheduler.Unlock(0);
            richTextBox1.Invoke(new Action(() => { richTextBox1.Text += "0 has LEFT critical region.\n"; }));
        }

        void TestFunction2()
        {
            int n = 0;
            textBox3.Invoke(new Action(() => { n = int.Parse(textBox3.Text.ToString()); }));
            SoundPlayer sd = new SoundPlayer("success.wav");
            for (int i = 0; i < n; i++)
            {
                sd.PlaySync();
            }
            Scheduler.Unlock(1);
            richTextBox1.Invoke(new Action(() => { richTextBox1.Text += "1 has LEFT critical region.\n"; }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(TestFunction);
            Scheduler.Lock(0);
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(TestFunction2);
            Scheduler.Lock(1);
            thread.Start();
        }
    }
}
