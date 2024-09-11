using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /*--TelefoneLoja = {codlojafk, codtelefonefk} OK  */
    internal class Telefoneloja
    {
        public Loja loja {  get; set; }
        public Telefone telefone { get; set; }
    }
}
