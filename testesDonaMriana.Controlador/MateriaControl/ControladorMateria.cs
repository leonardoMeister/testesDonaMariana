using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.MateriaDir;

namespace testesDonaMriana.Controlador.MateriaControl
{
    public class ControladorMateria : Controlador<Materia>
    {
        List<Materia> listaMaterias;

        public ControladorMateria()
        {
            this.listaMaterias = new List<Materia>();
        }

        public ControladorMateria(List<Materia> listaMaterias)
        {
            this.listaMaterias = listaMaterias;
        }

        public override List<Materia> ObterRegistros()
        {
            return listaMaterias;
        }

        public override AbstractValidator<Materia> ObterValidador()
        {
            return new ValidadorMateria();
        }
    }
}
