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
        public ValidadorQuestao(Questao quest, List<Questao> listaQuest)
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().NotNull();
            RuleFor(x => x.Enunciado)
                .NotEmpty().NotNull();
            RuleFor(x => x.ListaAlternativas)
                .NotEmpty().NotNull();
            RuleFor(x => x.RespostaCorreta)
                .NotEmpty().NotNull();

            foreach (Questao item in listaQuest)
            {
                if ((quest.Titulo == item.Titulo ) && (quest._id != item._id) ) 
                {
                    RuleFor(x => x.Titulo).NotEqual(quest.Titulo).WithMessage("Nao pode haver nomes repetidos nas Questoes.");
                }
            }

        }
    }
}
