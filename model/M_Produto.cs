using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class M_Produto
    {
        public int codproduto { get; set; }
        public String nomeproduto { get; set; }
        public Double quantidade { get; set; }
        public Double valor { get; set; }
        public M_Marca marca { get; set; }
        public M_TipoProduto tipoproduto { get; set; }
    }
}
