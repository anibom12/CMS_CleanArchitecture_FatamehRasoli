using CMS.Presistence.EF;
using CMS.Presistence.EF.Hilo;
using CMS.Read.Dapper.Common;
using Microsoft.EntityFrameworkCore;
using CMS.Command.Users.v1;
using CMS.Query.Users.v1;
using CMS.Presistence.EF.Repositories.Users;
using CMS.Domain.Entity.User;
using CMS.RestApi.Common;
using CMS.Domain.Entity.Comments;
using CMS.Presistence.EF.Repositories.Comments;
using CMS.Command.Comments.v1;
using CMS.Query.Comments;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
//var cnnString = builder.Configuration.GetConnectionString("Cnn");

var cnnString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CMSDbContext>(options =>
    options.UseSqlServer(cnnString));

builder.Services.AddScoped<IDapperQuery>(provider => new DapperQuery(cnnString));
//builder.Services.AddDbContext<CMSDbContext>(options => options.UseSqlServer(cnnString));
//builder.Services.AddScoped<IDapperQuery>(provider => new DapperQuery(cnnString));
//builder.Services.AddDbContext<CMSDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(UserCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UserQueryHandler).Assembly);
});
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CommentCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CommentQueryHandler).Assembly);
});

builder.Services.AddScoped<ICommandBus, CommandBus>();
builder.Services.AddScoped<IQueryBus, QueryBus>();

builder.Services.AddScoped<IHiloIdGenerator, HiloIdGenerator>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapDefaultControllerRoute();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
