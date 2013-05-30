using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inserir frm = new Inserir();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Eliminar frm = new Eliminar();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listar frm = new Listar();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Alterar frm = new Alterar();
            frm.ShowDialog();
        }
    }
}
