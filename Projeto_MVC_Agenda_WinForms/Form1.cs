using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_MVC_Agenda_WinForms
{
    public partial class Form1 : Form
    {
        private Contatos agenda;
        private BindingSource bs;

        public Form1()
        {
            InitializeComponent();
            agenda = new Contatos();

            // Contatos iniciais de exemplo
            Data d1 = new Data { Dia = 1, Mes = 1, Ano = 2000 };
            Contato c1 = new Contato("a@a.com", "Lucas", d1);
            agenda.adicionar(c1);

            Data d2 = new Data { Dia = 15, Mes = 5, Ano = 1998 };
            Contato c2 = new Contato("b@b.com", "Maria", d2);
            agenda.adicionar(c2);

            atualizarLista();
        }

        private void atualizarLista()
        {
            listBox1.Items.Clear();
            foreach (Contato c in agenda.Agenda)
            {
                listBox1.Items.Add(c.ToString());
            }

            bs = new BindingSource();
            bs.DataSource = agenda.Agenda;
            dataGridView1.DataSource = bs;

            // Permite editar direto no DataGridView
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAdicionar_Click_1(object sender, EventArgs e)
        {

            try
            {
                string email = txtEmail.Text;
                string nome = txtNome.Text;
                int dia = int.Parse(txtDia.Text);
                int mes = int.Parse(txtMes.Text);
                int ano = int.Parse(txtAno.Text);

                Data dt = new Data { Dia = dia, Mes = mes, Ano = ano };
                Contato novo = new Contato(email, nome, dt);

                if (agenda.adicionar(novo))
                {
                    atualizarLista();
                    MessageBox.Show("Contato adicionado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Já existe um contato com esse email!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar: " + ex.Message);
            }

        }

        private void btnRemover_Click_1(object sender, EventArgs e)
        {

            if (bs.Position >= 0)
            {
                Contato selecionado = (Contato)bs.Current;
                agenda.remover(selecionado);
                atualizarLista();
                MessageBox.Show("Contato removido!");
            }

        }

        private void dataGridView1_CellEndEdit_1(object sender, DataGridViewCellEventArgs e)
        {

            // Atualiza a lista quando o usuário altera algo na tabela
            bs.ResetBindings(false);
            atualizarLista();
            MessageBox.Show("Contato alterado com sucesso!");

        }
    }
}
