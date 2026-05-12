using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFiguras
{
    public partial class Form1 : Form
    {
        Figura figuraActual = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbFiguras.Items.Add("Kite");
            cmbFiguras.Items.Add("Octagon");
            cmbFiguras.Items.Add("Pie");
            cmbFiguras.Items.Add("Heart");
            cmbFiguras.Items.Add("Rhombus");

            cmbFiguras.SelectedIndex = 0;

            this.KeyPreview = true;
        }

        private void cmbFiguras_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiguras.SelectedItem.ToString() == "Octagon" ||
                cmbFiguras.SelectedItem.ToString() == "Pie" ||
                cmbFiguras.SelectedItem.ToString() == "Heart")
            {
                txtValor2.Visible = false;
                lblValor2.Visible = false;
            }
            else
            {
                txtValor2.Visible = true;
                lblValor2.Visible = true;
            }
        }

        private void btnDibujar_Click(object sender, EventArgs e)
        {
            double v1, v2 = 0;

            if (!double.TryParse(txtValor1.Text, out v1) || v1 <= 0)
            {
                MessageBox.Show("Valor 1 inválido");
                return;
            }

            if (txtValor2.Visible)
            {
                if (!double.TryParse(txtValor2.Text, out v2) || v2 <= 0)
                {
                    MessageBox.Show("Valor 2 inválido");
                    return;
                }
            }

            switch (cmbFiguras.SelectedItem.ToString())
            {
                case "Kite":
                    figuraActual = new Kite(v1, v2);
                    break;
                case "Octagon":
                    figuraActual = new Octagon(v1);
                    break;
                case "Pie":
                    figuraActual = new Pie(v1);
                    break;
                case "Heart":
                    figuraActual = new Heart(v1);
                    break;
                case "Rhombus":
                    figuraActual = new Rhombus(v1, v2);
                    break;
            }

            lblArea.Text = "Área: " + figuraActual.Area().ToString("0.00");
            lblPerimetro.Text = "Perímetro: " + figuraActual.Perimetro().ToString("0.00");

            pnlDibujo.Invalidate();
        }

        private void pnlDibujo_Paint(object sender, PaintEventArgs e)
        {
            if (figuraActual != null)
            {
                figuraActual.Dibujar(e.Graphics, pnlDibujo.Width, pnlDibujo.Height);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                figuraActual.ty -= 10;

            if (e.KeyCode == Keys.S)
                figuraActual.ty += 10;

            if (e.KeyCode == Keys.Left)
                figuraActual.tx -= 10;

            if (e.KeyCode == Keys.Right)
                figuraActual.tx += 10;


            if (e.KeyCode == Keys.M)
                figuraActual.escala += 0.1;

            if (e.KeyCode == Keys.N)
                figuraActual.escala -= 0.1;

            if (e.KeyCode == Keys.A)
                figuraActual.angulo -= 10;

            if (e.KeyCode == Keys.D)
                figuraActual.angulo += 10;

            pnlDibujo.Invalidate();
        }
    }
}
