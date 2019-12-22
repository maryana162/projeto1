using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace produtos29
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        public void AbrirProdutos()
        {
            this.Visible = false;
            frmProduots produots = new frmProduots();
            produots.ShowDialog();
            this.Visible = true;

        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirProdutos();
        }

        private void ptxprodutos_Click(object sender, EventArgs e)
        {
            AbrirProdutos();
        }

        private void lblprodutos_Click(object sender, EventArgs e)
        {
            AbrirProdutos();
        }
    }
}
