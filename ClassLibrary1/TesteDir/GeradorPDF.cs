using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using TestesDonaMariana.Domain.QuestaoDir;

namespace TestesDonaMariana.Domain.TesteDir
{
    public class GeradorPDF
    {
        public string Caminho { get; set; }
        public Teste Teste { get; set; }

        public GeradorPDF(string caminho, Teste teste)
        {
            this.Caminho = caminho;
            this.Teste = teste;
        }
        public void CriarPDF()
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 80);

            PdfWriter write = PdfWriter.GetInstance(doc, new FileStream(Caminho, FileMode.Create));

            doc.Open();

            Paragraph titulo = new Paragraph();
            titulo.Font = new Font(Font.FontFamily.COURIER, 40);
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.Add(Teste.NomeProva + "\n\n\n");
            doc.Add(titulo);


            int numeroQuestao = 1;
            foreach (Questao item in Teste.ListaQuestoesDoTeste)
            {
                Paragraph paragrafo = new Paragraph();
                string questao = numeroQuestao.ToString() + "- " + item.Enunciado + "\n";

                foreach (var Alternativa in item.ListaAlternativas)
                {
                    questao += "-" + Alternativa + "\n";
                }
                paragrafo.Add(questao);
                doc.Add(paragrafo);

                numeroQuestao++;
            }

            doc.Close();

            ProcessStartInfo info = new ProcessStartInfo(Caminho);
            

        }
    }
}
