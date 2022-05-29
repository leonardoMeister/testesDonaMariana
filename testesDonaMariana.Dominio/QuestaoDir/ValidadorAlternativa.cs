using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Domain.QuestaoDir
{
    public class ValidadorAlternativa : AbstractValidator<Alternativa>
    {
        public ValidadorAlternativa(Alternativa quest, List<Alternativa> listaQuest)
        {
            RuleFor(x => x.AlternativaStr)
                .NotEmpty().NotNull();

        }
    }
}

