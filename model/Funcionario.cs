using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /* -- Funcionario = {codfuncionario, nomefuncionario, 
     * codtipofuncionariofk, codlojafk } OK*/
    internal class Funcionario
    {
        public int codfuncionario {  get; set; }
        public String nomefuncionario { get; set; }
        public Tipofuncionario tipofuncionario { get; set; }
        public Loja loja { get; set; }
    }
}
