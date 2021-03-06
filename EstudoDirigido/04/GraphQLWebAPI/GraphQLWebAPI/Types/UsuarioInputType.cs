﻿using GraphQL.Types;
using GraphQLWebAPI.Infra;

namespace GraphQLWebAPI.Types
{
    public class UsuarioInputType : InputObjectGraphType<Usuario>
    {
        public UsuarioInputType()
        {
            Name = "UsuarioInput";
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id usuário");
            Field(x => x.Idade).Description("Idade do usuário");
            Field(x => x.Nome).Description("Nome do usuário");
            Field(x => x.DataCriacao, type: typeof(DateTimeGraphType)).Description("Data criação usuário");
        }
    }
}
