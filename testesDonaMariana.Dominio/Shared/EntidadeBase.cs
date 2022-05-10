using System;

namespace eAgenda.Dominio.Shared
{
    public abstract class EntidadeBase
    {
        public int _id;

        public abstract string Validar();

    }
}