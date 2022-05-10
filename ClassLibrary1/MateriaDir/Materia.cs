using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.MateriaDir
{
    public class Materia : EntidadeBase
    {

        List<Questao> listaQuestoes;

        public Materia()
        {
            listaQuestoes = new List<Questao>();
        }

        public Materia(List<Questao> listaQuestoes)
        {
            this.listaQuestoes = listaQuestoes;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
