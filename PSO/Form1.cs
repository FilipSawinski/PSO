using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedItem = "Funkcja sin(x)*cos(y)";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            comboBox1.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;
            numericUpDown6.Enabled = false;
            numericUpDown7.Enabled = false;
            label9.Visible = true;
            label9.Refresh();
            Logika logika = new Logika();
            List<Particle> particles = new List<Particle>();
            for (int i = 0; i < numericUpDown4.Value; i++)
            {
                System.Threading.Thread.Sleep(10);
                //numericupdown6 to kontrolka od zakresu
                double x = logika.Losuj((double)numericUpDown6.Value);
                System.Threading.Thread.Sleep(10);
                double y = logika.Losuj((double)numericUpDown6.Value);
                Particle particle = new Particle(x, y);
                particles.Add(particle);
                //Console.WriteLine("Utworzono cz¹steczke o pozycji " + particle.GetPosX() + ", " + particle.GetPosY());
                richTextBox1.AppendText("Utworzono cz¹steczke o pozycji " + particle.GetPosX() + ", " + particle.GetPosY() + "\n");
                richTextBox1.Refresh();
            }
            Point bestglobalposition = new Point();
            double bestglobalsolution;
            bestglobalposition.SetX(particles[0].GetPosX());
            bestglobalposition.SetY(particles[0].GetPosY());
            bestglobalsolution = logika.ObliczDoRownania(bestglobalposition.GetX(), bestglobalposition.GetY(), comboBox1.SelectedIndex);
            richTextBox1.AppendText("Wybrano pierwsz¹ cz¹steczke jako najlepsze rozwi¹zanie: " + bestglobalsolution + "\n");
            richTextBox1.AppendText("Dla punktu X=" + bestglobalposition.GetX() + ", Y=" + bestglobalposition.GetY() + "\n");
            foreach (Particle particle in particles)
            {
                double possiblesolution = logika.ObliczDoRownania(particle.GetPosX(), particle.GetPosY(), comboBox1.SelectedIndex);
                if (possiblesolution < bestglobalsolution)
                {
                    bestglobalsolution = possiblesolution;
                    bestglobalposition.SetX(particle.GetPosX());
                    bestglobalposition.SetY(particle.GetPosY());
                    richTextBox1.AppendText("Znaleziono nowe najlepsze rozwi¹zanie: " + bestglobalsolution  + "\n");
                    richTextBox1.AppendText("Dla punktu X=" + particle.GetPosX() + ", Y=" + particle.GetPosY() + "\n");
                }
            }
            for (int i = 0; i < numericUpDown5.Value; i++)
            {
                bool czyznalazl = false;
                foreach (Particle particle in particles)
                {
                    particle.CalculateNewV(bestglobalposition, (double)numericUpDown1.Value, (double)numericUpDown2.Value, (double)numericUpDown3.Value);
                    particle.Move();
                    double possiblesolution = logika.ObliczDoRownania(particle.GetPosX(), particle.GetPosY(), comboBox1.SelectedIndex);
                    if (possiblesolution < bestglobalsolution)
                    {
                        bestglobalsolution = possiblesolution;
                        bestglobalposition.SetX(particle.GetPosX());
                        bestglobalposition.SetY(particle.GetPosY());
                        richTextBox1.AppendText(i + ". Znaleziono nowe najlepsze rozwi¹zanie: " + bestglobalsolution + "\n");
                        richTextBox1.AppendText("Dla punktu X=" + particle.GetPosX() + ", Y=" + particle.GetPosY() + "\n");
                        richTextBox1.Refresh();
                        czyznalazl = true;
                    }
                }
                if(czyznalazl==false)
                {
                    richTextBox1.AppendText(i + ". Obecne najlepsze rozwi¹zanie to ci¹gle: " + bestglobalsolution + "\n");
                    richTextBox1.AppendText("Dla punktu X=" + bestglobalposition.GetX() + ", Y=" + bestglobalposition.GetY() + "\n");
                    richTextBox1.Refresh();
                }
                czyznalazl = false;
                System.Threading.Thread.Sleep((int)numericUpDown7.Value);
            }
            button1.Enabled = true;
            comboBox1.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            numericUpDown3.Enabled = true;
            numericUpDown4.Enabled = true;
            numericUpDown5.Enabled = true;
            numericUpDown6.Enabled = true;
            numericUpDown7.Enabled = true;
            label9.Visible = false;
            label9.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = (decimal)0.2;
            numericUpDown2.Value = (decimal)0.2;
            numericUpDown3.Value = (decimal)0.2;
            numericUpDown4.Value = (decimal)10;
            numericUpDown5.Value = (decimal)100;
            numericUpDown6.Value = (decimal)1;
            numericUpDown7.Value = (decimal)5;
        }
    }
}
