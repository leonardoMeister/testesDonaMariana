using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesDonaMariana.WinApp.Shared;

namespace testesDonaMariana.WinApp.Modulos.TesteMol.Configuracoes
{
    public class ConfiguracaoTesteToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar um novo Teste";

        public string TipoCadastro => "Cadastro de Teste";

        public string ToolTipEditar => "Editar um Teste Existente";

        public string ToolTipExcluir => "Excluir um Teste Existente";

        public string ToolTipoFiltrar => "Filtro de Testes";

        public bool DessagruparItens => false;

        public bool AgruparItens => false;

        public bool FiltrarItens => false;

        public bool GerarPdf => true;

        public string ToolTipoPdf => "Gerar Pdf de um Teste Existente";

        public bool BtnEditar => false;

        public string ToolTipoClonar => "Criar Novo Teste com Mesma Definição";

        public bool BtnClonar => true;
    }
}
