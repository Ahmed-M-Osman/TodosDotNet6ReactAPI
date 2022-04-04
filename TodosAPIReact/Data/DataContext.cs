using Microsoft.EntityFrameworkCore;
using TodosAPIReact.Models;

namespace TodosAPIReact.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }
    }
}
