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
using TestesDonaMariana.Domain.TesteDir;
using testesDonaMriana.Controlador.DisciplinaControl;
using testesDonaMriana.Controlador.QuestaoControl;

namespace testesDonaMriana.Controlador.TesteControl
{
    public class ControladorTeste : Controlador<Teste>
    {
        List<Teste> testes;

        public ControladorTeste()
        {
            this.testes = new List<Teste>();
        }

        public ControladorTeste(List<Teste> testes)
        {
            this.testes = testes;
        }

        protected override string SqlUpdate => throw new NotImplementedException();
        protected override string SqlExiste => throw new NotImplementedException();

        protected override string SqlDelete =>
                    @"DELETE FROM TB_TESTE
                      WHERE Id_teste = @ID";
        string SqlDeletarListaQuestoesTestePorFkTeste =
                    @"DELETE FROM TB_LISTA_TESTE_QUESTOES
                    WHERE fk_teste_id_lista = @ID";
        string SqlInsertListaQuestoesTeste =
                    @"INSERT INTO TB_LISTA_TESTE_QUESTOES
                        (fk_teste_id_lista
                        ,fk_questao_id_lista)
                      VALUES
                        (@FKTESTE, @FKQUESTAO)";
        string SqlSelectListaQuestoesTestePorTeste =
                    @"select fk_questao_id_lista,fk_teste_id_lista
                    from TB_LISTA_TESTE_QUESTOES
                    where fk_teste_id_lista = @ID";
        protected override string SqlInsert =>
                    @"INSERT INTO TB_TESTE
                           (nome_teste,fk_disciplina_id)
                     VALUES
                           (@NOMETESTE , @DISCIPLINAID)";
        protected override string SqlSelectAll =>
                    @"SELECT Id_teste
                          ,nome_teste
                          ,fk_disciplina_id
                      FROM TB_TESTE";
        protected override string SqlSelectId =>
                    @"SELECT Id_teste
                          ,nome_teste
                          ,fk_disciplina_id
                      FROM TB_TESTE
                      where Id_teste = @ID";
        string SqlSelectTestePorIdDisciplina =>
                    @"SELECT Id_teste
                          ,nome_teste
                          ,fk_disciplina_id
                      FROM TB_TESTE
                      where fk_disciplina_id = @ID";

        string SqlDeletarTestesPorDisciplina =
                    @"DELETE FROM TB_TESTE
                      WHERE fk_disciplina_id =  @ID";
        string SqlDeleteListaTesteQuestaoPorDisciplinaId =
                    @"delete from TB_LISTA_TESTE_QUESTOES
                    where @ID in (select fk_disciplina_id from TB_TESTE inner join TB_LISTA_TESTE_QUESTOES on Id_teste = fk_teste_id_lista)  ";
        public override Teste ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader[0]);
            string nome = Convert.ToString(reader[1]);
            int idDisciplina = Convert.ToInt32(reader[2]);

            Disciplina disciplina = new Disciplina();
            disciplina._id = idDisciplina;
            Teste teste = new Teste(AnoLetivoEnum.PrimeiroAno, disciplina, null, nome, null, 0);
            teste._id = id;
            return teste;
        }
        public override AbstractValidator<Teste> ObterValidador(Teste item, List<Teste> lista)
        {
            return new ValidarTeste(item, lista);
        }

        public void InserirNovoTeste(Teste teste)
        {
            int id = DataBase.Insert(SqlInsert, ObtemParametrosRegistro(teste));
            teste._id = id;

            foreach(Questao quest in teste.ListaQuestoesDoTeste)
            {
                DataBase.InsertNoReturn(SqlInsertListaQuestoesTeste, ObtemParametrosTesteQuestao(teste, quest));
            }
        }

        private Dictionary<string, object> ObtemParametrosTesteQuestao(Teste teste,Questao quest)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("FKTESTE", teste._id);
            parametros.Add("FKQUESTAO", quest._id);
            

            return parametros;
        }

        protected override Dictionary<string, object> ObtemParametrosRegistro(Teste registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOMETESTE", registro.NomeProva);
            parametros.Add("DISCIPLINAID", registro.Disciplina._id);

            return parametros;
        }
        public void ExcluirTodosTestesDeDisciplina(int idDisciplina)
        {         
            DataBase.Delete(SqlDeleteListaTesteQuestaoPorDisciplinaId, AdicionarParametro("ID", idDisciplina));
            DataBase.Delete(SqlDeletarTestesPorDisciplina, AdicionarParametro("ID", idDisciplina));
        }
        public void ExcluirTestePorTesteID(int idTeste)
        {
            DataBase.Delete(SqlDeletarListaQuestoesTestePorFkTeste, AdicionarParametro("ID", idTeste));
            DataBase.Delete(SqlDelete, AdicionarParametro("ID", idTeste));
        }
        public List<Teste> SelecionarTodosComReferencia()
        {
            List<Teste> lista = DataBase.GetAll(SqlSelectAll, ConverterEmRegistro);

            foreach (Teste teste in lista)
            {
                CarregarRefTeste(teste); 
            }
            return lista;
        }
        public Teste SelecionarTesteComReferenciaPorID(int idTeste) 
        {
            Teste teste = DataBase.Get(SqlSelectId, ConverterEmRegistro, AdicionarParametro("ID", idTeste));
            
            CarregarRefTeste(teste);

            return teste;
        }
        private void CarregarRefTeste(Teste teste)
        {
            teste.Disciplina = new ControladorDisciplina().SelecionarDisciplinaComReferenciaPorId(teste.Disciplina._id);
            teste.AnoLetivo = teste.Disciplina.AnoLetivo;
            teste.ListaMaterias = teste.Disciplina.ListaMaterias;
            teste.ListaQuestoesDisponiveisParaProva = PegarListaQuestoesDisponiveisParaProva(teste.ListaMaterias);
            teste.ListaQuestoesDoTeste = new ControladorQuestao().SelecionarQuestoesPorTesteEDisciplina(teste._id);
            teste.NumeroQuestoes = teste.ListaQuestoesDoTeste.Count;
        }

        private List<Questao> PegarListaQuestoesDisponiveisParaProva(List<Materia> listaMaterias)
        {
            List<Questao> lista = new List<Questao>();

            foreach (Materia materia in listaMaterias)
            {
                foreach(Questao quest in materia.ListaQuestoes)
                {
                    lista.Add(quest);
                }
            }
            return lista;
        }
    }
}
