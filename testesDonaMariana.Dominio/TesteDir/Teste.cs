using System;
using System.Collections.Generic;
using System.Linq;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.TesteDir
{
    public class Teste : EntidadeBase
    {
        
        Disciplina _disciplina;   List<Materia> _listaMaterias;
        string _nomeProva;
        List<Questao> _listaQuestoesDoTeste;

        List<Questao> _listaQuestoesDisponiveisParaGerarProva;        
        AnoLetivoEnum _anoLetivo;
        int _numeroQuestoes;

        public AnoLetivoEnum AnoLetivo { get => _anoLetivo; set => _anoLetivo = value; }
        public List<Materia> ListaMaterias { get => _listaMaterias; set => _listaMaterias = value; }
        public string NomeProva { get => _nomeProva; set => _nomeProva = value; }
        public List<Questao> ListaQuestoesDisponiveisParaProva { get => _listaQuestoesDisponiveisParaGerarProva; set => _listaQuestoesDisponiveisParaGerarProva = value; }
        public int NumeroQuestoes { get => _numeroQuestoes; set => _numeroQuestoes = value; }
        public Disciplina Disciplina { get => _disciplina; set => _disciplina = value; }
        public List<Questao> QuestoesDoTeste { get => ListaQuestoesDoTeste; set => ListaQuestoesDoTeste = value; }
        public List<Questao> ListaQuestoesDoTeste { get => _listaQuestoesDoTeste; set => _listaQuestoesDoTeste = value; }

        public Teste(AnoLetivoEnum anoLetivo, Disciplina disciplina, List<Materia> listaMaterias, string nomeProva, List<Questao> listaQuestoes, int numeroQuetoes)
        {
            _anoLetivo = anoLetivo;
            _listaMaterias = listaMaterias;
            _nomeProva = nomeProva;
            _listaQuestoesDisponiveisParaGerarProva = listaQuestoes;
            _numeroQuestoes = numeroQuetoes;
            _disciplina = disciplina;
        }


        public void GerarProva()
        {
            ListaQuestoesDoTeste = new List<Questao>();
            int numeroQuestoesNaLista = ListaQuestoesDisponiveisParaProva.Count;

            if (numeroQuestoesNaLista == _numeroQuestoes) ListaQuestoesDoTeste = _listaQuestoesDisponiveisParaGerarProva;
            else
            {
                Random rd = new Random();
                List<int> numerosAleatoriosQuestoesDevemIrParaProva = new List<int>();

                int number = 0;
                for (int i = 0; i < _numeroQuestoes; i++)
                {
                    number = rd.Next(0, numeroQuestoesNaLista - 1);
                    while (numerosAleatoriosQuestoesDevemIrParaProva.Contains(number))
                    {
                        if (numerosAleatoriosQuestoesDevemIrParaProva.Count >= _numeroQuestoes)
                            break;
                        else
                            number = rd.Next(0, numeroQuestoesNaLista - 1);
                    }
                    numerosAleatoriosQuestoesDevemIrParaProva.Add(number);
                    Console.WriteLine(number.ToString());
                }

                numerosAleatoriosQuestoesDevemIrParaProva = numerosAleatoriosQuestoesDevemIrParaProva.OrderBy(x => x).ToList();

                for (int i = 0; i < numerosAleatoriosQuestoesDevemIrParaProva.Count; i++)
                {
                    ListaQuestoesDoTeste.Add(_listaQuestoesDisponiveisParaGerarProva[numerosAleatoriosQuestoesDevemIrParaProva[i]]);
                }
            }
        }
        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
