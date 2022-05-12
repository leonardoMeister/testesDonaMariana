using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testesDonaMariana.WinApp.Modulos.DisciplinaMol.ColetaDados;
using testesDonaMariana.WinApp.Shared;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.Shared;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;

namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.Configuracoes
{
    public class AcoesDisciplina : ICadastravel
    {
        ControladorDisciplina controladorDisciplina;
        ControladorMateria controladorMateria;

        TabelaListaDisciplina tabelaListaDisciplina;
        public AcoesDisciplina(ControladorDisciplina control, ControladorMateria controlMate)
        {
            this.controladorDisciplina = control;
            this.controladorMateria = controlMate;
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

            CadastroDisciplinaForm tela = new CadastroDisciplinaForm(controladorMateria);

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
                controladorDisciplina.Excluir(id);

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodos().Cast<EntidadeBase>().ToList();

                tabelaListaDisciplina.AtualizarRegistros(disciplinas);

                TelaPrincipal.Instancia.AtualizarRodape($"disciplina: [{disciplinaSelecionada.Nome}] removida com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            CadastroDisciplinaForm tela = new CadastroDisciplinaForm(controladorMateria);

            tela.Disciplina = new Disciplina();
            

            if (tela.ShowDialog() == DialogResult.OK)
            {
                tela.Disciplina.GeraId();

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
