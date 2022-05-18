using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
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

        public override string SqlUpdate => throw new NotImplementedException();

        public override string SqlDelete => throw new NotImplementedException();

        public override string SqlInsert => throw new NotImplementedException();

        public override string SqlSelectAll => throw new NotImplementedException();

        public override string SqlSelectId => throw new NotImplementedException();

        public override string SqlExiste => throw new NotImplementedException();

        public override Questao ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Questao> ObterValidador(Questao item, List<Questao> lista)
        {
            return new ValidadorQuestao(item,lista);
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Questao registro)
        {
            throw new NotImplementedException();
        }
    }
}
