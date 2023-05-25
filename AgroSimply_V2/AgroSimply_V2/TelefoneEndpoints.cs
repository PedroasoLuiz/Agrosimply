using Microsoft.EntityFrameworkCore;
using AgroSimply_V2.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AgroSimply_V2;

public static class TelefoneEndpoints
{
    public static void MapTelefoneEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Telefone").WithTags(nameof(Telefone));

        group.MapGet("/", async (AgroSimply_V2Context db) =>
        {
            return await db.Telefone.ToListAsync();
        })
        .WithName("GetAllTelefones")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Telefone>, NotFound>> (int idtel, AgroSimply_V2Context db) =>
        {
            return await db.Telefone.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdTel == idtel)
                is Telefone model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTelefoneById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idtel, Telefone telefone, AgroSimply_V2Context db) =>
        {
            var affected = await db.Telefone
                .Where(model => model.IdTel == idtel)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IdTel, telefone.IdTel)
                  .SetProperty(m => m.ProdutorId, telefone.ProdutorId)
                  .SetProperty(m => m.Numero, telefone.Numero)
                  .SetProperty(m => m.Tipo, telefone.Tipo)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTelefone")
        .WithOpenApi();

        group.MapPost("/", async (Telefone telefone, AgroSimply_V2Context db) =>
        {
            db.Telefone.Add(telefone);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Telefone/{telefone.IdTel}",telefone);
        })
        .WithName("CreateTelefone")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idtel, AgroSimply_V2Context db) =>
        {
            var affected = await db.Telefone
                .Where(model => model.IdTel == idtel)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTelefone")
        .WithOpenApi();
    }
}
