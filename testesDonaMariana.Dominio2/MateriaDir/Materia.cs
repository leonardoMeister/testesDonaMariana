using eAgenda.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesDonaMariana.Dominio.QuestaoDir;

namespace testesDonaMariana.Dominio.MateriaDir
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
