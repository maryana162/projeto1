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
    public partial class frmProduots : Form
    {
        public frmProduots()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void pbxImagem_Click(object sender, EventArgs e)
        {

        }

        String foto;
        conexãobd bd = new conexãobd();
        string sql;
        DateTime data;

        private void btnEscolher_Click(object sender, EventArgs e)
        {
            if(opffoto.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                pbxImagem.Load(opffoto.FileName);
                foto = opffoto.FileName;
                 
            }
        }

        public void Listar()
        {
            sql = "select * from produtos";
            dgvData.DataSource = bd.ConsultarTabelas(sql);
        }

        public void Limpar()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtQuantidade.Clear();
            txtValorUni.Clear();
            dtpData.Text = DateTime.Now.ToString();
            pbxImagem.Load("P:\\TEP\\Terceiro_Trimestre\\semfoto.jpeg");
            txtCodigo.Focus();
            foto = null;
            
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            double valor;
            int qtd;

            if (double.TryParse(txtValorUni.Text, out valor) && int.TryParse(txtQuantidade.Text, out qtd) && foto!=null && txtDescricao.Text!= null)
            {
                foto = foto.Replace(@"\", @"\\");
                data = DateTime.Parse(dtpData.Text);
                sql = string.Format("insert into produtos values(null,'{0}','{1}','{2}','{3}','{4}')", txtDescricao.Text, txtValorUni.Text, txtQuantidade.Text, data.ToString("yyyy-MM-dd"), foto);

                bd.AlterarTabelas(sql);
                MessageBox.Show("Produto inserido com sucesso", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listar();
                Limpar();
            }
            else { MessageBox.Show("Campo com informações em branco ou incorretas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable busca = new DataTable();
            sql = string.Format("select * from produtos where id = '{0}' or descri = '{1}'", txtCodigo.Text, txtDescricao.Text);
            busca = bd.ConsultarTabelas(sql);

            if (busca.Rows.Count > 0)
            {
                txtCodigo.Text = busca.Rows[0]["id"].ToString();
                txtDescricao.Text = busca.Rows[0]["descri"].ToString();
                txtQuantidade.Text = busca.Rows[0]["qtd"].ToString();
                txtValorUni.Text = busca.Rows[0]["valor"].ToString();
                dtpData.Text = busca.Rows[0]["dt"].ToString();
                pbxImagem.Load(busca.Rows[0]["imagem"].ToString());

                foto = busca.Rows[0]["imagem"].ToString();                       
            }

            else
            {
                MessageBox.Show("Produto não encontrado...","Buscar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void frmProduots_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            data = DateTime.Parse(dtpData.Text);
            foto = foto.Replace(@"\",@"\\");
            sql = string.Format("update produtos set descri='{0}', valor = '{1}', qtd='{2}', dt = '{3}', imagem='{4}' where id = '{5}'"
            ,txtDescricao.Text,txtValorUni.Text,txtQuantidade.Text,data.ToString("yyyy-MM-dd"),foto,txtCodigo.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Produto alterado com sucesso...", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Limpar();
            Listar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            sql = string.Format("delete from produtos where id = '{0}'", txtCodigo.Text);
            bd.AlterarTabelas(sql);
            MessageBox.Show("Produto excluído com sucesso...", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            Limpar();
            Listar();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                txtCodigo.Text = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescricao.Text = dgvData.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtValorUni.Text = dgvData.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtQuantidade.Text = dgvData.Rows[e.RowIndex].Cells[3].Value.ToString();
                dtpData.Text = dgvData.Rows[e.RowIndex].Cells[4].Value.ToString();
                pbxImagem.Load(dgvData.Rows[e.RowIndex].Cells[5].Value.ToString());
                foto = dgvData.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }
    }
}
