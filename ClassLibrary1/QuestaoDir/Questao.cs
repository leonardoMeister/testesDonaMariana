using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.QuestaoDir
{
    public class Questao : EntidadeBase
    {

        string _titulo;
        string _enunciado;
        List<string> _listaAlternativas;
        string _respostaCorreta;

        public Questao()
        {

        }

        public Questao(string titulo, string enunciado, List<string> listaAlternativas, string respostaCorreta)
        {
            _titulo = titulo;
            _enunciado = enunciado;
            _listaAlternativas = listaAlternativas;
            _respostaCorreta = respostaCorreta;
        }

        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Enunciado { get => _enunciado; set => _enunciado = value; }
        public List<string> ListaAlternativas { get => _listaAlternativas; set => _listaAlternativas = value; }
        public string RespostaCorreta { get => _respostaCorreta; set => _respostaCorreta = value; }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
