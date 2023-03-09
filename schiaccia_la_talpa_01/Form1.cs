using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiaccia_la_talpa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int diff = 0;

        Random random = new Random();

        const int maxOgg = 25;

        PictureBox[] pictureBoxes1 = new PictureBox[maxOgg];
        PictureBox[] pictureBoxes2 = new PictureBox[maxOgg];

        Label score = new Label();

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < maxOgg; i++)
            {
                int x = random.Next(500);
                int y = random.Next(300);
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Image = global::schiaccia_la_talpa_01.Properties.Resources.talpa012;
                pictureBox1.Location = new System.Drawing.Point(x, y);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(313, 224);
                pictureBox1.TabIndex = 2;
                pictureBox1.TabStop = false;
                pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
                pictureBoxes1[i] = pictureBox1;
            }
            for (int i = 0; i < maxOgg; i++)
            {
                int x = random.Next(500);
                int y = random.Next(300);
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Image = global::schiaccia_la_talpa_01.Properties.Resources.talpa012;
                pictureBox1.Location = new System.Drawing.Point(x, y);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(313, 224);
                pictureBox1.TabIndex = 2;
                pictureBox1.TabStop = false;
                pictureBox1.Click += new System.EventHandler(this.pictureBox2_Click);
                pictureBoxes2[i] = pictureBox1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            diff = 0;
            Button button1 = new Button();
            button1.Location = new System.Drawing.Point(250, 150);
            button1.Name = "button3";
            button1.Size = new System.Drawing.Size(100, 50);
            button1.TabIndex = 0;
            button1.Text = "INIZIA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button3_Click);
            this.Controls.Add(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            diff = 1;
            Button button1 = new Button();
            button1.Location = new System.Drawing.Point(250, 150);
            button1.Name = "button3";
            button1.Size = new System.Drawing.Size(100, 50);
            button1.TabIndex = 0;
            button1.Text = "INIZIA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button3_Click);
            this.Controls.Add(button1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            Label label1= new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 16);
            label1.TabIndex = 2;
            label1.Text = "Score:";
            this.Controls.Add(label1);

            score.AutoSize = true;
            score.Location = new System.Drawing.Point(20, 20);
            score.Name = "label1";
            score.Size = new System.Drawing.Size(44, 16);
            score.TabIndex = 2;
            score.Text = "0";
            this.Controls.Add(score);

            timer1.Enabled = true;
            timer1.Start();

            timer2.Enabled = true;
            timer2.Start();

            if (diff == 0)
            {
                timer1.Interval = 800;
                timer2.Interval = 1000;
            }
            else
            {
                timer1.Interval = 400;
                timer2.Interval = 600;
            }

        }
        int tempo1 = 0;
        int tempo2 = 0;
        int pos1 = 0;
        int pos2 = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (tempo1 == 0)
            {
                pos1 = random.Next(maxOgg);
                this.Controls.Add(pictureBoxes1[pos1]);
                tempo1++;
            }
            else
            {
                this.Controls.Remove(pictureBoxes1[pos1]);
                tempo1--;
            }
            
            if(timer1.Interval>400)
            {
                timer1.Interval -= 5;
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (tempo2 == 0)
            {
                pos2 = random.Next(maxOgg);
                this.Controls.Add(pictureBoxes2[pos2]);
                tempo2++;
            }
            else
            {
                this.Controls.Remove(pictureBoxes2[pos2]);
                tempo2--;
            }

            if (timer2.Interval > 400)
            {
                timer2.Interval -= 5;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int punti = int.Parse(score.Text);
            punti++;
            score.Text = punti.ToString();
            this.Controls.Remove(pictureBoxes1[pos1]);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int punti = int.Parse(score.Text);
            punti++;
            score.Text = punti.ToString();
            this.Controls.Remove(pictureBoxes2[pos2]);
        }
    }
}
