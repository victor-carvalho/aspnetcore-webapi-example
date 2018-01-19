using Microsoft.EntityFrameworkCore;
using WebApi.ContactService.Models;

namespace WebApi.ContactService.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}