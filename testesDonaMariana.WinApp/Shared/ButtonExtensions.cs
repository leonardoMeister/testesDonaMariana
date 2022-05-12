using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Domain.Shared;

namespace testesDonaMariana.WinApp.Shared
{
    public static class ButtonExtensions
    {
        public static void ConfiguraBotao(this Button button, TipoAcao tipo)
        {
            button.Visible = true;

            if (tipo == TipoAcao.Sucesso) button.Image = global::testesDonaMariana.WinApp.Properties.Resources.Ok_;
            else button.Image = global::testesDonaMariana.WinApp.Properties.Resources.erro;
        }



    }
}
