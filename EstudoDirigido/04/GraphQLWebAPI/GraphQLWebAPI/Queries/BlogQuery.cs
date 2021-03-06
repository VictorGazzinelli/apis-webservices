﻿
using GraphQLWebAPI.Infra;
using GraphQL.Types;
using GraphQL;

namespace GraphQLWebAPI
{
    public class BlogQuery : ObjectGraphType<object>
    {
        public BlogQuery(UsuarioRepositorio repositorio)
        {
            Field<ListGraphType<UsuarioType>>("usuario",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IdGraphType>{Name="id"},
                    new QueryArgument<StringGraphType>{Name="nome"}
                }),
                resolve: contexto =>
                {
                    var filtro = new UsuarioFiltro()
                    {
                        Id = contexto.GetArgument<int>("id"),
                        Nome = contexto.GetArgument<string>("nome"),
                    };
                    return repositorio.ObterUsuarios(filtro);
                }

                );
        }
    }
}