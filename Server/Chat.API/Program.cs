using Chat.Application.CQRS.Commands.CreateMessage;
using Chat.Application.CQRS.Commands.RegisterUser;
using Chat.Infrastructure;
using Chat.Infrastructure.SignalR;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateMessageCommandHandler).Assembly));

builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();
builder.Services.AddTransient<IValidator<RegisterUserCommand>, RegisterUserCommandValidator>();

builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins(
            "http://localhost:4200",
            "http://10.186.157.107:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        );
});

builder.WebHost.UseUrls("http://0.0.0.0:5260");

var app = builder.Build();

app.MapHub<MessageHub>("messageHub");

app.UseCors("AllowOrigin");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
