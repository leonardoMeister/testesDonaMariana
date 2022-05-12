using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesDonaMariana.Domain.MateriaDir
{
    public enum BimestreEnum
    {
        [Description("Primeiro Bimestre")]
        PrimeiroBimestre =1,
        [Description("Segundo Bimestre")]
        SegundoBimestre =2,
        [Description("Terceiro Bimestre")]
        TerceiroBimestre =3,
        [Description("Quarto Bimestre")]
        QuartoBimestre =4
    }
}
