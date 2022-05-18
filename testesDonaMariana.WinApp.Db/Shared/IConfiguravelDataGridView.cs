using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Domain.Shared;

namespace testesDonaMariana.WinApp.Shared
{
    public interface IConfiguravelDataGridView
    {
        DataGridViewColumn[] ObterColunas();
        int ObtemIdSelecionado();
        void AtualizarRegistros(List<EntidadeBase> tarefas); 

    }
}
