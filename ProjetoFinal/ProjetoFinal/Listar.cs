﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoFinal
{
    public partial class Listar : Form
    {
        public Listar()
        {
            InitializeComponent();
        }

        private void Listar_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database2DataSet1.Palavras' table. You can move, or remove it, as needed.
            this.palavrasTableAdapter.Fill(this.database2DataSet1.Palavras);

        }
    }
}
