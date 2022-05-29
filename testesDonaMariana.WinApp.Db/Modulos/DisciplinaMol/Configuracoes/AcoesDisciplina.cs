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
using testesDonaMriana.Controlador.Db.QuestaoControl;
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
        public AcoesDisciplina()
        {
            this.controladorDisciplina = new ControladorDisciplina();
            this.controladorMateria = new ControladorMateria();
            this.controladorQuestao = new ControladorQuestao();
            this.controladorTeste = new ControladorTeste();
            this.tabelaListaDisciplina = new TabelaListaDisciplina();
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

            Disciplina disciplinaSelecionada = controladorDisciplina.SelecionarDisciplinaComReferenciaPorId(id);

            CadastroDisciplinaForm tela = new CadastroDisciplinaForm();

            tela.Disciplina = disciplinaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorDisciplina.Editar(id, tela.Disciplina);

                foreach (Materia mate in tela.Disciplina.ListaMaterias)
                {
                    controladorMateria.AtualizarMateria(mate);
                }

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodasDisciplinasComMateriaEQuestao().Cast<EntidadeBase>().ToList();

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

            Disciplina disciplinaSelecionada = controladorDisciplina.SelecionarDisciplinaComReferenciaPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a Disciplina: [{disciplinaSelecionada.Nome}] ?",
                "Exclusão de Disciplinas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                RemoverTodosOsItensComReferencia(disciplinaSelecionada);

                controladorDisciplina.Excluir(id);

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodasDisciplinasComMateriaEQuestao().Cast<EntidadeBase>().ToList();

                tabelaListaDisciplina.AtualizarRegistros(disciplinas);

                TelaPrincipal.Instancia.AtualizarRodape($"disciplina: [{disciplinaSelecionada.Nome}] removida com sucesso");
            }
        }

        private void RemoverTodosOsItensComReferencia(Disciplina disc)
        {
            controladorTeste.ExcluirTodosTestesDeDisciplina(disc._id);
            foreach (Materia mat in disc.ListaMaterias)
            {
                foreach (Questao quest in mat.ListaQuestoes)
                {
                    new ControladorAlternativa().Excluir(quest._id);                    
                }               
                controladorMateria.RemoverReferenciaBimestresMateria(mat._id);
                controladorQuestao.ExcluirQuestoesPorMateriaId(mat._id);
            }
                       
            controladorMateria.ExcluirMateriasPorDisciplina(disc._id);


        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            CadastroDisciplinaForm tela = new CadastroDisciplinaForm();

            tela.Disciplina = new Disciplina();


            if (tela.ShowDialog() == DialogResult.OK)
            {
                controladorDisciplina.InserirNovo(tela.Disciplina);

                foreach (Materia mate in tela.Disciplina.ListaMaterias)
                {
                    controladorMateria.InserirNovaMateriaComBimestre(mate);
                }

                List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodasDisciplinasComMateriaEQuestao().Cast<EntidadeBase>().ToList();

                tabelaListaDisciplina.AtualizarRegistros(disciplinas);

                TelaPrincipal.Instancia.AtualizarRodape($"Disciplina: [{tela.Disciplina.Nome}] inserida com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<EntidadeBase> disciplinas = controladorDisciplina.SelecionarTodasDisciplinasComMateriaEQuestao().Cast<EntidadeBase>().ToList();

            tabelaListaDisciplina.AtualizarRegistros(disciplinas);

            return tabelaListaDisciplina;
        }
    }
}
