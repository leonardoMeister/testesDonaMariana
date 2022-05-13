using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.QuestaoDir;

namespace testesDonaMriana.Controlador.QuestaoControl
{
    public class ControladorQuestao : Controlador<Questao>
    {
        List<Questao> questoes;

        public ControladorQuestao()
        {
            questoes = new List<Questao>();
        }

        public ControladorQuestao(List<Questao> questoes)
        {
            this.questoes = questoes;
        }

        public override List<Questao> ObterRegistros()
        {
            return questoes;
        }

        public override AbstractValidator<Questao> ObterValidador()
        {
            return new ValidadorQuestao();
        }
    }
}
