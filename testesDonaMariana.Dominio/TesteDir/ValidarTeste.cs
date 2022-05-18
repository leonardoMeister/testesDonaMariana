using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Domain.TesteDir
{
    public class ValidarTeste: AbstractValidator<Teste>
    {
        public ValidarTeste(Teste teste, List<Teste> lista)
        {
            RuleFor(x => x.ListaQuestoesDisponiveisParaProva)
                .NotEmpty().NotNull();
            RuleFor(x => x.ListaMaterias)
                .NotEmpty().NotNull();
            RuleFor(x => x.Disciplina)
                .NotEmpty().NotNull();
            RuleFor(x => x.AnoLetivo)
                .NotEmpty().NotNull();
            RuleFor(x => x.NomeProva)
                .NotEmpty().NotNull();
            RuleFor(x => x.NumeroQuestoes)
                .NotEmpty().NotNull();

            foreach (Teste item in lista)
            {
                if ((teste.NomeProva == item.NomeProva) && (teste._id != item._id))
                {
                    RuleFor(x => x.NomeProva).NotEqual(teste.NomeProva).WithMessage("Nao pode haver nomes repetidos nos Testes.");
                }
            }

        }
    }
}
