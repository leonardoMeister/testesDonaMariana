using eAgenda.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testesDonaMariana.Dominio.QuestaoDir
{
    public class Questao : EntidadeBase
    {

        BimestreEnum bimestre;
        string titulo;

        public Questao()
        {

        }

        public Questao(BimestreEnum bimestre, string titulo)
        {
            this.bimestre = bimestre;
            this.titulo = titulo;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
