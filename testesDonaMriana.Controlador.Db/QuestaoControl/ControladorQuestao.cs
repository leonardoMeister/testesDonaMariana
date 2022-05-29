using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.DataBase.Shared;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using TestesDonaMariana.Domain.QuestaoDir;
using TestesDonaMariana.Domain.Shared;
using testesDonaMriana.Controlador.Db.QuestaoControl;
using testesDonaMriana.Controlador.DisciplinaControl;

namespace testesDonaMriana.Controlador.QuestaoControl
{
    public class ControladorQuestao : Controlador<Questao>
    {
        List<Questao> questoes;

        public ControladorQuestao()
        {
            questoes = new List<Questao>();
        }

        public ControladorQuestao(List<Questao> questoes)
        {
            this.questoes = questoes;
        }

        public override string SqlUpdate =>
                    @"UPDATE TB_QUESTAO
                    SET 
                        enunciado_quest = @ENUNCIADO
                        ,alternativa_correta = @ALTERNATIVACORRETA
                        ,Fk_materia_id = @IDMATERIA
                    WHERE Id_Questao = @ID";
        protected override Dictionary<string, object> ObtemParametrosRegistro(Questao registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("ENUNCIADO", registro.Enunciado);
            parametros.Add("ALTERNATIVACORRETA", Convert.ToInt32(registro.RespostaCorreta));
            parametros.Add("IDMATERIA", registro.Materia._id);

            return parametros;
        }
        public override string SqlDelete =>
                    @"DELETE FROM TB_QUESTAO
                      WHERE Id_Questao = @ID";

        public override string SqlInsert =>
                    @"INSERT INTO TB_QUESTAO
                        (enunciado_quest, alternativa_correta, Fk_materia_id)
                    VALUES
                    (@ENUNCIADO, @ALTERNATIVACORRETA, @IDMATERIA)";

        public override string SqlSelectAll =>
                    @"SELECT 
	                    Id_Questao as 'Id Questao',
	                    enunciado_quest as 'Enunciado questao',
	                    alternativa_correta as 'Alternativa correta',
	                    Fk_materia_id as 'Materia Id'
                    FROM TB_QUESTAO";

        public string SqlSelecionarQuestoesPorMateria =
                    @"SELECT 
	                    Id_Questao as 'Id Questao',
	                    enunciado_quest as 'Enunciado questao',
	                    alternativa_correta as 'Alternativa correta',
	                    Fk_materia_id as 'Materia Id'
                    FROM TB_QUESTAO
                        where Fk_materia_id = @ID";
        public override string SqlSelectId =>
                    @"SELECT 
            	        Id_Questao as 'Id Questao',
	                    enunciado_quest as 'Enunciado questao',
	                    alternativa_correta as 'Alternativa correta',
	                    Fk_materia_id as 'Materia Id'
                    FROM TB_QUESTAO
                        where Id_Questao = @ID";
        private string SqlDeletarQuestoesPorMateriaId =
                    @"delete from TB_QUESTAO
                      where Fk_materia_id = @ID";
        public override string SqlExiste => "";
        public override Questao ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader[0]);
            string enunciado = Convert.ToString(reader[1]);
            string alternativaCorreta = Convert.ToString(reader[2]);

            Questao questao = new Questao(enunciado, null, alternativaCorreta, null);
            questao._id = id;

            return questao;
        }

        public List<Questao> SelecionarTodasQuestoesComReferencia()
        {
            List<Disciplina> listaMaterias = new ControladorDisciplina().SelecionarTodasDisciplinasComMateriaEQuestao();
            List<Questao> listaQuestoes = new List<Questao>();
            foreach (Disciplina disciplina in listaMaterias)
            {
                foreach (Materia materia in disciplina.ListaMaterias)
                {
                    foreach (Questao questao in materia.ListaQuestoes)
                    {
                        listaQuestoes.Add(questao);
                    }
                }
            }
            return listaQuestoes;
        }
        string SqlPegarListaQuestoesTeste =
                    @"select * from TB_QUESTAO
                      inner join TB_LISTA_TESTE_QUESTOES
                      on Id_Questao = fk_questao_id_lista
                      where fk_teste_id_lista = @ID";

        public void ExcluirQuestoesPorMateriaId(int idMateria)
        {
            DataBase.Delete(SqlDeletarQuestoesPorMateriaId, AdicionarParametro("ID", idMateria));
        }

        internal List<Questao> SelecionarQuestoesPorTesteEDisciplina(int idTeste)
        {
            List<Questao> lista = DataBase.GetAll(SqlPegarListaQuestoesTeste, ConverterEmQuestaoApenasComID, AdicionarParametro("ID", idTeste));
            List<Questao> listaTodasQuestoes = SelecionarTodasQuestoesComReferencia();
            List<Questao> novaLista = new List<Questao>();
            foreach(Questao  questao in lista)
            {
                Questao quest = listaTodasQuestoes.Find(x => x._id == questao._id);
                novaLista.Add(quest);
            }
            return novaLista;
        }
        public Questao ConverterEmQuestaoApenasComID(IDataReader reader)
        {
            int id = Convert.ToInt32(reader[0]);

            Questao questao = new Questao("", null, "", null);
            questao._id = id;

            return questao;
        }
        public override AbstractValidator<Questao> ObterValidador(Questao item, List<Questao> lista)
        {
            return new ValidadorQuestao(item, lista);
        }
        public override List<Questao> SelecionarTodos()
        {
            return SelecionarTodasQuestoesComReferencia();
        }



        internal void CarregarQuestoesDeUmaMateria(Materia mate)
        {
            List<Questao> listaQuestoes = DataBase.GetAll(SqlSelecionarQuestoesPorMateria, ConverterEmRegistro, AdicionarParametro("ID", mate._id));

            foreach (Questao item in listaQuestoes)
            {
                CarregarAlternativasDaQuestao(item);
                for (int i = 0; i < item.ListaAlternativas.Count; i++)
                {
                    if (Convert.ToInt32(item.RespostaCorreta) == (1 + i)) { item.RespostaCorreta = item.ListaAlternativas[i].AlternativaStr; break; }
                }
                item.Materia = mate;
            }
            mate.ListaQuestoes = listaQuestoes;
        }

        public void CarregarAlternativasDaQuestao(Questao questao)
        {
            questao.ListaAlternativas = new ControladorAlternativa().SelecionarTodosPorQuestao(questao);
        }
    }
}
