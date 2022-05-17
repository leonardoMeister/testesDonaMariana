using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testesDonaMariana.WinApp.Modulos.QuestaoMol.ColetaDados;
using testesDonaMariana.WinApp.Shared;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.QuestaoControl;

namespace testesDonaMariana.WinApp.Modulos.QuestaoMol.Configuracoes
{
    public class AcoesQuestao : ICadastravel
    {
        private readonly ControladorQuestao controladorQuestao;
        private readonly TabelaListaQuestao tabelaQuestao;
        private readonly ControladorDisciplina controladorDisc;
        public AcoesQuestao(ControladorQuestao controlador,ControladorDisciplina controlDisc)
        {
            
            this.controladorDisc = controlDisc;
            this.controladorQuestao = controlador;
            this.tabelaQuestao = new TabelaListaQuestao(); ;
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaQuestao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Questao para poder editar!", "Edição de Questões",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Questao questaoSelecionada = controladorQuestao.SelecionarPorId(id);

            CadastroQuestaoForm tela = new CadastroQuestaoForm(controladorDisc,controladorQuestao);

            tela.Questao = questaoSelecionada;
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorQuestao.Editar(id, tela.Questao);

                List<EntidadeBase> questoes = controladorQuestao.SelecionarTodos().Cast<EntidadeBase>().ToList(); ;

                tabelaQuestao.AtualizarRegistros(questoes);

                TelaPrincipal.Instancia.AtualizarRodape($"Questão: [{tela.Questao.Titulo}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaQuestao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Questão para poder excluir!", "Exclusão de Questões",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Questao questaoSelecionada = controladorQuestao.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Questão: [{questaoSelecionada.Titulo}] ?",
                "Exclusão de Questões", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controladorQuestao.Excluir(id);

                List<EntidadeBase> questoes = controladorQuestao.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaQuestao.AtualizarRegistros(questoes);

                TelaPrincipal.Instancia.AtualizarRodape($"questão: [{questaoSelecionada.Titulo}] removida com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            CadastroQuestaoForm tela = new CadastroQuestaoForm(controladorDisc,controladorQuestao);

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorQuestao.InserirNovo(tela.Questao);

                List<EntidadeBase> questoes = controladorQuestao.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaQuestao.AtualizarRegistros(questoes);

                TelaPrincipal.Instancia.AtualizarRodape($"Questao: [{tela.Questao.Titulo}] inserida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<EntidadeBase> questoes = controladorQuestao.SelecionarTodos().Cast<EntidadeBase>().ToList();

            tabelaQuestao.AtualizarRegistros(questoes);

            return tabelaQuestao;
        }
    }
}
