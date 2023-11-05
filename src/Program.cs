using picpay_desafio_backend.Model;
using picpay_desafio_backend.Repositories;
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

builder.Services.AddSingleton<PicpayDesafioBackendContext>();
builder.Services.AddTransient<IRepository<Transaction>, TransactionsRepository>();
builder.Services.AddTransient<IRepository<User>, UserRepository>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();

builder.Services.AddTransient<IAuthorizeService>(_ =>
    new AuthorizeService()
    {
        ServiceURL = "https://run.mocky.io/v3/8fafdd68-a090-496f-8c9a-3442cf30dae6"
    }
);

builder.Services.AddTransient<INotification>(_ =>
    new Notification()
    {
        ServiceURL = "http://o4d9z.mocklab.io/notify"
    }
);

var app = builder.Build();
if (app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.Run();