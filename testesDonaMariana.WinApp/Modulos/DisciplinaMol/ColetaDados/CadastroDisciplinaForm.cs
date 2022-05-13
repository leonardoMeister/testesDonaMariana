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
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.Shared;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;


namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.ColetaDados
{
    public partial class CadastroDisciplinaForm : Form
    {
        ControladorMateria controladorMateria;
        private Disciplina disciplina;
        private Materia materiaSelecionada;
        public Disciplina Disciplina
        {
            get { return disciplina; }
            set
            {
                disciplina = value;
                if (disciplina.Nome != "")
                {
                    txtNome.Text = disciplina.Nome;
                    SelecionarComboAnoLetivo();
                    AtualizarListaMaterias();
                    }

            }
        }
        private void SelecionarComboAnoLetivo()
        {
            foreach(string ano in comboAnoLetivo.Items)
            {
                if (disciplina.AnoLetivo.ToString() == ano) comboAnoLetivo.SelectedItem = ano;
            }
        }
        public CadastroDisciplinaForm(ControladorMateria controlMate)
        {
            InitializeComponent();
            this.controladorMateria = controlMate;
            EsconderMensagensErro();
            CarregarListaAnos();
        }
        private void EsconderMensagensErro()
        {
            valida1.Visible = false;
            valida2.Visible = false;
            valida3.Visible = false;
            valida4.Visible = false;
        }
        private void CarregarListaAnos()
        {
            comboAnoLetivo.Items.Clear();
            foreach (string item in Enum.GetNames(typeof(AnoLetivoEnum)))
            {
                comboAnoLetivo.Items.Add(item);
            }

        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            disciplina.Nome = txtNome.Text;
            string anoletivo = comboAnoLetivo.Text;

            if (anoletivo == AnoLetivoEnum.PrimeiroAno.ToString())
                disciplina.AnoLetivo = AnoLetivoEnum.PrimeiroAno;
            if (anoletivo == AnoLetivoEnum.SegundoAno.ToString())
                disciplina.AnoLetivo = AnoLetivoEnum.SegundoAno;

            disciplina.ListaMaterias = listaMaterias.Items.Cast<Materia>().ToList();



            var validacao = new ValidadorDisciplina().Validate(disciplina);

            if (validacao.IsValid == false)
            {
                string erro = validacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
        private void btnRemover_Click(object sender, EventArgs e)
        {

            var resultadoValidacao = controladorMateria.Excluir(materiaSelecionada._id);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;
                MessageBox.Show(erro);
            }
            else
            {
                disciplina.RemoverMateria(materiaSelecionada);
            }
            LimparCamposMateria();
            AtualizarListaMaterias();
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (btnAdicionar.Text == "Editar") EditarMateriaExistenta();
            else if (btnAdicionar.Text == "Adicionar") AdicionarMateriaNova();

            LimparCamposMateria();
        }
        private void EditarMateriaExistenta()
        {
            Materia mate = PegarMateria(new Materia());

            var validacao = controladorMateria.Editar(materiaSelecionada._id, mate);

            if (validacao.IsValid == false)
            {
                string erro = validacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro);
            }
            else
            {
                disciplina.RemoverMateria(materiaSelecionada);
                disciplina.AdicionarMateria(mate);

                AtualizarListaMaterias();
            }

        }
        private void AdicionarMateriaNova()
        {
            Materia mat = PegarMateria();

            var validacao = controladorMateria.InserirNovo(mat);

            if (validacao.IsValid == false)
            {
                string erro = validacao.Errors[0].ErrorMessage;

                MessageBox.Show(erro);
            }
            else
            {
                disciplina.AdicionarMateria(mat);
                AtualizarListaMaterias();
            }
        }
        private Materia PegarMateria(Materia materia = null)
        {
            if (materia == null)
            {
                string nomeMateria = txtNomeMateria.Text;
                List<BimestreEnum> listaBimestres = new List<BimestreEnum>();

                if (box1.Checked is true) listaBimestres.Add(BimestreEnum.PrimeiroBimestre);
                if (box2.Checked is true) listaBimestres.Add(BimestreEnum.SegundoBimestre);
                if (box3.Checked is true) listaBimestres.Add(BimestreEnum.TerceiroBimestre);
                if (box4.Checked is true) listaBimestres.Add(BimestreEnum.QuartoBimestre);

                Materia mat = new Materia(listaBimestres, nomeMateria);
                return mat;
            }
            else
            {
                string nomeMateria = txtNomeMateria.Text;
                List<BimestreEnum> listaBimestres = new List<BimestreEnum>();

                if (box1.Checked is true) listaBimestres.Add(BimestreEnum.PrimeiroBimestre);
                if (box2.Checked is true) listaBimestres.Add(BimestreEnum.SegundoBimestre);
                if (box3.Checked is true) listaBimestres.Add(BimestreEnum.TerceiroBimestre);
                if (box4.Checked is true) listaBimestres.Add(BimestreEnum.QuartoBimestre);

                materia.Nome = nomeMateria;
                materia.ListaBimestres = listaBimestres;

                return materia;
            }
        }
        private void AtualizarListaMaterias()
        {
            listaMaterias.Items.Clear();
            foreach (Materia materia in disciplina.ListaMaterias)
            {
                listaMaterias.Items.Add(materia);
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCamposMateria();
        }
        private void LimparCamposMateria()
        {
            LimpaBoxBimestres();
            txtNomeMateria.Text = "";
            listaMaterias.SelectedItem = -1;
            EscondeBtnsMensagemErroMateria();
            materiaSelecionada = null;
            btnAdicionar.Text = "Adicionar";
        }
        private void EscondeBtnsMensagemErroMateria()
        {
            valida3.Visible = false;
            valida4.Visible = false;
        }
        private void LimpaBoxBimestres()
        {
            box1.Checked = false;
            box2.Checked = false;
            box3.Checked = false;
            box4.Checked = false;
        }
        private void listaMaterias_SelecionouUmItemNaLista(object sender, EventArgs e)
        {
            LimparCamposMateria();
            if (!(listaMaterias.SelectedItem is null))
            {

                Materia materia = (Materia)listaMaterias.SelectedItem;
                materiaSelecionada = materia;
                btnAdicionar.Text = "Editar";
                txtNomeMateria.Text = materia.Nome;
                List<BimestreEnum> lista = materia.ListaBimestres;

                foreach (BimestreEnum item in lista)
                {
                    if (item == BimestreEnum.PrimeiroBimestre) box1.Checked = true;
                    if (item == BimestreEnum.SegundoBimestre) box2.Checked = true;
                    if (item == BimestreEnum.TerceiroBimestre) box3.Checked = true;
                    if (item == BimestreEnum.QuartoBimestre) box4.Checked = true;
                }
            }
            else
            {
                MessageBox.Show("Selecione uma Materia na lista.");
            }

        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            RemoverMateriasControlador();
        }
        private void RemoverMateriasControlador()
        {
            foreach (Materia materia in listaMaterias.Items)
            {
                controladorMateria.Excluir(materia._id);
            }
        }
    }
}
