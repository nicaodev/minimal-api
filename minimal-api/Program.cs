using minimal_api.Data;
using minimal_api.ViewModels;

var builder = WebApplication.CreateBuilder(args);
// Injeção de Dependência.
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//https://localhost:7166/swagger/index.html



app.MapGet("/v1/pessoas", (AppDbContext context) =>
{
    var todos = context.pessoas;
    return todos is not null ? Results.Ok(todos) : Results.NotFound();
}).Produces<pessoa>();

app.MapPost("/v1/pessoas", (AppDbContext context, CreatePessoaViewModel model) =>
{
    var pessoa = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);

    context.pessoas.Add(pessoa);
    context.SaveChanges();

    return Results.Created($"/v1/pessoas/{pessoa.Id}", pessoa);
});

app.Run();
