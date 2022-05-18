using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using TestesDonaMariana.Domain.DisciplinaDir;

namespace testesDonaMriana.Controlador.DisciplinaControl
{
    public class ControladorDisciplina : Controlador<Disciplina>
    {
        List<Disciplina> disciplinas;

        public ControladorDisciplina()
        {
            disciplinas = new List<Disciplina>();
        }

        public ControladorDisciplina(List<Disciplina> disciplinas)
        {
            this.disciplinas = disciplinas;
        }

        public override string SqlUpdate => throw new NotImplementedException();

        public override string SqlDelete => throw new NotImplementedException();

        public override string SqlInsert => throw new NotImplementedException();

        public override string SqlSelectAll => throw new NotImplementedException();

        public override string SqlSelectId => throw new NotImplementedException();

        public override string SqlExiste => throw new NotImplementedException();

        public override Disciplina ConverterEmRegistro(System.Data.IDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public override AbstractValidator<Disciplina> ObterValidador(Disciplina item, List<Disciplina> lista)
        {
            return new ValidadorDisciplina(item,lista);
        }

        public List<Disciplina> SelecionarDisciplinasPorAno(AnoLetivoEnum ano)
        {
            return SelecionarTodos().Where(x => x.AnoLetivo == ano).Cast<Disciplina>().ToList();
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Disciplina registro)
        {
            throw new NotImplementedException();
        }
    }
}
