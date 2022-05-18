using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.MateriaDir
{
    public class Materia : EntidadeBase
    {

        List<Questao> _listaQuestoes;
        List<BimestreEnum> _listaBimestres;
        string _nome;

        public Materia()
        {

        }

        public Materia(List<BimestreEnum> listaBimestre, string nome)
        {
            this.ListaQuestoes = new List<Questao>();
            this._listaBimestres = listaBimestre;
            this._nome = nome;
        }

        public List<Questao> ListaQuestoes { get => _listaQuestoes; set => _listaQuestoes = value; }
        public List<BimestreEnum> ListaBimestres { get => _listaBimestres; set => _listaBimestres = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            string aux = "";
            foreach (BimestreEnum bi in _listaBimestres)
            {
                if (bi == BimestreEnum.PrimeiroBimestre) aux += "1º ";
                if (bi == BimestreEnum.SegundoBimestre) aux += "2º ";
                if (bi == BimestreEnum.TerceiroBimestre) aux += "3º ";
                if (bi == BimestreEnum.QuartoBimestre) aux += "4º ";
            }
            return $"Materia: {Nome}, Bimestre(s): {aux}";
        }

    }
}
