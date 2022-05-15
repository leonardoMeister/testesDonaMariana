using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testesDonaMariana.WinApp.Modulos.TesteMol.ColetaDados;
using testesDonaMariana.WinApp.Shared;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;
using TestesDonaMariana.Domain.TesteDir;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.TesteControl;

namespace testesDonaMariana.WinApp.Modulos.TesteMol.Configuracoes
{
    public class AcoesTeste : ICadastravel
    {
        private readonly ControladorTeste controladorTeste;
        private readonly ControladorDisciplina controladorDisciplina;
        private readonly TabelaListaTeste tabelaTestes;

        public AcoesTeste(ControladorTeste controladorTeste, ControladorDisciplina controladorDisciplina)
        {
            this.controladorTeste = controladorTeste;
            this.tabelaTestes = new TabelaListaTeste();
            this.controladorDisciplina = controladorDisciplina;
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }
        public void EditarRegistro()
        {
            int id = tabelaTestes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Teste para poder Duplicar!", "Duplicar Teste",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Teste testeSelecionado = controladorTeste.SelecionarPorId(id);

            CadastroTesteForm tela = new CadastroTesteForm(controladorDisciplina);

            tela.Teste = testeSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorTeste.Editar(id, tela.Teste);

                List<EntidadeBase> testes = controladorTeste.SelecionarTodos().Cast<EntidadeBase>().ToList(); ;

                tabelaTestes.AtualizarRegistros(testes);

                TelaPrincipal.Instancia.AtualizarRodape($"Teste: [{tela.Teste.NomeProva}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaTestes.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Teste para poder excluir!", "Exclusão de Testes",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Teste testeSelecionada = controladorTeste.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Teste: [{testeSelecionada.NomeProva}] ?",
                "Exclusão de Testes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorTeste.Excluir(id);

                List<EntidadeBase> testes = controladorTeste.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaTestes.AtualizarRegistros(testes);

                TelaPrincipal.Instancia.AtualizarRodape($"Teste: [{testeSelecionada.NomeProva}] removido com sucesso");
            }
        }
        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }
        public void InserirNovoRegistro()
        {
            CadastroTesteForm tela = new CadastroTesteForm(controladorDisciplina);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorTeste.InserirNovo(tela.Teste);

                List<EntidadeBase> tarefas = controladorTeste.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaTestes.AtualizarRegistros(tarefas);

                TelaPrincipal.Instancia.AtualizarRodape($"Teste: [{tela.Teste.NomeProva}] inserido com sucesso");
            }
        }
        public UserControl ObterTabela()
        {
            List<EntidadeBase> testes = controladorTeste.SelecionarTodos().Cast<EntidadeBase>().ToList();

            tabelaTestes.AtualizarRegistros(testes);

            return tabelaTestes;
        }

        internal void GerarPDF()
        {
            int id = tabelaTestes.ObtemIdSelecionado();
            Teste teste = controladorTeste.SelecionarPorId(id);

            if (teste == null)
            {
                MessageBox.Show("Selecione um teste primeiro.",
                "Gerar PDF de teste", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pastaSelecioanda = saveFileDialog.FileName;

                    GeradorPDF geradorPdf = new GeradorPDF(pastaSelecioanda, teste);

                    geradorPdf.CriarPDF();
                }
            }
        }
    }
}
