﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinaria.model
{
    /*--TelefoneLoja = {codlojafk, codtelefonefk} OK  */
    internal class Telefoneloja
    {
        public M_Loja loja {  get; set; }
        public M_Telefone telefone { get; set; }
    }
}
