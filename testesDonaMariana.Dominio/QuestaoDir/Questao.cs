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
        List<string> _listaAlternativas;
        string _respostaCorreta;
        Disciplina _disciplina;
        Materia materia;

        public Questao(string enunciado, List<string> listaAlternativas, string respostaCorreta, Disciplina dis, Materia mate)
        {
            _enunciado = enunciado;
            _listaAlternativas = listaAlternativas;
            _respostaCorreta = respostaCorreta;
            _disciplina = dis;
            Materia = mate;
        }
        public string Enunciado { get => _enunciado; set => _enunciado = value; }
        public List<string> ListaAlternativas { get => _listaAlternativas; set => _listaAlternativas = value; }
        public string RespostaCorreta { get => _respostaCorreta; set => _respostaCorreta = value; }
        public Disciplina Disciplina { get => _disciplina; set => _disciplina = value; }
        public Materia Materia { get => materia; set => materia = value; }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
