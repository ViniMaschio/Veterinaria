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
        public Telefone telefone {  get; set; }
        public Cliente cliente { get; set; }

    }
}
