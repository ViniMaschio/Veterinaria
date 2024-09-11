using System;

namespace Veterinaria.model
{
    internal class M_Sexo
    {
        public int codsexo { get; set; }
        public String nomesexo { get; set; }

        //Construtor Padrão
        public M_Sexo() { }

        public M_Sexo(int codsexo, string nomesexo)
        {
            this.codsexo = codsexo;
            this.nomesexo = nomesexo;
        }
    }
}
