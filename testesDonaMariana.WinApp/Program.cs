using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestesDonaMariana.Serializador.Shared;

namespace testesDonaMariana.WinApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            

            if (File.Exists("ContextoDadosDomain.json") == false)
            {
                MessageBox.Show("Criando Arquivo Serializador.");
                File.Create("ContextoDadosDomain.json");
                return;
            }
            
            DataContextDadosDomain data = new DataContextDadosDomain();
            data = data.CarregarTarefasDoArquivo();

            try
            {
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TelaPrincipal(data));
            }
            catch (Exception )
            {

            }
            finally
            {
                data.GravarTarefasEmArquivo(data);
            }
        }
    }
}
