using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class M_ItensVendaServico
    {
        public M_ItensVendaServico() { }

        public M_TipoServico tiposervico { get; set; }
        public M_VendaServico vendaservico { get; set; }
        public double quant { get; set; }
        public double valor { get; set; }
        public M_CidAnimal cidanimal { get; set; }
    }
}
