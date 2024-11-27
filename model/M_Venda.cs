using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class M_Venda
    {
        public int codvenda { get; set; }
        public DateTime datavenda { get; set; }
        public M_Cliente cliente { get; set; }
        public M_Funcionario funcionario { get; set; }
        public M_Loja loja { get; set; }

        public M_Venda() { }
    }
   
}
