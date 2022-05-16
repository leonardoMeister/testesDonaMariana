using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Domain.MateriaDir
{
    public class ValidadorMateria: AbstractValidator<Materia>
    {
        public ValidadorMateria(Materia materia, List<Materia> lista)
        {
            
            RuleFor(x => x.ListaBimestres)
                .NotNull().NotEmpty();
            
             RuleFor(x => x.Nome)
                .NotNull().NotEmpty();

        }
    }
}
