using Microsoft.EntityFrameworkCore;

namespace Northwind.EntityModels;

public partial class NorthwindContext : DbContext
{
  public NorthwindContext()
  {
  }

  public NorthwindContext(DbContextOptions<NorthwindContext> options)
      : base(options)
  {
  }

  public virtual DbSet<Category> Categories { get; set; }

  public virtual DbSet<Customer> Customers { get; set; }

  public virtual DbSet<Employee> Employees { get; set; }

  public virtual DbSet<Order> Orders { get; set; }

  public virtual DbSet<OrderDetail> OrderDetails { get; set; }

  public virtual DbSet<Product> Products { get; set; }

  public virtual DbSet<Shipper> Shippers { get; set; }

  public virtual DbSet<Supplier> Suppliers { get; set; }

  protected override void OnConfiguring(
    DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      string database = "Northwind.db";
      string dir = Environment.CurrentDirectory;
      string path = string.Empty;

      if (dir.EndsWith("net9.0"))
      {
        // In the <project>\bin\<Debug|Release>\net9.0 directory.
        path = Path.Combine("..", "..", "..", "..", database);
      }
      else
      {
        // In the <project> directory.
        path = Path.Combine("..", database);
      }

      path = Path.GetFullPath(path); // Convert to absolute path.
      try
      {
        NorthwindContextLogger.WriteLine($"Database path: {path}");
      }
      catch (Exception ex)
      {
        WriteLine(ex.Message);
      }

      if (!File.Exists(path))
      {
        throw new FileNotFoundException(
          message: $"{path} not found.", fileName: path);
      }

      optionsBuilder.UseSqlite($"Data Source={path}");

      optionsBuilder.LogTo(NorthwindContextLogger.WriteLine,
        new[] { Microsoft.EntityFrameworkCore
        .Diagnostics.RelationalEventId.CommandExecuting });
    }
  }


  protected override void OnModelCreating(
    ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Order>(entity =>
    {
      entity.Property(e => e.Freight).HasDefaultValue(0.0M);
    });

    modelBuilder.Entity<OrderDetail>(entity =>
    {
      entity.Property(e => e.Quantity).HasDefaultValue((short)1);

      entity.HasOne(d => d.Order)
        .WithMany(p => p.OrderDetails)
        .OnDelete(DeleteBehavior.ClientSetNull);

      entity.HasOne(d => d.Product)
        .WithMany(p => p.OrderDetails)
        .OnDelete(DeleteBehavior.ClientSetNull);
    });

    modelBuilder.Entity<Product>(entity =>
    {
      entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);
      entity.Property(e => e.UnitPrice).HasDefaultValue(0.0M);
      entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
      entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

      entity.Property(product => product.UnitPrice)
        .HasConversion<double>();
    });

    OnModelCreatingPartial(modelBuilder);
  }

  partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
