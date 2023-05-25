using Microsoft.EntityFrameworkCore;
using AgroSimply_V2.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace AgroSimply_V2;

public static class UsuarioEndpoints
{
    public static void MapUsuarioEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Usuario").WithTags(nameof(Usuario));

        group.MapGet("/", async (AgroSimply_V2Context db) =>
        {
            return await db.Usuario.ToListAsync();
        })
        .WithName("GetAllUsuarios")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Usuario>, NotFound>> (string idusuario, AgroSimply_V2Context db) =>
        {
            return await db.Usuario.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdUsuario == idusuario)
                is Usuario model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetUsuarioById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (string idusuario, Usuario usuario, AgroSimply_V2Context db) =>
        {
            var affected = await db.Usuario
                .Where(model => model.IdUsuario == idusuario)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.IdUsuario, usuario.IdUsuario)
                  .SetProperty(m => m.ProdutorId, usuario.ProdutorId)
                  .SetProperty(m => m.CPF, usuario.CPF)
                  .SetProperty(m => m.Tipo, usuario.Tipo)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateUsuario")
        .WithOpenApi();

        group.MapPost("/", async (Usuario usuario, AgroSimply_V2Context db) =>
        {
            db.Usuario.Add(usuario);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Usuario/{usuario.IdUsuario}",usuario);
        })
        .WithName("CreateUsuario")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (string idusuario, AgroSimply_V2Context db) =>
        {
            var affected = await db.Usuario
                .Where(model => model.IdUsuario == idusuario)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteUsuario")
        .WithOpenApi();
    }
}
