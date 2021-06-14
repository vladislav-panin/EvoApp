using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace EvoApp
{
    public partial class EvoAppForm : Form
    {
        public EvoAppForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          //this.Paint += new System.Windows.Forms.PaintEventHandler(this.InitGame);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void EvoAppForm_Shown(object sender, EventArgs e)
        {
            this.InitAppIndikator();
        }

        private void EvoAppForm_Paint(object sender, PaintEventArgs e)
        {
           
        }

        //public void InitGame(object sender, System.Windows.Forms.PaintEventArgs e)
        public void InitGame()
        {
            Program.app.Init();
            this.InitAppIndikator();
            Program.app.Run();          
        }

        public void InitAppIndikator()
        {
            lblinit.Text = "игра запущена!";
            lblinit.ForeColor = Color.Green;
            btnStart.Enabled = true;
            btnStop.Enabled = true;
        }

        public void SetCellCount(int count) 
        {
            this.lblCellCount.Text = "количество ячеек: " + Convert.ToString(count);
        }
    }
}
