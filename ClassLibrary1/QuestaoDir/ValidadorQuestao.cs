using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Domain.QuestaoDir
{
    public class ValidadorQuestao : AbstractValidator<Questao>
    {
        public ValidadorQuestao()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().NotNull();
            RuleFor(x => x.Enunciado)
                .NotEmpty().NotNull();
            RuleFor(x => x.ListaAlternativas)
                .NotEmpty().NotNull();
            RuleFor(x => x.RespostaCorreta)
                .NotEmpty().NotNull();
        }
    }
}
