using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    
    internal class M_Animal
    {
        public int codanimal { get; set; }
        public string nomeanimal { get; set; }
        public M_Sexo sexo { get; set; }
        public M_Raca raca { get; set; }
        public M_TipoAnimal tipoanimal { get; set; }  
        public M_Cliente cliente { get; set; }
    }
}
