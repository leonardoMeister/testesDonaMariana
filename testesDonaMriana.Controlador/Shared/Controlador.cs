using FluentValidation;
using System;
using System.Collections.Generic;
using TestesDonaMariana.Domain.Shared;
using FluentValidation.Results;

namespace eAgenda.Controladores.Shared
{
    public abstract class Controlador<T> where T : EntidadeBase
    {
        public abstract AbstractValidator<T> ObterValidador();
        public abstract List<T> ObterRegistros();

        public virtual ValidationResult InserirNovo(T registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                var lista = ObterRegistros();
                lista.Add(registro);
            }
            return resultadoValidacao;
        }
        public virtual ValidationResult Editar(int id, T registro)
        {
            var validator = ObterValidador();

            var resultadoValidacao = validator.Validate(registro);

            if (resultadoValidacao.IsValid)
            {
                registro._id = id;
                var lista = ObterRegistros();
                lista[lista.FindIndex(x => x._id == id)] = registro;
            }
            return resultadoValidacao;
        }
        public virtual bool Existe(int id)
        {
            var lista = ObterRegistros();
            T item = lista.Find(x => x._id == id);
            return (item != null) ? true : false;
        }
        public virtual ValidationResult Excluir(int id)
        {
            var resultadoValidacao = new ValidationResult();

            var lista = ObterRegistros();

            if (lista.Remove(lista.Find(x => x._id == id))   ==false)
                resultadoValidacao.Errors.Add(new ValidationFailure("", "Não foi possível remover o registro"));
            return resultadoValidacao;
        }
        public virtual List<T> SelecionarTodos()
        {
            var lista = ObterRegistros();
            List<T> novaLista = new List<T>(lista);
            return novaLista;
        }
        public virtual T SelecionarPorId(int id)
        {
            var lista = ObterRegistros();
            return lista.Find(x => x._id == id);
        }

    }
}