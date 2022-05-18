using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testesDonaMariana.WinApp.Modulos.DisciplinaMol.ColetaDados;
using testesDonaMariana.WinApp.Shared;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;
using TestesDonaMariana.Domain.TesteDir;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;
using testesDonaMriana.Controlador.QuestaoControl;
using testesDonaMriana.Controlador.TesteControl;

namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.Configuracoes
{
    public class AcoesDisciplina : ICadastravel
    {
        ControladorDisciplina controladorDisciplina;
        ControladorQuestao controladorQuestao;
        ControladorMateria controladorMateria;
        ControladorTeste controladorTeste;


        TabelaListaDisciplina tabelaListaDisciplina;
        public AcoesDisciplina(ControladorDisciplina control, ControladorMateria controlMate,ControladorQuestao controlQuest, ControladorTeste controlTeste)
        {
            this.controladorDisciplina = control;
            this.controladorMateria = controlMate;
            this.controladorQuestao = controlQuest;
            this.controladorTeste = controlTeste;
            this.tabelaListaDisciplina= new TabelaListaDisciplina();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaListaDisciplina.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Disciplina para poder editar!", "Edição de Contatos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Disciplina disciplinaSelecionada = controladorDisciplina.SelecionarPorId(id);

            CadastroDisciplinaForm tela = new CadastroDisciplinaForm(controladorMateria,controladorDisciplina);

            tela.Disciplina = disciplinaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorDisciplina.Editar(id, tela.Disciplina);

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodos().Cast<EntidadeBase>().ToList(); ;

                tabelaListaDisciplina.AtualizarRegistros(disciplinas);

                TelaPrincipal.Instancia.AtualizarRodape($"Disciplina: [{tela.Disciplina.Nome}] editada com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaListaDisciplina.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma Disciplina para poder excluir!", "Exclusão de Disciplinas",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Disciplina disciplinaSelecionada = controladorDisciplina.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Disciplina: [{disciplinaSelecionada.Nome}] ?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                Disciplina disc = controladorDisciplina.SelecionarPorId(id);

                RemoverTodosOsItensComReferencia(disc);

                controladorDisciplina.Excluir(id);

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaListaDisciplina.AtualizarRegistros(disciplinas);

                TelaPrincipal.Instancia.AtualizarRodape($"disciplina: [{disciplinaSelecionada.Nome}] removida com sucesso");
            }
        }

        private void RemoverTodosOsItensComReferencia(Disciplina disc)
        {
            foreach(Materia mat in disc.ListaMaterias)
            {
                foreach(Questao quest in mat.ListaQuestoes)
                {
                    controladorQuestao.Excluir(quest._id);
                }

                foreach(Teste teste in controladorTeste.SelecionarTodos())
                {
                    if(teste.Disciplina._id == disc._id) controladorTeste.Excluir(teste._id);
                }

                controladorMateria.Existe(mat._id);
            }


        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            CadastroDisciplinaForm tela = new CadastroDisciplinaForm(controladorMateria, controladorDisciplina);

            tela.Disciplina = new Disciplina();
            

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorDisciplina.InserirNovo(tela.Disciplina);

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaListaDisciplina.AtualizarRegistros(disciplinas);

                TelaPrincipal.Instancia.AtualizarRodape($"Disciplina: [{tela.Disciplina.Nome}] inserida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<EntidadeBase> compromissos = controladorDisciplina.SelecionarTodos().Cast<EntidadeBase>().ToList();

            tabelaListaDisciplina.AtualizarRegistros(compromissos);

            return tabelaListaDisciplina;
        }
    }
}
