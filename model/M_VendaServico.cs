using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class M_VendaServico
    {
        public M_VendaServico() { }
        public int codvendaservico { get; set; }
        public M_Funcionario funcionario { get; set; }
        public M_Cliente cliente { get; set; }
        public DateTime datavenda { get; set; }
        public M_Animal animal { get; set; }
    }
}
