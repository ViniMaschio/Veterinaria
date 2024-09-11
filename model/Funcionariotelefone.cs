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
        public Telefone telefone {  get; set; }
        public Funcionario funcionario { get; set; }

    }
}
