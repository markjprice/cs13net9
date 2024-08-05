using Microsoft.AspNetCore.Mvc; // To use ProblemDetails.
using Northwind.EntityModels; // To use Customer.
using Northwind.WebApi.Repositories; // To use ICustomerRepository.

static partial class Program
{
  internal static void MapCustomers(this WebApplication app)
  {
    // GET: /customers
    app.MapGet(pattern: "/customers", handler:
      async (ICustomerRepository repo) =>
    {
      return await repo.RetrieveAllAsync();
    });

    // GET: /customers/in/[country]
    app.MapGet(pattern: "/customers/in/{country}", handler:
      async (string country, ICustomerRepository repo) =>
    {
      return (await repo.RetrieveAllAsync())
        .Where(customer => customer.Country == country);
    });

    // GET: /customers/[id]
    app.MapGet("/customers/{id:regex(^[A-Z]{{5}}$)}", 
      async Task<IResult> (string id, ICustomerRepository repo,
        CancellationToken token = default) =>
    {
      Customer? c = await repo.RetrieveAsync(id, token);
      if (c is null)
      {
        return TypedResults.NotFound(); // 404 Resource not found.
      }
      return TypedResults.Ok(c); // 200 OK with customer in body.
    });

    // POST: /customers
    // BODY: Customer (JSON)
    app.MapPost(pattern: "/customers", handler:
      async Task<IResult> (Customer c, 
        ICustomerRepository repo) =>
    {
      if (c is null)
      {
        return TypedResults.BadRequest(); // 400 Bad request.
      }
      Customer? addedCustomer = await repo.CreateAsync(c);
      if (addedCustomer is null)
      {
        return TypedResults.BadRequest("Repository failed to create customer.");
      }
      else
      {
        return TypedResults.Created( // 201 Created.
          uri: $"/customers/{addedCustomer.CustomerId}",
          value: addedCustomer);
      }
    });

    // PUT: /customers/[id]
    // BODY: Customer (JSON)
    app.MapPut(pattern: "/customers/{id}", handler:
      async Task<IResult> (Customer c,
        string id, ICustomerRepository repo,
        CancellationToken token = default) =>
    {
      id = id.ToUpper();
      c.CustomerId = c.CustomerId.ToUpper();
      if (c is null || c.CustomerId != id)
      {
        return TypedResults.BadRequest(); // 400 Bad request.
      }
      Customer? existing = await repo.RetrieveAsync(id, token);
      if (existing is null)
      {
        return TypedResults.NotFound(); // 404 Resource not found.
      }
      await repo.UpdateAsync(c);
      return TypedResults.NoContent(); // 204 No content.
    });

    // DELETE: /customers/[id]
    app.MapDelete(pattern: "/customers/{id}", handler:
      async Task<IResult> (string id, ICustomerRepository repo,
        CancellationToken token = default) =>
    {
      // Take control of problem details.
      if (id == "bad")
      {
        ProblemDetails problemDetails = new()
        {
          Status = StatusCodes.Status400BadRequest,
          Type = "https://localhost:5151/customers/failed-to-delete",
          Title = $"Customer ID {id} found but failed to delete.",
          Detail = "More details like Company Name, Country and so on."
        };
        return TypedResults.BadRequest(problemDetails); // 400 Bad Request
      }

      Customer? existing = await repo.RetrieveAsync(id, token);
      if (existing is null)
      {
        return TypedResults.NotFound(); // 404 Resource not found.
      }
      bool? deleted = await repo.DeleteAsync(id);
      if (deleted.HasValue && deleted.Value) // Short circuit AND.
      {
        return TypedResults.NoContent(); // 204 No content.
      }
      else
      {
        return TypedResults.BadRequest( // 400 Bad request.
      $"Customer {id} was found but failed to delete.");
      }
    });
  }
}
