using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesDonaMariana.WinApp.Shared;

namespace testesDonaMariana.WinApp.Modulos.QuestaoMol.Configuracoes
{
    internal class ConfiguracaoQuestaoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar uma nova Questão";

        public string TipoCadastro => "Cadastro de Questões";

        public string ToolTipEditar => "Editar uma Questão Existente";

        public string ToolTipExcluir => "Excluir uma Questão Existente";

        public string ToolTipoFiltrar => "Filtrar de Questões";

        public bool DessagruparItens => false;

        public bool AgruparItens => false;

        public bool FiltrarItens => false;

        public bool GerarPdf => false;

        public string ToolTipoPdf => "Gerar PDF";

        public bool BtnEditar => false;

        public string ToolTipoClonar => "";

        public bool BtnClonar => false;
    }
}
