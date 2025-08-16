using PetAmparo.Entities;
using Microsoft.OpenApi.Models;
using PetAmparo.Infra.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PetAmparoContext, PetAmparoContext>();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PetAmparo",
        Version = "v1",
        Description = "API para adoção de animais"
    });

    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"<b>JWT Autorização</b> <br/>
                            Digite 'Bearer' [espaço] e em seguida cole seu token na caixa de texto abaixo.
                            <br/> <br/>
                            <b>Exemplo:</b> 'bearer 123456abcdefg...'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(
    JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "PetAmaparo",
            ValidAudience = "PetAmparo",
            IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(
                  "{f45a021f-4537-467d-8550-ab41cba7dc59}"))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(cors => cors
    .AllowAnyOrigin()
    .AllowAnyMethod() //GET - POST - PUT - DELETE
    .AllowAnyHeader()
);

app.UseAuthentication();
app.UseAuthorization();

#region Usuario

app.MapPost("usuario/adicionar", (PetAmparoContext context, Usuario usuario) =>
{
    context.UsuarioSet.Add(usuario);
    context.SaveChanges();

    return Results.Created("Created", "Usuario Adicionado com Sucesso.");
}).RequireAuthorization().WithTags("Usuário");

app.MapGet("Usuario/listar", (PetAmparoContext context) =>
{
    var listaUsuario = context.UsuarioSet.ToList();
    return Results.Ok(listaUsuario);
}).RequireAuthorization().WithTags("Usuário");

app.MapPut("Usuario/atualizar", (PetAmparoContext context, Usuario usuario) =>
{
    context.UsuarioSet.Update(usuario);
    context.SaveChanges();

    return Results.Ok("Usuario Atualizado com Sucesso.");
}).RequireAuthorization().WithTags("Usuário");

app.MapDelete("usuario/excluir/{id:guid}", (PetAmparoContext context, Guid id) =>
{
    var usuario = context.UsuarioSet.Find(id);

    if (usuario is null)
        return Results.BadRequest("Usuario não encontrado.");

    context.UsuarioSet.Remove(usuario);
    context.SaveChanges();

    return Results.Ok("Usuário Excluído com Sucesso.");
}).RequireAuthorization().WithTags("Usuário");

#endregion 

#region Animal

app.MapPost("animal/adicionar", (PetAmparoContext context, Animal animal) =>
{
    context.AnimalSet.Add(animal);
    context.SaveChanges();

    return Results.Created("Created", "Animal Adicionado com Sucesso.");
}).RequireAuthorization().WithTags("Animal");

app.MapGet("animal/listar", (PetAmparoContext context) =>
{
    var listaAnimal = context.AnimalSet.ToList();
    return Results.Ok(listaAnimal);
}).RequireAuthorization().WithTags("Animal");

app.MapPut("animal/atualizar", (PetAmparoContext context, Animal animal) =>
{
    context.AnimalSet.Update(animal);
    context.SaveChanges();

    return Results.Ok("Animal Atualizado com Sucesso.");
}).RequireAuthorization().WithTags("Animal");

app.MapDelete("animal/excluir/{id:guid}", (PetAmparoContext context, Guid id) =>
{
    var animal = context.AnimalSet.Find(id);

    if (animal is null)
        return Results.BadRequest("Animal não encontrado.");

    context.AnimalSet.Remove(animal);
    context.SaveChanges();

    return Results.Ok("Animal Excluído com Sucesso.");
}).RequireAuthorization().WithTags("Animal");

#endregion

#region publicacao

app.MapPost("publicacao/adicionar", (PetAmparoContext context, Publicacao publicacao) =>
{
    context.PublicacaoSet.Add(publicacao);
    context.SaveChanges();

    return Results.Created("Created", "Publicação Adicionado com Sucesso.");
}).RequireAuthorization().WithTags("Publicação");

app.MapGet("publicacao/listar", (PetAmparoContext context) =>
{
    var listaPublicacao = context.PublicacaoSet.ToList();
    return Results.Ok(listaPublicacao);
}).RequireAuthorization().WithTags("Publicação");

app.MapPut("publicacao/atualizar", (PetAmparoContext context, Publicacao publicacao) =>
{
    context.PublicacaoSet.Update(publicacao);
    context.SaveChanges();

    return Results.Ok("Publicação Atualizado com Sucesso.");
}).RequireAuthorization().WithTags("Publicação");

app.MapDelete("publicacao/excluir/{id:guid}", (PetAmparoContext context, Guid id) =>
{
    var publicacao = context.PublicacaoSet.Find(id);

    if (publicacao is null)
        return Results.BadRequest("Publicação não encontrado.");

    context.PublicacaoSet.Remove(publicacao);
    context.SaveChanges();

    return Results.Ok("Publicação Excluído com Sucesso.");
}).RequireAuthorization().WithTags("Publicação");

#endregion

#region Ong

app.MapPost("ong/adicionar", (PetAmparoContext context, Ong ong) =>
{
    context.OngSet.Add(ong);
    context.SaveChanges();

    return Results.Created("Created", "Ong Adicionado com Sucesso.");
}).RequireAuthorization().WithTags("Ong");

app.MapGet("ong/listar", (PetAmparoContext context) =>
{
    var listaOng = context.OngSet.ToList();
    return Results.Ok(listaOng);
}).RequireAuthorization().WithTags("Ong");

app.MapPut("animal/atualizar", (PetAmparoContext context, Ong ong) =>
{
    context.OngSet.Update(ong);
    context.SaveChanges();

    return Results.Ok("Ong Atualizado com Sucesso.");
}).RequireAuthorization().WithTags("Ong");

app.MapDelete("ong/excluir/{id:guid}", (PetAmparoContext context, Guid id) =>
{
    var ong = context.OngSet.Find(id);

    if (ong is null)
        return Results.BadRequest("Ong não encontrado.");

    context.OngSet.Remove(ong);
    context.SaveChanges();

    return Results.Ok("Ong Excluído com Sucesso.");
}).RequireAuthorization().WithTags("Ong");

#endregion

#region Adocao

app.MapPost("adocao/adicionar", (PetAmparoContext context, Adocao adocao) =>
{
    context.AdocaoSet.Add(adocao);
    context.SaveChanges();

    return Results.Created("Created", "Adoção Adicionado com Sucesso.");
}).RequireAuthorization().WithTags("Adoção");

app.MapGet("adocao/listar", (PetAmparoContext context) =>
{
    var listaAdocao = context.PublicacaoSet.ToList();
    return Results.Ok(listaAdocao);
}).RequireAuthorization().WithTags("Adoção");

app.MapPut("adocao/atualizar", (PetAmparoContext context, Adocao adocao) =>
{
    context.AdocaoSet.Update(adocao);
    context.SaveChanges();

    return Results.Ok("Adoção Atualizado com Sucesso.");
}).RequireAuthorization().WithTags("Adoção");

app.MapDelete("adocao/excluir/{id:guid}", (PetAmparoContext context, Guid id) =>
{
    var adocao = context.AdocaoSet.Find(id);

    if (adocao is null)
        return Results.BadRequest("Adoção não encontrado.");

    context.AdocaoSet.Remove(adocao);
    context.SaveChanges();

    return Results.Ok("Adoção Excluído com Sucesso.");
}).RequireAuthorization().WithTags("Adoção");

#endregion

app.UseHttpsRedirection();
app.UseAuthorization();


app.Run();
