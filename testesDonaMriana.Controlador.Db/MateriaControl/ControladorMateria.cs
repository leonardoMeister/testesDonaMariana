using eAgenda.Controladores.Shared;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestesDonaMariana.DataBase.Shared;
using TestesDonaMariana.Domain.DisciplinaDir;
using TestesDonaMariana.Domain.MateriaDir;
using testesDonaMriana.Controlador.QuestaoControl;

namespace testesDonaMriana.Controlador.MateriaControl
{
    public class ControladorMateria : Controlador<Materia>
    {
        List<Materia> listaMaterias;

        public ControladorMateria()
        {
            this.listaMaterias = new List<Materia>();
        }

        public ControladorMateria(List<Materia> listaMaterias)
        {
            this.listaMaterias = listaMaterias;
        }

        public override string SqlUpdate =>
                @"UPDATE TB_MATERIA
                SET nome_materia = @NOME
                    WHERE Id_materia = @ID";
        protected override Dictionary<string, object> ObtemParametrosRegistro(Materia registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro._id);
            parametros.Add("NOME", registro.Nome);
            parametros.Add("DISCIPLINAID", registro.Disciplina._id);

            return parametros;
        }
        public override string SqlDelete =>
                    @"DELETE FROM TB_MATERIA
                      WHERE Id_materia = @ID";

        public override string SqlInsert =>
                    @"INSERT INTO TB_MATERIA
                        (disciplina_Id, nome_materia)
                    VALUES
                        (@DISCIPLINAID, @NOME)";

        public override string SqlSelectAll =>
                @"SELECT 
	                Id_materia as 'Id Materia',
	                nome_materia as 'Nome Materia',
	                disciplina_Id as 'Disciplina Id'
                FROM TB_MATERIA";
        public string SqlDeleteMateriaPorDisciplina =
                @"DELETE FROM TB_MATERIA
                  WHERE disciplina_Id = @ID";
        public override string SqlSelectId => throw new NotImplementedException();

        public override string SqlExiste =>
                    @"SELECT
                        COUNT(*)
                    FROM 
                        TB_MATERIA
                    WHERE Id_materia = @ID";

        public string SqlDeleteBimestres =
                    @"DELETE FROM TB_LISTA_BIMESTRES_MATERIA
                    WHERE TB_LISTA_BIMESTRES_MATERIA.FK_tb_materia_id = @ID";

        public string SqlBimestresMateria =
                    @"SELECT 	
	                    Bime.nome_bimestre as 'Nome Bimestre'
                    FROM TB_MATERIA
                        inner join TB_LISTA_BIMESTRES_MATERIA as bimestres
                        on bimestres.FK_tb_materia_id = Id_materia
                        inner join TB_BIMESTRE Bime
                        on Bime.Id_Bimeste = bimestres.Fk_tb_bimestre_id
                    where Id_materia = @ID";

        public string SqlMateriasPorUmaDisciplina =
                    @"SELECT 
	                    Id_materia as 'Id Materia',
	                    nome_materia as 'Nome Materia',
	                    disciplina_Id as 'Disciplina Id'
                    FROM TB_MATERIA
                        where disciplina_Id = @ID";
        private string SqlInsertBimestres =
                    @"INSERT INTO TB_LISTA_BIMESTRES_MATERIA
                        (Fk_tb_bimestre_id, FK_tb_materia_id)
                    VALUES
                        (@FkBIMESTRE  ,@FkMATERIA)";

        public void RemoverReferenciaBimestresMateria(int id)
        {
            DataBase.Delete(SqlDeleteBimestres, AdicionarParametro("ID", id));
        }

        public override Materia ConverterEmRegistro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader[0]);
            string nome = Convert.ToString(reader[1]);
            int disciplinaID = Convert.ToInt32(reader[2]);

            Materia mate = new Materia(null, nome, null);
            mate._id = id;

            return mate;
        }

        public void AtualizarMateria(Materia mate)
        {
            bool jaExiste = DataBase.Exists(SqlExiste, AdicionarParametro("ID", mate._id));

            if (jaExiste)
            {
                DataBase.Update(SqlUpdate, ObtemParametrosRegistro(mate));

                DataBase.Delete(SqlDeleteBimestres, AdicionarParametro("ID", mate._id));
                foreach (BimestreEnum bime in mate.ListaBimestres)
                {
                    DataBase.InsertNoReturn(SqlInsertBimestres, ObtemParametrosParaBimestre(mate, bime));
                }
            }
            else
            {
                int id = DataBase.Insert(SqlInsert, ObtemParametrosRegistro(mate));
                mate._id = id;

                foreach (BimestreEnum bime in mate.ListaBimestres)
                {
                    DataBase.InsertNoReturn(SqlInsertBimestres, ObtemParametrosParaBimestre(mate, bime));
                }
            }


        }

        public void ExcluirMateriasPorDisciplina(int id)
        {
            
            DataBase.Delete(SqlDeleteMateriaPorDisciplina, AdicionarParametro("ID", id));
        }

        protected Dictionary<string, object> ObtemParametrosParaBimestre(Materia registro, BimestreEnum bime)
        {

            var parametros = new Dictionary<string, object>();
            int bimestre = 0;

            if (bime.ToString() == BimestreEnum.PrimeiroBimestre.ToString()) bimestre = 1;
            if (bime.ToString() == BimestreEnum.SegundoBimestre.ToString()) bimestre = 2;
            if (bime.ToString() == BimestreEnum.TerceiroBimestre.ToString()) bimestre = 3;
            if (bime.ToString() == BimestreEnum.QuartoBimestre.ToString()) bimestre = 4;

            parametros.Add("FkBIMESTRE", bimestre);
            parametros.Add("FkMATERIA", registro._id);


            return parametros;
        }

        public void InserirNovaMateriaComBimestre(Materia mate)
        {
            int id = DataBase.Insert(SqlInsert, ObtemParametrosRegistro(mate));
            mate._id = id;

            foreach (BimestreEnum bime in mate.ListaBimestres)
            {
                DataBase.InsertNoReturn(SqlInsertBimestres, ObtemParametrosParaBimestre(mate, bime));
            }
        }

        public Materia ConverterDadosMateria(IDataReader reader)
        {
            string bimestre = Convert.ToString(reader[0]);
            List<BimestreEnum> enums = new List<BimestreEnum>();

            if (bimestre == BimestreEnum.PrimeiroBimestre.ToString()) enums.Add(BimestreEnum.PrimeiroBimestre);
            if (bimestre == BimestreEnum.SegundoBimestre.ToString()) enums.Add(BimestreEnum.SegundoBimestre);
            if (bimestre == BimestreEnum.TerceiroBimestre.ToString()) enums.Add(BimestreEnum.TerceiroBimestre);
            if (bimestre == BimestreEnum.QuartoBimestre.ToString()) enums.Add(BimestreEnum.QuartoBimestre);

            return new Materia(enums, "", null);
        }

        public override AbstractValidator<Materia> ObterValidador(Materia item, List<Materia> lista)
        {
            return new ValidadorMateria(item, lista);
        }

        public List<Materia> SelecionarTodasMateriasPorDisciplina(Disciplina disc)
        {
            return DataBase.GetAll(SqlMateriasPorUmaDisciplina, ConverterEmRegistro, AdicionarParametro("ID", disc._id));
        }

        internal void CarregarBimestresMateria(Materia mate)
        {
            List<Materia> lista = DataBase.GetAll(SqlBimestresMateria, ConverterDadosMateria, AdicionarParametro("ID", mate._id));
            mate.ListaBimestres = new List<BimestreEnum>();

            foreach (Materia item in lista)
            {
                mate.ListaBimestres.Add(item.ListaBimestres[0]);
            }
        }
    }
}
