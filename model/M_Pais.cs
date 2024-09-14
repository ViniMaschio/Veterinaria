using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    internal class M_Pais
    {
        public int codpais {  get; set; }
        public String nomepais { get; set; }
        public Byte[] bandeira { get; set; }

        public M_Pais() { } //Construtor padrão da classe Pais
        public M_Pais(int codpais, string nomepais, byte[] bandeira)
        {
            this.codpais = codpais;
            this.nomepais = nomepais;
            this.bandeira = bandeira;
        }
    }
}
