using Model;
using Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class FilmeEditar : Form
    {
        public FilmeEditar()
        {
            InitializeComponent();
        }

        public FilmeEditar (Filme filme)
        {
            InitializeComponent();
            txtNome.Text = filme.Nome;
            txtCodigo.Text = filme.Id.ToString();
            txtAvaliacao.Text = Convert.ToString(filme.Avaliacao);
            txtDuracao.Text = filme.Duracao.ToString("yyyy-MM-dd hh:mm:ss");

            cbCategoria.SelectedItem = filme.Categoria;
            ckbTemSequencia.Checked = filme.TemSequencia;
            if (filme.Curtiu)
            {
                rbtSim.Checked = true;
            }
            else
            {
                rbtNao.Checked = true;
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Filme filme = new Filme();
            filme.Id = Convert.ToInt32(txtCodigo.Text);
            filme.Nome = txtNome.Text;
            filme.Curtiu = rbtSim.Checked;
            filme.TemSequencia = ckbTemSequencia.Checked;
            filme.Duracao = Convert.ToDateTime(txtDuracao.Text);
            filme.Avaliacao = Convert.ToDecimal(txtAvaliacao.Text);
            filme.Categoria = cbCategoria.SelectedIndex.ToString();
            FilmeRepositorio repositorio = new FilmeRepositorio();
            repositorio.Atualizar(filme);

            MessageBox.Show("Editado com sucesso");
            Close();
        }
    }
}
