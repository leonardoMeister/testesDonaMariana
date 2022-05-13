using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.MateriaControl;
using testesDonaMriana.Controlador.QuestaoControl;

namespace testesDonaMariana.WinApp
{
    public static class PopularAplicativo
    {
        public static void Popularaplicativo(ControladorMateria controlmateria, ControladorDisciplina controldisciplina, ControladorQuestao controlquestao)
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




        }
    }
}
