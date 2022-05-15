using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
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

        public override List<Teste> ObterRegistros()
        {
            return this.testes;
        }

        public override AbstractValidator<Teste> ObterValidador()
        {
            return new ValidarTeste();
        }
    }
}
