//using eAgenda.Dominio.Shared;
//using eAgenda.Dominio.TarefaModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Shared
{
    public interface IConfiguravelDataGridView
    {
        DataGridViewColumn[] ObterColunas();
        int ObtemIdSelecionado();
        //void AtualizarRegistros(List<EntidadeBase> tarefas); 

    }
}
