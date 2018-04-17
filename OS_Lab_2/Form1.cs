using System;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace OS_Lab_2
{
    public partial class Form1: Form
    {
        bool turn = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void Factorial()
        {
            label3.Invoke(new Action(() => { label3.Text = "Работает процесс 0"; }));
            Thread.Sleep(2000);
            int Number = 0;
            textBox1.Invoke(new Action(() => { Number = int.Parse(textBox1.Text.ToString()); }));
            long Result = 1;
            for (int i = Number; i >= 1; i--)
            {
                Result *= i;
            }

            textBox3.Invoke(new Action(() => { textBox3.Text = Result.ToString(); }));
            turn = false;
            label3.Invoke(new Action(() => { label3.Text=""; }));
        }

        public void PlaySound()
        {
            label3.Invoke(new Action(() => { label3.Text = "Работает процесс 1"; }));
            int n = 0;
            textBox2.Invoke(new Action(() => { n = int.Parse(textBox2.Text.ToString()); }));
            SoundPlayer sd = new SoundPlayer("success.wav");
            for (int i = 0; i < n; i++)
            {
                sd.PlaySync();
            }
            turn = true;
            label3.Invoke(new Action(() => { label3.Text = ""; }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Factorial);
            if (turn)
            {
                thread.Start();
            }
            else MessageBox.Show("Очередь другого процесса!!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(PlaySound);
            if (!turn)
            {
                thread.Start();
            }
            else MessageBox.Show("Очередь другого процесса!!!");
        }
    }
}
