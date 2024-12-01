using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class M_VendasProdutos
    {
        public M_VendasProdutos() {  }

        public M_Venda venda { get; set; }
        public M_Produto produto { get; set; }
        public double quantv { get; set; }
        public double valorv { get; set; }
    }
}
