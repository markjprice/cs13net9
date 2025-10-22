using Microsoft.EntityFrameworkCore.ChangeTracking; // To use EntityEntry<T>.
using Northwind.EntityModels; // To use Customer.
using Microsoft.EntityFrameworkCore; // To use ToArrayAsync.
using Microsoft.Extensions.Caching.Hybrid; // To use HybridCache.

namespace Northwind.WebApi.Repositories;

public class CustomerRepository : ICustomerRepository
{
  private readonly HybridCache _cache;

  // Use an instance data context field because it should not be
  // cached due to the data context having internal caching.
  private NorthwindContext _db;

  public CustomerRepository(NorthwindContext db,
    HybridCache hybridCache)
  {
    _db = db;
    _cache = hybridCache;
  }

  public Task<Customer[]> RetrieveAllAsync()
  {
    return _db.Customers.ToArrayAsync();
  }

  public async Task<Customer?> RetrieveAsync(string id,
    CancellationToken token = default)
  {
    id = id.ToUpper(); // Normalize to uppercase.

    return await _cache.GetOrCreateAsync(
      key: id, // Unique key to the cache entry.
      factory: async cancel => await _db.Customers
        .FirstOrDefaultAsync(c => c.CustomerId == id, token),
      cancellationToken: token);
  }


  public async Task<Customer?> CreateAsync(Customer c)
  {
    c.CustomerId = c.CustomerId.ToUpper(); // Normalize to uppercase.

    // Add to database using EF Core.
    EntityEntry<Customer> added = await _db.Customers.AddAsync(c);
    int affected = await _db.SaveChangesAsync();
    if (affected == 1)
    {
      // If saved to database then store in cache.
      await _cache.SetAsync(c.CustomerId, c);
      return c;
    }
    return null;
  }

  public async Task<Customer?> UpdateAsync(Customer c)
  {
    c.CustomerId = c.CustomerId.ToUpper();

    /*
    // Detach the existing tracked entity if it exists.
    Customer? alreadyTracked = _db.Customers.Local
      .FirstOrDefault(local => local.CustomerId == c.CustomerId);
    if (alreadyTracked is not null)
    {
      _db.Entry(alreadyTracked).State = EntityState.Detached;
    }
    _db.Entry(c).State = EntityState.Modified;
    */

    _db.ChangeTracker.Clear();

    _db.Customers.Update(c);

    int affected = await _db.SaveChangesAsync();
    if (affected == 1)
    {
      await _cache.SetAsync(c.CustomerId, c);
      return c;
    }
    return null;
  }

  public async Task<bool?> DeleteAsync(string id)
  {
    id = id.ToUpper();

    Customer? c = await _db.Customers.FindAsync(id);
    if (c is null) return null;

    _db.Customers.Remove(c);
    int affected = await _db.SaveChangesAsync();
    if (affected == 1)
    {
      await _cache.RemoveAsync(c.CustomerId);
      return true;
    }
    return null;
  }
}
