﻿using FluentValidation;
using System;
using System.Collections.Generic;
using TestesDonaMariana.Domain.Shared;
using FluentValidation.Results;
using System.Linq;
using TestesDonaMariana.DataBase.Shared;

using System.Data;

namespace eAgenda.Controladores.Shared
{
    public abstract class Controlador<T> where T : EntidadeBase
    {
        protected abstract string SqlUpdate { get; }
        protected abstract string SqlDelete { get; }
        protected abstract string SqlInsert { get; }
        protected abstract string SqlSelectAll { get; }
        protected abstract string SqlSelectId { get; }
        protected abstract string SqlExiste { get; }
        
        public abstract AbstractValidator<T> ObterValidador(T item, List<T> lista);
        public abstract T ConverterEmRegistro(IDataReader dataReader);      
        protected abstract Dictionary<string, object> ObtemParametrosRegistro(T registro);
        protected Dictionary<string, object> AdicionarParametro(string campo, object valor)
        {
            return new Dictionary<string, object>() { { campo, valor } };
        }
        public virtual ValidationResult InserirNovo(T registro)
        {
            var validator = ObterValidador(registro, SelecionarTodos());

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                int id = DataBase.Insert(SqlInsert, ObtemParametrosRegistro(registro));
                registro._id = id;
            }
            return resultadoValidacao;
        }
        public virtual ValidationResult Editar(int id, T registro)
        {
            var validator = ObterValidador(registro, SelecionarTodos());

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                registro._id = id;
                DataBase.Update(SqlUpdate, ObtemParametrosRegistro(registro));
            }
            return resultadoValidacao;
        }
        public virtual bool Existe(int id)
        {
            return DataBase.Exists(SqlExiste, AdicionarParametro("ID", id));
        }
        public virtual ValidationResult Excluir(int id)
        { 
            var resultadoValidacao = new ValidationResult();
            try
            {
                DataBase.Delete(SqlDelete, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));
                return resultadoValidacao;
            }

            return resultadoValidacao;
        }
        public virtual List<T> SelecionarTodos()
        {
            return DataBase.GetAll(SqlSelectAll, ConverterEmRegistro );
        }
        public virtual T SelecionarPorId(int id)
        {
            return DataBase.Get(SqlSelectId, ConverterEmRegistro, AdicionarParametro("ID", id));
        }

    }
}