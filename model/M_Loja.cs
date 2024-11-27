using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
   
    internal class M_Loja
    {
        public int codloja {  get; set; }
        public String nomeloja { get; set; }
        public M_Bairro bairro { get; set; }
        public M_Rua rua { get; set; }
        public M_Cep cep { get; set; }  
        public M_Cidade cidade { get; set; }
        public M_Estado estado { get; set; }
        public M_Pais pais { get; set; }
        public String numeroloja { get; set; }
        public String cnpj { get; set; }    
    }
}
