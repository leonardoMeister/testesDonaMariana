using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesDonaMariana.WinApp.Shared;

namespace testesDonaMariana.WinApp.Modulos.DisciplinaMol.Configuracoes
{
    public class ConfiguracaoDisciplinaToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar => "Adicionar nova Disciplina";

        public string TipoCadastro => "Cadastro de Disciplina / Materias";

        public string ToolTipEditar => "Editar uma Disciplina Existente";

        public string ToolTipExcluir => "Excluir uma disciplina Existente";

        public string ToolTipoFiltrar => "Filtro de Disciplina";

        public bool FiltrarItens => false;

        public bool DessagruparItens => false;

        public bool AgruparItens => false;
    }
}
