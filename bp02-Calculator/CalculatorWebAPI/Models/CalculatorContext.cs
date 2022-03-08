using Microsoft.EntityFrameworkCore;

namespace CalculatorWebAPI.Models;

public class CalculatorContext : DbContext
{
    public DbSet<CalculatorModel> Calculations { get; set; }

    public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options)
    {
        
    }
}