# 🐾 Sistema de Clínica Veterinária

Este projeto foi desenvolvido em dupla como parte da disciplina **Desenvolvimento de Aplicativos Desktop II** no curso de Análise e Desenvolvimento de Sistemas.

O objetivo do sistema é gerenciar os processos administrativos de uma clínica veterinária, incluindo o cadastro de animais, donos, funcionários, produtos, serviços e vendas. A aplicação foi construída com **C# utilizando .NET (Windows Forms)** e **SQL Server** como banco de dados.

## 🧑‍💻 Equipe

- Gabriel Maschio  
- Vinícius Maschio

## 🛠️ Tecnologias Utilizadas

- C#  
- .NET Framework  
- Windows Forms  
- SQL Server  
- ADO.NET

## 📦 Funcionalidades

- Cadastro de animais, donos, raças, tipos de animal e sexo
- Cadastro de endereço completo (rua, bairro, cidade, estado, país, CEP)
- Registro de funcionários, tipos de funcionários e suas lojas
- Gerenciamento de produtos, marcas, imagens e categorias
- Realização de vendas de produtos e serviços
- Relacionamento completo entre tabelas com integridade referencial
- Interface intuitiva para manipulação dos dados via Windows Forms

## 🧱 Estrutura do Banco de Dados

O banco de dados chama-se `Veterinaria_Unifunec` e contém diversas tabelas normalizadas com integridade entre entidades. Algumas entidades de destaque:

- `cliente`, `animal`, `funcionario`, `loja`, `produto`, `vendas`, `vendaservico`
- Tabelas auxiliares como `sexo`, `raca`, `bairro`, `estado`, `pais`, `cidanimal`, etc.
- Relacionamentos com *foreign keys* e controle de deleção/cascata
- Verificações de integridade com `CHECK`, `UNIQUE` e `NOT NULL`

> 💡 O script completo do banco de dados está documentado no projeto e pode ser utilizado para recriar a base no SQL Server.

## 💻 Como Executar

1. Clone este repositório:
   ```bash
   git clone https://github.com/ViniMaschio/Veterinaria
2. Abra o projeto no Visual Studio
3. Configure a string de conexão com o SQL Server
4. Execute a aplicação
