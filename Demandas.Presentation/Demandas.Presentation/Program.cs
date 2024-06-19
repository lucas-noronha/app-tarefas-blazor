using Demandas.Presentation.Client.Pages;
using Demandas.Presentation.Components;
using Microsoft.FluentUI.AspNetCore.Components;
using Demandas.CrossCutting.DependenciesApp;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection; // Certifique-se de que esta diretiva esteja presente se necessário
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

});
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

//Add custom services
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddRouting(builder => builder.LowercaseUrls = true);


//Add swagger documentation config
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Demandas.Presentation", Version = "v1" });
    c.EnableAnnotations();

    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    // Adiciona o arquivo XML de documentação do projeto Demandas.Application
    var xmlDTOFile = "Demandas.Application.xml"; // O nome do arquivo XML gerado
    var xmlDTOPath = Path.Combine(AppContext.BaseDirectory, xmlDTOFile);
    c.IncludeXmlComments(xmlDTOPath);
});


var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demandas.Presentation V1");
        c.RoutePrefix = string.Empty; // Para acessar o Swagger UI na raiz do aplicativo
    });
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseAntiforgery();

// Registros de rota de nível superior
app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Counter).Assembly);

app.Run();
