using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;

namespace TestesDonaMariana.Domain.DisciplinaDir
{
    public class Disciplina : EntidadeBase
    {

        List<Materia> _listaMaterias;
        AnoLetivoEnum _anoLetivo;
        string _nome;
        public Disciplina()
        {
            _listaMaterias = new List<Materia>();
        }
        public Disciplina(List<Materia> listaMaterias, AnoLetivoEnum ano, string nome)
        {
            this.ListaMaterias = listaMaterias;
            this._anoLetivo = ano;
            this._nome = nome;
        }

        public void AdicionarMateria(Materia mat)
        {
            ListaMaterias.Add(mat);
        }
        public void RemoverMateria(Materia mat)
        {
            ListaMaterias.Remove(mat);
        }

        public List<Materia> ListaMaterias { get => _listaMaterias; set => _listaMaterias = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public AnoLetivoEnum AnoLetivo { get => _anoLetivo; set => _anoLetivo = value; }

        public override string ToString()
        {
            return $"Id: {_id}, Nome: {Nome}, Ano Letivo: {_anoLetivo}";
        }

        public override string Validar()
        {
            throw new NotImplementedException();
        }
    }
}
