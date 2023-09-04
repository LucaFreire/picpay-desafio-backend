using picpay_desafio_backend.Model;
using picpay_desafio_backend.Respositories;
using picpay_desafio_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "MainPolicy",
    policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .Build();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PicpayDesafioBackendContext>();
builder.Services.AddTransient<IRepository<Transaction>, TransactionsRespository>();
builder.Services.AddTransient<IRepository<User>, UserRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITransactionsService, TransactionsService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();