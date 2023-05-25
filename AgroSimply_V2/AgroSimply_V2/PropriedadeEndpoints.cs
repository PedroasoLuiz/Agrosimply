using Microsoft.EntityFrameworkCore;
using AgroSimply_V2.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AgroSimply_V2;

public static class PropriedadeEndpoints
{
    public static void MapPropriedadeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Propriedade").WithTags(nameof(Propriedade));

        group.MapGet("/", async (AgroSimply_V2Context db) =>
        {
            return await db.Propriedade.ToListAsync();
        })
        .WithName("GetAllPropriedades")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Propriedade>, NotFound>> (int idpropriedade, AgroSimply_V2Context db) =>
        {
            return await db.Propriedade.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdPropriedade == idpropriedade)
                is Propriedade model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPropriedadeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idpropriedade, Propriedade propriedade, AgroSimply_V2Context db) =>
        {
            var affected = await db.Propriedade
                .Where(model => model.IdPropriedade == idpropriedade)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IdPropriedade, propriedade.IdPropriedade)
                  .SetProperty(m => m.Nome, propriedade.Nome)
                  .SetProperty(m => m.Cidade, propriedade.Cidade)
                  .SetProperty(m => m.Cultura, propriedade.Cultura)
                  .SetProperty(m => m.Localização, propriedade.Localização)
                  .SetProperty(m => m.Extensão, propriedade.Extensão)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePropriedade")
        .WithOpenApi();

        group.MapPost("/", async (Propriedade propriedade, AgroSimply_V2Context db) =>
        {
            db.Propriedade.Add(propriedade);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Propriedade/{propriedade.IdPropriedade}",propriedade);
        })
        .WithName("CreatePropriedade")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idpropriedade, AgroSimply_V2Context db) =>
        {
            var affected = await db.Propriedade
                .Where(model => model.IdPropriedade == idpropriedade)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePropriedade")
        .WithOpenApi();
    }
}
