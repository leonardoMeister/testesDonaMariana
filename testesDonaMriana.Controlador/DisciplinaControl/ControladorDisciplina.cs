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

        public override List<Disciplina> ObterRegistros()
        {
            return disciplinas;
        }

        public override AbstractValidator<Disciplina> ObterValidador()
        {
            return new ValidadorDisciplina();
        }

        public List<Disciplina> SelecionarDisciplinasPorAno(AnoLetivoEnum ano)
        {
            return SelecionarTodos().Where(x => x.AnoLetivo == ano).Cast<Disciplina>().ToList();
        }
    }
}
