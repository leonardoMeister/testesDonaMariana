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
using testesDonaMariana.WinApp.Modulos.QuestaoMol.Configuracoes;
using testesDonaMariana.WinApp.Modulos.TesteMol.Configuracoes;
using testesDonaMariana.WinApp.Shared;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;
using testesDonaMriana.Controlador.QuestaoControl;
using testesDonaMriana.Controlador.TesteControl;

namespace testesDonaMariana.WinApp
{
    public partial class TelaPrincipal : Form
    {

        private ICadastravel operacoes;

        ControladorMateria controladorMateria;
        ControladorQuestao controladorQuestao;
        ControladorDisciplina controladorDisciplina;
        ControladorTeste controladorTeste;

        public static TelaPrincipal Instancia;

        public TelaPrincipal()
        {
            InitializeComponent();
            this.controladorDisciplina = new ControladorDisciplina();
            this.controladorMateria = new ControladorMateria();
            this.controladorQuestao = new ControladorQuestao();
            this.controladorTeste = new ControladorTeste();

            PopularAplicativo.Popularaplicativo(controladorMateria, controladorDisciplina, controladorQuestao, controladorTeste);

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
        private void btnClonar_Click(object sender, EventArgs e)
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
        private void btnPDF_Click(object sender, EventArgs e)
        {
            if ((!(operacoes is null)) && operacoes is AcoesTeste)
                ((AcoesTeste)operacoes).GerarPDF();
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
            btnPDF.ToolTipText = configuracao.ToolTipoPdf;
            btnClonar.ToolTipText = configuracao.ToolTipoClonar;

            btnFiltrar.Enabled = configuracao.FiltrarItens;
            btnDessagrupar.Enabled = configuracao.DessagruparItens;
            btnAgrupar.Enabled = configuracao.AgruparItens;
            btnPDF.Enabled = configuracao.GerarPdf;
            btnEditar.Enabled = configuracao.BtnEditar;
            btnClonar.Enabled = configuracao.BtnClonar;
        }

        private void disciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDisciplinaToolBox configuracao = new ConfiguracaoDisciplinaToolBox();

            ConfigurarToolBox(configuracao);

            AtualizarRodape(configuracao.TipoCadastro);

            operacoes = new AcoesDisciplina(controladorDisciplina, controladorMateria, controladorQuestao, controladorTeste);

            ConfigurarPainelRegistros();
        }

        private void questãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controladorDisciplina.SelecionarTodos().Count > 0)
            {
                ConfiguracaoQuestaoToolBox configuracao = new ConfiguracaoQuestaoToolBox();

                ConfigurarToolBox(configuracao);

                AtualizarRodape(configuracao.TipoCadastro);

                operacoes = new AcoesQuestao(controladorQuestao, controladorDisciplina);

                ConfigurarPainelRegistros();
            }
            else MessageBox.Show("Para poder Gerenciar Questões Adicione antes uma Disciplina!");

        }

        private void testesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (controladorQuestao.SelecionarTodos().Count > 0 && controladorDisciplina.SelecionarTodos().Count>0)
            {
                ConfiguracaoTesteToolBox configuracao = new ConfiguracaoTesteToolBox();

                ConfigurarToolBox(configuracao);

                AtualizarRodape(configuracao.TipoCadastro);

                operacoes = new AcoesTeste(controladorTeste, controladorDisciplina);

                ConfigurarPainelRegistros();
            }
            else MessageBox.Show("Para poder Gerenciar Testes Adicione antes uma Disciplina e questoes!");
        }




    }
}
