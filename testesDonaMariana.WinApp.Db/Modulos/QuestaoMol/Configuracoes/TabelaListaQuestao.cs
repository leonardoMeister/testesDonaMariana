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
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;

namespace testesDonaMariana.WinApp.Modulos.QuestaoMol.Configuracoes
{
    public partial class TabelaListaQuestao : UserControl, IConfiguravelDataGridView
    {
        public TabelaListaQuestao()
        {
            InitializeComponent();
            gridQuestao.ConfigurarGridZebrado();
            gridQuestao.ConfigurarGridSomenteLeitura();
            gridQuestao.Columns.AddRange(ObterColunas());
        }

        public void AtualizarRegistros(List<EntidadeBase> questaos)
        {
            gridQuestao.Rows.Clear();

            foreach (Questao questao in questaos)
            {
                gridQuestao.Rows.Add(questao._id, questao.Enunciado, questao.RespostaCorreta,
                    questao.Disciplina.Nome, questao.Materia.Nome, questao.ListaAlternativas.Count);
            }
        }

        public int ObtemIdSelecionado()
        {
            return gridQuestao.SelecionarId<int>();
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
                                               { 
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Enunciado", HeaderText = "Enunciado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "AlternativaCorreta", HeaderText = "Alternativa Correta"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Disciplina", HeaderText = "Disciplina"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Materia", HeaderText = "Materia"},
               
                new DataGridViewTextBoxColumn {DataPropertyName = "NumeroAlternativas", HeaderText = "Nº Alternativas"}


                                               };

            return colunas;
        }
    }
}
