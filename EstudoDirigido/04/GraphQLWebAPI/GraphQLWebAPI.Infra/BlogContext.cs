using Microsoft.EntityFrameworkCore;

namespace GraphQLWebAPI.Infra
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> opcoes) : base(opcoes)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}