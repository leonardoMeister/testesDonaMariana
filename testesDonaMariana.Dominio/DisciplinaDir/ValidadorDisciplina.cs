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
        public ValidadorDisciplina(Disciplina disc, List<Disciplina> lista)
        {
            RuleFor(x => x.Nome)
               .NotEmpty().NotNull();

            RuleFor(x => x.ListaMaterias)
                .NotEmpty().NotNull();

            RuleFor(x => x.AnoLetivo)
                .NotNull().NotEmpty();


            foreach (Disciplina  item in lista)
            {
                if ((disc.Nome == item.Nome) && (disc._id != item._id))
                {
                    RuleFor(x => x.Nome).NotEqual(disc.Nome).WithMessage("Nao pode haver nomes repetidos nas Disciplinas.");
                }
            }
        }
    }
}
