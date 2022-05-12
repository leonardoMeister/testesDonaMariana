using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testesDonaMariana.WinApp.Modulos.DisciplinaMol.Configuracoes;
using testesDonaMariana.WinApp.Shared;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;
using testesDonaMriana.Controlador.QuestaoControl;

namespace testesDonaMariana.WinApp
{
    public partial class TelaPrincipal : Form
    {

        private ICadastravel operacoes;

        ControladorMateria controladorMateria;
        ControladorQuestao controladorQuestao;
        ControladorDisciplina controladorDisciplina;
        public static TelaPrincipal Instancia;

        public TelaPrincipal()
        {
            InitializeComponent();
            this.controladorDisciplina = new ControladorDisciplina();
            this.controladorMateria = new ControladorMateria();
            this.controladorQuestao = new ControladorQuestao();

            PopularAplicativo.Popularaplicativo(controladorMateria, controladorDisciplina, controladorQuestao);

            Instancia = this;
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (!(operacoes is null))
                operacoes.InserirNovoRegistro();
            else MessageBox.Show("Selecione uma opção de janela primeiro!");
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!(operacoes is null))
                operacoes.EditarRegistro();
            else MessageBox.Show("Selecione uma opção de janela primeiro!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (!(operacoes is null))
                operacoes.ExcluirRegistro();
            else MessageBox.Show("Selecione uma opção de janela primeiro!");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (!(operacoes is null))
                operacoes.FiltrarRegistros();
            else MessageBox.Show("Selecione uma opção de janela primeiro!");
        }
        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }


        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);

            tabela.Dock = DockStyle.Fill;

        }
        private void ConfigurarToolBox(IConfiguracaoToolBox configuracao)
        {
            labelTipoCadastro.Text = configuracao.TipoCadastro;

            btnAdicionar.ToolTipText = configuracao.ToolTipAdicionar;
            btnEditar.ToolTipText = configuracao.ToolTipEditar;
            btnExcluir.ToolTipText = configuracao.ToolTipExcluir;
            btnFiltrar.ToolTipText = configuracao.ToolTipoFiltrar;

            btnFiltrar.Enabled = configuracao.FiltrarItens;
            btnDessagrupar.Enabled = configuracao.DessagruparItens;
            btnAgrupar.Enabled = configuracao.AgruparItens;

        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDisciplinaToolBox configuracao = new ConfiguracaoDisciplinaToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new AcoesDisciplina(controladorDisciplina, controladorMateria);

            ConfigurarPainelRegistros();
        }

        private void questãoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
