using Microsoft.EntityFrameworkCore;
using SMSData.Models;
using SMSDomain.Data;
using SMSData.utility;


namespace SMS.Test.Controllers.Test;

public class InMemoryContext : DataContext
{
    public InMemoryContext(DbContextOptions<InMemoryContext> options): base(options){}
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
    }
}