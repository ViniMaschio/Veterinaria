using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /* -- Animal = {codanimal, nomeanimal, codsexofk, codracafk, 
     * codtipoanimalfk, codclientefk} OK */
    internal class Animal
    {
        public int codanimal { get; set; }
        public string nomeanimal { get; set; }
        public M_Sexo sexo { get; set; }
        public Raca raca { get; set; }
        public M_TipoAnimal tipoanimal { get; set; }  
        public Cliente cliente { get; set; }
    }
}
