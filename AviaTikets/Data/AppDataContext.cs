using AviaTikets.Models;
using Microsoft.EntityFrameworkCore;

namespace AviaTikets.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) 
        {
            
        }


        public DbSet<Tickets> ticketsProperties { get; set; }


    }
}
