using eAgenda.Controladores.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.TesteDir;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.TesteControl;

namespace testesDonaMariana.WinApp.Modulos.TesteMol.ColetaDados
{
    public partial class CadastroTesteForm : Form
    {
        private Teste teste;
        private ControladorDisciplina controladorDisciplina;
        private ControladorTeste controladorTeste;

        public CadastroTesteForm(ControladorDisciplina controlDisci, ControladorTeste controladorTeste)
        {
            InitializeComponent();
            this.controladorDisciplina = controlDisci;
            this.controladorTeste = controladorTeste;
            CarregarAnosLetivos();
            grupoTeste.Enabled = false;
            lista1.Enabled = true;
        }

        private void CarregarAnosLetivos()
        {
            foreach (AnoLetivoEnum ano in Enum.GetValues(typeof(AnoLetivoEnum)))
            {
                comboAnoLetivo.Items.Add(ano);
            }
        }



        public Teste Teste
        {
            get { return teste; }
            set
            {
                this.teste = value;
                
                SelecionarAnoCorrespondenteTeste(teste);
                
                SelecionarDisciplinaCorrespondenteTeste(teste); 
                
                SelecionarMateriasCorrespondenteTeste(teste); 
                txtNumeroQuestoes.Text = teste.NumeroQuestoes.ToString();
                txtNomeTeste.Text = teste.NomeProva;
            }
        }

        private void SelecionarAnoCorrespondenteTeste(Teste aux)
        {
            foreach (AnoLetivoEnum ano in comboAnoLetivo.Items) 
            {
                if(ano == teste.AnoLetivo) comboAnoLetivo.SelectedItem = ano;
            }   
        }

        private void SelecionarDisciplinaCorrespondenteTeste(Teste aux)
        {
            foreach (Disciplina disci in comboDisciplina.Items)
            {
                if (disci == teste.Disciplina) comboDisciplina.SelectedItem = disci;
            }
        }

        private void SelecionarMateriasCorrespondenteTeste(Teste aux)
        {

            lista1.Items.Clear();
            lista2.Items.Clear();

            Disciplina disc = (Disciplina)comboDisciplina.SelectedItem;

            foreach (Materia mat in disc.ListaMaterias)
            {

                lista1.Items.Add(mat);

            }

        }

        private void comboAnoLetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDisciplinas();
            LimparCombos();
        }

        private void LimparCombos()
        {

            lista1.Items.Clear();
            lista2.Items.Clear();
            grupoTeste.Enabled = false;
        }

        private void CarregarDisciplinas()
        {
            comboDisciplina.Items.Clear();

            AnoLetivoEnum ano = (AnoLetivoEnum)comboAnoLetivo.SelectedItem;

            List<Disciplina> listaDisci = controladorDisciplina.SelecionarDisciplinasPorAno(ano);

            if (listaDisci.Count > 0)
            {
                comboDisciplina.Enabled = true;

                foreach (Disciplina disciplina in listaDisci)
                {
                    comboDisciplina.Items.Add(disciplina);
                }
            }
            else
            {
                CancelarOperacao();
                MessageBox.Show("Nenhuma Disciplina Localizada Para Este ano, Tente Novamente.");
            }
        }

        private void CancelarOperacao()
        {
            comboDisciplina.Items.Clear();
            comboDisciplina.Enabled = false;
            lista1.Items.Clear();
            lista2.Items.Clear();

        }

        private void comboDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarMaterias();
        }

        private void CarregarMaterias()
        {
            lista1.Items.Clear();
            lista2.Items.Clear();

            Disciplina disc = (Disciplina)comboDisciplina.SelectedItem;

            foreach (Materia mat in disc.ListaMaterias)
            {
                lista1.Items.Add(mat);
            }


        }


        private void lista1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(lista1.SelectedItem is null))
            {
                Materia mate = (Materia)lista1.SelectedItem;

                if (mate.ListaQuestoes.Count < 5) MessageBox.Show("Materia Selecionada não possui a quantidade minima de questoes, tente novamente.");
                else
                {
                    lista1.Items.Remove(mate);
                    lista2.Items.Add(mate);

                    grupoTeste.Enabled = true;
                }

            }

        }

        private void lista2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!(lista2.SelectedItem is null))
            {
                Materia mate = (Materia)lista2.SelectedItem;
                lista2.Items.Remove(mate);
                lista1.Items.Add(mate);
                if(lista2.Items.Count == 0) grupoTeste.Enabled=false;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            AnoLetivoEnum ano = (AnoLetivoEnum)comboAnoLetivo.SelectedItem ;
            Disciplina disciplina= (Disciplina) comboDisciplina.SelectedItem;
            List<Materia> listaMaterias = lista2.Items.Cast<Materia>().ToList();
            List<Questao> listaQuestaos = PegarListaQuestoes(listaMaterias);

            int numeroQuestoesProva = 0;
            if (txtNumeroQuestoes.Text !="") numeroQuestoesProva= Convert.ToInt32(txtNumeroQuestoes.Text);

            Teste teste = new Teste(ano,disciplina,listaMaterias,txtNomeTeste.Text,listaQuestaos,numeroQuestoesProva);

            var validacao = new ValidarTeste(teste,controladorTeste.SelecionarTodos()).Validate(teste);

            if (validacao.IsValid == false)
            {
                string erro = validacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro);
            }else if (teste.ListaQuestoesDisponiveisParaProva.Count< teste.NumeroQuestoes)
            {
                MessageBox.Show("Não pode criar um Teste com mais questoes que o maximo de questões nas matérias selecionadas.");
            }
            else
            {
                this.teste = teste;
                teste.GerarProva();
                this.DialogResult = DialogResult.OK;
            }
        }

        private List<Questao> PegarListaQuestoes(List<Materia> listaMateria)
        {
            List<Questao> listaQuestaos = new List<Questao>();
            foreach(Materia materia in listaMateria)
            {
                foreach(Questao quest in materia.ListaQuestoes)
                {
                    listaQuestaos.Add(quest);
                }
            }
            return listaQuestaos;
        }
    }
}
