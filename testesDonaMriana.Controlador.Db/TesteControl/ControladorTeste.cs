using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.TesteDir;

namespace testesDonaMriana.Controlador.TesteControl
{
    public class ControladorTeste : Controlador<Teste>
    {
        List<Teste> testes;

        public ControladorTeste()
        {
            this.testes = new List<Teste>();
        }

        public ControladorTeste(List<Teste> testes)
        {
            this.testes = testes;
        }

        public override string SqlUpdate => throw new NotImplementedException();

        public override string SqlDelete => throw new NotImplementedException();

        public override string SqlInsert => throw new NotImplementedException();

        public override string SqlSelectAll => throw new NotImplementedException();

        public override string SqlSelectId => throw new NotImplementedException();

        public override string SqlExiste => throw new NotImplementedException();

        public override Teste ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Teste> ObterValidador(Teste item, List<Teste> lista)
        {
            return new ValidarTeste(item,lista);
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Teste registro)
        {
            throw new NotImplementedException();
        }
    }
}
