using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesDonaMariana.DataBase.Shared;
using TestesDonaMariana.Domain.QuestaoDir;

namespace testesDonaMriana.Controlador.Db.QuestaoControl
{
    public class ControladorAlternativa : Controlador<Alternativa>
    {
        public override string SqlUpdate => "";

        public override string SqlDelete =>
                    @"DELETE FROM TB_ALTERNATIVA
	                  WHERE FK_Questao_id = @ID";

        public override string SqlInsert =>
                        @"insert into TB_ALTERNATIVA
			                (Alternativa,FK_Questao_id)
		                VALUES
			                (@ALTERNATIVA, @QUESTAOID)";
        protected override Dictionary<string, object> ObtemParametrosRegistro(Alternativa registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("ALTERNATIVA", registro.AlternativaStr);
            parametros.Add("QUESTAOID", registro.Quest._id);

            return parametros;
        }
        public override string SqlSelectAll =>
                    @"SELECT 
                        Id,Alternativa,FK_Questao_id
                    FROM TB_ALTERNATIVA";

        public override string SqlSelectId => "";

        public override string SqlExiste => "";

        public string SqlSelecionarTodosPorQuestao =
                @"SELECT 
                	id as 'Id Alternativa',
	                Alternativa as 'Alternativa',
	                FK_Questao_id as 'Questao Id'
                FROM TB_ALTERNATIVA
                    where FK_Questao_id  = @ID";

        public override Alternativa ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader[0]);
            string alternativaStr = Convert.ToString(reader[1]);

            Alternativa alternativa = new Alternativa(alternativaStr,null);
            alternativa._id = id;

            return alternativa;
        }

        public override AbstractValidator<Alternativa> ObterValidador(Alternativa item, List<Alternativa> lista)
        {
            return new ValidadorAlternativa(item,lista);
        }

 
     

        internal List<Alternativa> SelecionarTodosPorQuestao(Questao questao)
        {
            List<Alternativa> listaAlternativa =  DataBase.GetAll(SqlSelecionarTodosPorQuestao, ConverterEmRegistro, AdicionarParametro("ID", questao._id));
            foreach(Alternativa alternativa in listaAlternativa)
            {
                alternativa.Quest = questao;
            }
            return listaAlternativa;
        }
    }
}
