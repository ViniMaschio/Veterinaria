using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /* -- FuncionarioTelefone = {codtelefonefk, codfuncionariofk} OK*/
    internal class Funcionariotelefone
    {
        public M_Telefone telefone {  get; set; }
        public M_Funcionario funcionario { get; set; }

    }
}
