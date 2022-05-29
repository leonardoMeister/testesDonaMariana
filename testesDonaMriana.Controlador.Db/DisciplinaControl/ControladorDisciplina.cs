using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Linq;
using System.Collections.Generic;
using TestesDonaMariana.Domain.DisciplinaDir;
using testesDonaMriana.Controlador.MateriaControl;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.Shared;
using testesDonaMriana.Controlador.QuestaoControl;
using TestesDonaMariana.Domain.QuestaoDir;

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

        protected override string SqlUpdate =>
            @"UPDATE TB_DISCIPLINA
                    SET 
                        nome_disciplina = @NOME,
						ano_letivo_disciplina = @ANOLETIVO
                    WHERE Id_disciplina = @ID";
        protected override string SqlDelete =>
            @"DELETE FROM TB_DISCIPLINA
            WHERE Id_disciplina = @ID";
        protected override string SqlInsert =>
                @"INSERT INTO TB_DISCIPLINA
                    (nome_disciplina,ano_letivo_disciplina)
                VALUES
                    (@NOME, @ANOLETIVO)";
        protected override string SqlSelectAll =>
            @"SELECT
	            Id_disciplina,
                nome_disciplina,
                ano_letivo_disciplina
            FROM TB_DISCIPLINA";

        protected override string SqlSelectId =>
                    @"SELECT
	                    Id_disciplina,
                        nome_disciplina,
                        ano_letivo_disciplina
                    FROM TB_DISCIPLINA 
                    where Id_disciplina = @ID";

        protected override string SqlExiste => "";

        protected override Dictionary<string, object> ObtemParametrosRegistro(Disciplina registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("ANOLETIVO", registro.AnoLetivo.ToString());

            return parametros;
        }
        public override Disciplina ConverterEmRegistro(System.Data.IDataReader reader)
        {

            int id = Convert.ToInt32(reader[0]);
            string nome = Convert.ToString(reader[1]);
            string anoLetivo = Convert.ToString(reader[2]);

            AnoLetivoEnum ano = ConverterstrEmAno(anoLetivo);

            Disciplina disciplina = new Disciplina(null, ano, nome);
            disciplina._id = id;

            return disciplina;
        }

        public Questao SelecionarQuestaoComReferenciaPorId(int id)
        {
            List<Disciplina> lista = SelecionarTodasDisciplinasComMateriaEQuestao();

            foreach (Disciplina disciplina in lista)
            {
                foreach (Materia mate in disciplina.ListaMaterias)
                {
                    foreach (Questao quest in mate.ListaQuestoes)
                    {
                        if (quest._id == id) return quest;
                    }
                }
            }
            return null;
        }

        public Disciplina SelecionarDisciplinaComReferenciaPorId(int id)
        {
            return SelecionarDisciplinaComMateriaEQuestaoPorId(id );
        }

  

        private AnoLetivoEnum ConverterstrEmAno(string ano)
        {
            if (ano == AnoLetivoEnum.PrimeiroAno.ToString()) return AnoLetivoEnum.PrimeiroAno;
            if (ano == AnoLetivoEnum.SegundoAno.ToString()) return AnoLetivoEnum.SegundoAno;
            return AnoLetivoEnum.PrimeiroAno;
        }

        public override AbstractValidator<Disciplina> ObterValidador(Disciplina item, List<Disciplina> lista)
        {
            return new ValidadorDisciplina(item, lista);
        }

        public List<Disciplina> SelecionarDisciplinasPorAno(AnoLetivoEnum ano)
        {
            return SelecionarTodasDisciplinasComMateriaEQuestao().Where(x => x.AnoLetivo == ano).Cast<Disciplina>().ToList();
        }
        private Disciplina SelecionarDisciplinaComMateriaEQuestaoPorId(int id)
        {
            Disciplina disciplina = SelecionarPorId(id);
            CarregarreferenciasDisciplina(disciplina);
            return disciplina;

        } 

        private static void CarregarreferenciasDisciplina(Disciplina disciplina)
        {
            disciplina.ListaMaterias = new ControladorMateria().SelecionarTodasMateriasPorDisciplina(disciplina);
            foreach (Materia mate in disciplina.ListaMaterias)
            {
                mate.Disciplina = disciplina;
                new ControladorMateria().CarregarBimestresMateria(mate);
                new ControladorQuestao().CarregarQuestoesDeUmaMateria(mate);
            }
        }

        public List<Disciplina> SelecionarTodasDisciplinasComMateriaEQuestao()
        {
            List<Disciplina> disciplinas = SelecionarTodos().Cast<Disciplina>().ToList();
            foreach (Disciplina item in disciplinas)
            {
                CarregarreferenciasDisciplina(item);                
            }
            return disciplinas;
        }
    }
}
