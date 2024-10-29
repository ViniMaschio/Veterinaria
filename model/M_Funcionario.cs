using System;

namespace Veterinaria.model
{

    internal class M_Funcionario
    {
        public int codfuncionario { get; set; }
        public String nomefuncionario { get; set; }
        public M_Tipofuncionario tipofuncionario { get; set; }
        public M_Loja loja { get; set; }
    }
}
