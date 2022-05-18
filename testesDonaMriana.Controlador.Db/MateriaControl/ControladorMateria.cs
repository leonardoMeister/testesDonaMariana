using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
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

        public override string SqlUpdate => throw new NotImplementedException();

        public override string SqlDelete => throw new NotImplementedException();

        public override string SqlInsert => throw new NotImplementedException();

        public override string SqlSelectAll => throw new NotImplementedException();

        public override string SqlSelectId => throw new NotImplementedException();

        public override string SqlExiste => throw new NotImplementedException();

        public override Materia ConverterEmRegistro(IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Materia> ObterValidador(Materia item, List<Materia> lista)
        {
            return new ValidadorMateria(item,lista);
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Materia registro)
        {
            throw new NotImplementedException();
        }
    }
}
