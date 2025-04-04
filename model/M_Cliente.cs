﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    
    internal class M_Cliente
    {
        public int codcliente {  get; set; }
        public String nomecliente { get; set; }
        public String cpf {  get; set; }
        public M_Bairro bairro { get; set; }
        public M_Rua rua { get; set; }
        public M_Cep cep { get; set; }
        public M_Cidade cidade { get; set; }
        public M_Estado estado { get; set; }
        public M_Pais pais { get; set; }
        public String numerocasa {  get; set; }   
        public Byte[] fotocliente { get; set; }

        public M_Cliente() { }

        public M_Cliente(int codcliente, string nomecliente, string cpf, M_Bairro bairro, M_Rua rua, M_Cep cep, M_Cidade cidade, M_Estado estado, M_Pais pais, string numeroca, byte[] fotocliente)
        {
            this.codcliente = codcliente;
            this.nomecliente = nomecliente;
            this.cpf = cpf;
            this.bairro = bairro;
            this.rua = rua;
            this.cep = cep;
            this.cidade = cidade;
            this.estado = estado;
            this.pais = pais;
            this.numerocasa = numeroca;
            this.fotocliente = fotocliente;
        }
    }
}
