using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.TesteDir;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;
using testesDonaMriana.Controlador.QuestaoControl;
using testesDonaMriana.Controlador.TesteControl;

namespace testesDonaMariana.WinApp
{
    public static class PopularAplicativo
    {
        public static void Popularaplicativo(ControladorMateria controlmateria, ControladorDisciplina controldisciplina, ControladorQuestao controlquestao, ControladorTeste controlTeste)
        {
            List<BimestreEnum> enums = new List<BimestreEnum>();
            enums.Add(BimestreEnum.PrimeiroBimestre);
            enums.Add(BimestreEnum.SegundoBimestre);

            Materia mat1 = new Materia( enums, "Soma");
            Materia mat2 = new Materia(enums, "Subtracao");

            List<Materia> listMat = new List<Materia> { mat1, mat2 };

            Disciplina disc1 = new Disciplina(listMat, AnoLetivoEnum.PrimeiroAno, "Matematica");

            controlmateria.InserirNovo(mat1);
            controlmateria.InserirNovo(mat2);

            controldisciplina.InserirNovo(disc1);

            List<string> listaAlternativas = new List<string> { "Alternativa 1","Alternativa 2","Alternativa 3"};

            Questao quest = new Questao("Nome de questao","Enunciadode Questao",listaAlternativas,"Alternativa 2",disc1, mat1);
            Questao quest2 = new Questao("Nome de questao2", "Enunciadode Questao2", listaAlternativas, "Alternativa 3", disc1, mat1);
            Questao quest3 = new Questao("Nome de questao3", "Enunciadode Questao3", listaAlternativas, "Alternativa 1", disc1, mat1);
            Questao quest4 = new Questao("Nome de questao4", "Enunciadode Questao4", listaAlternativas, "Alternativa 2", disc1, mat1);
            Questao quest5 = new Questao("Nome de questao5", "Enunciadode Questao5", listaAlternativas, "Alternativa 3", disc1, mat1);
            Questao quest6 = new Questao("Nome de questao6", "Enunciadode Questao6", listaAlternativas, "Alternativa 2", disc1, mat1);
            Questao quest7 = new Questao("Nome de questao7", "Enunciadode Questao7", listaAlternativas, "Alternativa 1", disc1, mat1);

            controlquestao.InserirNovo(quest);
            controlquestao.InserirNovo(quest2);
            controlquestao.InserirNovo(quest3);
            controlquestao.InserirNovo(quest4);
            controlquestao.InserirNovo(quest5);
            controlquestao.InserirNovo(quest6);
            controlquestao.InserirNovo(quest7);

            mat1.ListaQuestoes.Add(quest);
            mat1.ListaQuestoes.Add(quest2);
            mat1.ListaQuestoes.Add(quest3);
            mat1.ListaQuestoes.Add(quest4);
            mat1.ListaQuestoes.Add(quest5);
            mat1.ListaQuestoes.Add(quest6);
            mat1.ListaQuestoes.Add(quest7);

            List<Materia> listaMateria= new List<Materia> { mat1};
            Teste teste = new Teste(disc1.AnoLetivo, disc1, listaMateria, "Prova Teste 1", mat1.ListaQuestoes, 5);
            teste.GerarProva();
            controlTeste.InserirNovo(teste);

            teste = new Teste(disc1.AnoLetivo, disc1, listaMateria, "Prova Teste 2", mat1.ListaQuestoes, 5);
            teste.GerarProva();
            controlTeste.InserirNovo(teste);

        }
    }
}
