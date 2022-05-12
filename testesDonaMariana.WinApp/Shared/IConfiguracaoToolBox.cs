﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesDonaMariana.WinApp.Shared
{
    public interface IConfiguracaoToolBox
    {
        string ToolTipAdicionar { get; }
        string TipoCadastro { get; }
        string ToolTipEditar { get; }
        string ToolTipExcluir { get; }
        string ToolTipoFiltrar { get; }
        bool DessagruparItens { get; }
        bool AgruparItens { get; }
        bool FiltrarItens { get; }



    }
}
