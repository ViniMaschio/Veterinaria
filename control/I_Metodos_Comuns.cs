using System;
using System.Collections.Generic;
using System.Data;

namespace Veterinaria.control
{
    internal interface I_Metodos_Comuns
    {
        void Insere_Dados(Object aux);

        void Apaga_Dados(int aux);

        Object Buscar_Id(int valor);

        Object Buscar_Todos();

        Object Buscar_Filtro(String dados);

        void Atualizar_Dados(Object aux);
    }
}

