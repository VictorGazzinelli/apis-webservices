using GraphQL.Types;
using GraphQLWebAPI.Mutations;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GraphQLWebAPI
{
    public class BlogSchema : Schema
    {
        public BlogSchema(IServiceProvider serviceProvider)
        : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<BlogQuery>();
            Mutation = serviceProvider.GetRequiredService<BlogMutation>();

        }
    }
}