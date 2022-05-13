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
using testesDonaMriana.Controlador.DisciplinaControl;

namespace testesDonaMariana.WinApp.Modulos.QuestaoMol.ColetaDados
{
    public partial class CadastroQuestaoForm : Form
    {
        private Questao questao;
        ControladorDisciplina controlDisciplina;

        public Questao Questao
        {
            get { return questao; }
            set
            {
                questao = value;


            }
        }

        public CadastroQuestaoForm(ControladorDisciplina controlDisci)
        {
            InitializeComponent();
            controlDisciplina = controlDisci;
            CarregarAnosLetivos();
        }
        private void CarregarAnosLetivos()
        {
            foreach (AnoLetivoEnum ano in Enum.GetValues(typeof(AnoLetivoEnum)))
            {
                comboAnoLetivo.Items.Add(ano);
            }
        }
        private void CarregarMaterias()
        {
            comboMateria.Items.Clear();

            Disciplina disc = (Disciplina)comboDisciplina.SelectedItem;

            foreach (Materia mat in disc.ListaMaterias)
            {
                comboMateria.Items.Add(mat);
            }
            comboMateria.Enabled = true;
        }
        private void CarregarDisciplinas()
        {
            comboDisciplina.Items.Clear();

            AnoLetivoEnum ano = (AnoLetivoEnum)comboAnoLetivo.SelectedItem;

            List<Disciplina> listaDisci = controlDisciplina.SelecionarDisciplinasPorAno(ano);

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
            comboMateria.Items.Clear();
            comboMateria.Enabled = false;
            grupoQuestao.Enabled = false;
        }
        private void comboAnoLetivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDisciplinas();
            LimparCombos();
        }
        private void LimparCombos()
        {
            comboMateria.Items.Clear();
            comboMateria.Enabled = false;
            grupoQuestao.Enabled = false;

        }
        private void comboDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarMaterias();
        }
        private void comboMateria_SelectedIndexChanged(object sender, EventArgs e)
        {
            LiberarEdicaoCamposQuestao();
        }
        private void LiberarEdicaoCamposQuestao()
        {
            grupoQuestao.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string auxCampo = txtDescricaoAlternativa.Text;

            if (auxCampo is null or "") MessageBox.Show("Não pode adicionar Alternativa vazia!");
            else
            {
                listaAlternativas.Items.Add(auxCampo);
                txtDescricaoAlternativa.Text = "";
                if (listaAlternativas.Items.Count >= 3) comboAlternativaCorreta.Enabled = true;
            }
            AtualizarComboBoxListaAlternativas();
        }

        private void AtualizarComboBoxListaAlternativas()
        {
            comboAlternativaCorreta.Items.Clear();
            foreach (string aux in listaAlternativas.Items)
            {
                comboAlternativaCorreta.Items.Add(aux);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

            if (listaAlternativas.Items.Count < 3) MessageBox.Show("Para avançar são necessarias 3 Alternativas");
            else
            {
                Materia mate = (Materia)comboMateria.SelectedItem;
                Questao quest = new Questao(txtTitulo.Text, txtEnunciado.Text, listaAlternativas.Items.Cast<String>().ToList(),
                    comboAlternativaCorreta.Text, (Disciplina)comboDisciplina.SelectedItem, mate);

                var validacao = new ValidadorQuestao().Validate(quest);

                if (validacao.IsValid == false)
                {
                    string erro = validacao.Errors[0].ErrorMessage;

                    MessageBox.Show(erro);
                }
                else
                {
                    questao = quest;

                    mate.ListaQuestoes.Add(questao);

                    this.DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
