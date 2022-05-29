using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.QuestaoDir
{
    public class Alternativa : EntidadeBase
    {
        string alternativaStr;
        Questao quest;
        public Alternativa(string alternativa, Questao quest)
        {
            this.alternativaStr  = alternativa;
            this.quest = quest;
        }
        public string AlternativaStr { get => alternativaStr; set => alternativaStr = value; }
        public Questao Quest { get => quest; set => quest = value; }

        public override string ToString()
        {
            return $"{alternativaStr}";
        }
        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
