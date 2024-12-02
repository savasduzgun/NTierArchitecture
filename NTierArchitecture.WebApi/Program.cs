

using NTierArchitecture.Business;

//dependency injection kýsmý (eðer bir class istenirse o class ýn instance türeten yapýlar)

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBusiness();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//middleware kýsmý (request yapýldýðýnda çalýþan kontrol ve benzeri iþlemlerri yaptýktan sonra, sonraki middleware leri tetikleyip iþlemleri gerçekleþtiren kýsým)

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
