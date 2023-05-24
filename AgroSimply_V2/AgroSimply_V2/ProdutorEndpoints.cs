using Microsoft.EntityFrameworkCore;
using AgroSimply_V2.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AgroSimply_V2;

public static class ProdutorEndpoints
{
    public static void MapProdutorEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Produtor").WithTags(nameof(Produtor));

        group.MapGet("/", async (AgroSimply_V2Context db) =>
        {
            return await db.Produtor.ToListAsync();
        })
        .WithName("GetAllProdutors")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Produtor>, NotFound>> (string idprodutor, AgroSimply_V2Context db) =>
        {
            return await db.Produtor.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdProdutor == idprodutor)
                is Produtor model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProdutorById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (string idprodutor, Produtor produtor, AgroSimply_V2Context db) =>
        {
            var affected = await db.Produtor
                .Where(model => model.IdProdutor == idprodutor)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IdProdutor, produtor.IdProdutor)
                  .SetProperty(m => m.Nome, produtor.Nome)
                  .SetProperty(m => m.Email, produtor.Email)
                  .SetProperty(m => m.CPF, produtor.CPF)
                  .SetProperty(m => m.CNPJ, produtor.CNPJ)
                  .SetProperty(m => m.Atividade, produtor.Atividade)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProdutor")
        .WithOpenApi();

        group.MapPost("/", async (Produtor produtor, AgroSimply_V2Context db) =>
        {
            db.Produtor.Add(produtor);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Produtor/{produtor.IdProdutor}",produtor);
        })
        .WithName("CreateProdutor")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (string idprodutor, AgroSimply_V2Context db) =>
        {
            var affected = await db.Produtor
                .Where(model => model.IdProdutor == idprodutor)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProdutor")
        .WithOpenApi();
    }
}
