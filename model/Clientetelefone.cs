using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /*ClienteTelefone = {codtelefonefk, codclientefk} OK */
    internal class Clientetelefone
    {
        public M_Telefone telefone {  get; set; }
        public M_Cliente cliente { get; set; }

    }
}
