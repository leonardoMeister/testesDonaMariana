using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.QuestaoDir
{
    public class Questao : EntidadeBase 
    {

        string _enunciado;
        string _respostaCorreta;

        List<Alternativa> _listaAlternativas;       
        Materia materia;

        public Questao()
        {
        }

        public Questao(string enunciado, List<Alternativa> listaAlternativas, string respostaCorreta, Materia mate)
        {
            _enunciado = enunciado;
            _listaAlternativas = listaAlternativas;
            _respostaCorreta = respostaCorreta;
            Materia = mate;
        }
        public string Enunciado { get => _enunciado; set => _enunciado = value; }
        public List<Alternativa> ListaAlternativas { get => _listaAlternativas; set => _listaAlternativas = value; }
        public string RespostaCorreta { get => _respostaCorreta; set => _respostaCorreta = value; }
        public Materia Materia { get => materia; set => materia = value; }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
