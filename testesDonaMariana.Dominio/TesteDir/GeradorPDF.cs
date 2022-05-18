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
using iTextSharp.text.pdf.draw;
using TestesDonaMariana.Domain.MateriaDir;

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

        public void CriarPDF2()
        {

            Document document = new Document(PageSize.A4);
            document.SetMargins(25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(Caminho, FileMode.Create, FileAccess.ReadWrite));
            document.Open();

            Font fonte = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 14);

            Paragraph tituloProva = new Paragraph(Teste.NomeProva, fonte);
            tituloProva.Alignment = Element.ALIGN_CENTER;

            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph informacoesProva = new Paragraph($"Disciplina: {Teste.Disciplina.Nome}", fonte);
            informacoesProva.Add(new Chunk(glue));
            informacoesProva.Add($"Matéria(s): ");
            foreach (Materia mate in Teste.ListaMaterias)
            {
                informacoesProva.Add($" {mate.Nome}");
            }/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //Paragraph dataProva = new Paragraph($"Data da Prova: {Teste.Data.Day}/{testeSelecionada.Data.Month}/{testeSelecionada.Data.Year}", fonte);

            document.Add(tituloProva);
            document.Add(informacoesProva);
//            document.Add(dataProva);
            document.Add(new Paragraph(Environment.NewLine));

            for (int i = 0; i < Teste.ListaQuestoesDoTeste.Count; i++)
            {
                Paragraph questao = new Paragraph($"Questão {i + 1}: {Teste.ListaQuestoesDoTeste[i].Enunciado}", fonte);
                document.Add(questao);
                for (int j = 0; j < Teste.ListaQuestoesDoTeste[i].ListaAlternativas.Count; j++)
                {
                    Paragraph alternativaQuestao = new Paragraph($"Opcao {j+1}: {Teste.ListaQuestoesDoTeste[i].ListaAlternativas[j]}", fonte);
                    document.Add(alternativaQuestao);
                }
                //foreach (var alternativa in Teste.ListaQuestoesDoTeste[i].ListaAlternativas)
                //{
                //    Paragraph alternativaQuestao = new Paragraph($"{alternativa.}: {alternativa.Descricao}", fonte);
                //    document.Add(alternativaQuestao);
                //}
                document.Add(new Paragraph(Environment.NewLine));
            }

            document.NewPage();
            Paragraph gabarito = new Paragraph("Gabarito", fonte);
            gabarito.Alignment = Element.ALIGN_CENTER;
            document.Add(gabarito);

            for (int i = 0; i < Teste.ListaQuestoesDoTeste.Count; i++)
            {
                Paragraph questao = new Paragraph($"Questão {i + 1}: {Teste.ListaQuestoesDoTeste[i].Enunciado}", fonte);
                document.Add(questao);

                string auxRespostaCorreta= Teste.QuestoesDoTeste[i].RespostaCorreta;                

                Paragraph alternativaQuestao = new Paragraph($"R: {auxRespostaCorreta}", fonte);
                document.Add(alternativaQuestao);
            }

            document.Close();
        }
    }
}
