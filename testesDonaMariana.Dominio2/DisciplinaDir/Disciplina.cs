using eAgenda.Dominio.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testesDonaMariana.Dominio.MateriaDir;

namespace testesDonaMariana.Dominio.DisciplinaDir
{
    public class Disciplina : EntidadeBase
    {

        List<Materia> listaMaterias;
        string anoLetivo;


        public Disciplina()
        {
            listaMaterias = new List<Materia>();    
        }

        public Disciplina(List<Materia> listaMaterias)
        {
            this.listaMaterias = listaMaterias;
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
