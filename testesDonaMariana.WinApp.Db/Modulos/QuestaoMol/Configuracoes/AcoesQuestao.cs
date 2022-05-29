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
using testesDonaMriana.Controlador.Db.QuestaoControl;
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

            Questao questaoSelecionada = new ControladorDisciplina().SelecionarQuestaoComReferenciaPorId(id);
            
            
            CadastroQuestaoForm tela = new CadastroQuestaoForm();

            tela.Questao = questaoSelecionada;
            
            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorQuestao.Editar(id, tela.Questao);

                new ControladorAlternativa().Excluir(id);
                foreach (Alternativa alt in tela.Questao.ListaAlternativas)
                {
                    new ControladorAlternativa().InserirNovo(alt);
                }

                List<EntidadeBase> questoes = controladorQuestao.SelecionarTodasQuestoesComReferencia().Cast<EntidadeBase>().ToList();

                tabelaQuestao.AtualizarRegistros(questoes);

                TelaPrincipal.Instancia.AtualizarRodape($"Questão: [{tela.Questao.Enunciado}] editada com sucesso");
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



            if (MessageBox.Show($"Tem certeza que deseja excluir a Questão?",
                "Exclusão de Questões", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                new ControladorAlternativa().Excluir(id);
                controladorQuestao.Excluir(id);

                List<EntidadeBase> questoes = controladorQuestao.SelecionarTodasQuestoesComReferencia().Cast<EntidadeBase>().ToList();

                tabelaQuestao.AtualizarRegistros(questoes);

                TelaPrincipal.Instancia.AtualizarRodape($"Questão removida com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            CadastroQuestaoForm tela = new CadastroQuestaoForm( );
            //tela.Questao = new Questao();
            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorQuestao.InserirNovo(tela.Questao);

                ControladorAlternativa controladorAlternativa = new ControladorAlternativa();

                foreach(Alternativa alt in tela.Questao.ListaAlternativas)
                {
                    alt.Quest = tela.Questao;
                    controladorAlternativa.InserirNovo(alt);
                }

                List<EntidadeBase> questoes = controladorQuestao.SelecionarTodasQuestoesComReferencia().Cast<EntidadeBase>().ToList();

                tabelaQuestao.AtualizarRegistros(questoes);

                TelaPrincipal.Instancia.AtualizarRodape($"Questao: [{tela.Questao.Enunciado}] inserida com sucesso");
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
