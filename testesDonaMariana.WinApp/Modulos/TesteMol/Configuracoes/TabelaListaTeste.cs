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
using TestesDonaMariana.Domain.Shared;
using TestesDonaMariana.Domain.TesteDir;

namespace testesDonaMariana.WinApp.Modulos.TesteMol.Configuracoes
{
    public partial class TabelaListaTeste : UserControl, IConfiguravelDataGridView
    {
        public TabelaListaTeste()
        {
            InitializeComponent();
            gridTeste.ConfigurarGridZebrado();
            gridTeste.ConfigurarGridSomenteLeitura();
            gridTeste.Columns.AddRange(ObterColunas());
        }

        public void AtualizarRegistros(List<EntidadeBase> testes)
        {
            gridTeste.Rows.Clear();

            foreach (Teste teste in testes)
            {
                gridTeste.Rows.Add(teste._id, teste.NomeProva, teste.AnoLetivo, teste.NumeroQuestoes, teste.ListaQuestoesDisponiveisParaProva.Count, teste.Disciplina.Nome);
            }
        }

        public int ObtemIdSelecionado()
        {
            return gridTeste.SelecionarId<int>();
        }

        public DataGridViewColumn[] ObterColunas()
        {

            var colunas = new DataGridViewColumn[]
                                   {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeProva", HeaderText = "Nome Prova"},

                new DataGridViewTextBoxColumn { DataPropertyName = "AnoLetivo", HeaderText = "Ano Letivo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NumeroQuestoes", HeaderText = "Numero Questoes"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TotalQuestoesDisponiveis", HeaderText = "Nº Total Questoes Disponiveis"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NomeDisciplina", HeaderText = "Nome Disciplina."}

                                   };

            return colunas;
        }
    }

}
