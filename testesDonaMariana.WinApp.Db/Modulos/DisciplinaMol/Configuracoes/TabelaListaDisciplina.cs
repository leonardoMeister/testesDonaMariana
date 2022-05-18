using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testesDonaMariana.WinApp.Shared;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.Shared;

namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.Configuracoes
{
    public partial class TabelaListaDisciplina : UserControl, IConfiguravelDataGridView
    {
        public TabelaListaDisciplina()
        {
            InitializeComponent();
            gridDisciplina.ConfigurarGridZebrado();
            gridDisciplina.ConfigurarGridSomenteLeitura();
            gridDisciplina.Columns.AddRange(ObterColunas());

        }

        public void AtualizarRegistros(List<EntidadeBase> disciplinas)
        {
            gridDisciplina.Rows.Clear();

            foreach (Disciplina disciplina in disciplinas)
            {
                gridDisciplina.Rows.Add(disciplina._id.ToString(), disciplina.Nome, disciplina.AnoLetivo, disciplina.ListaMaterias.Count);
            }
        }

        public int ObtemIdSelecionado()
        {
            return gridDisciplina.SelecionarId<int>();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
                                    {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome"},

                new DataGridViewTextBoxColumn { DataPropertyName = "AnoLetivo", HeaderText = "Ano Letivo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NumeroMaterias", HeaderText = "Numero Materias"}

                                    };

            return colunas;
        }
    }
}
