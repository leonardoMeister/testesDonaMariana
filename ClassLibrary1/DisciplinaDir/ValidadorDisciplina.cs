using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Domain.DisciplinaDir
{
    public class ValidadorDisciplina : AbstractValidator<Disciplina>
    {
        public ValidadorDisciplina()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().NotNull();

            RuleFor(x => x.ListaMaterias)
                .NotEmpty().NotNull();

            RuleFor(x => x.AnoLetivo)
                .NotNull().NotEmpty();
        }
    }
}
