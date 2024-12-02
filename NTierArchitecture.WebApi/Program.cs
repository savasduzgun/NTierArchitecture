

using NTierArchitecture.Business;

//dependency injection k�sm� (e�er bir class istenirse o class �n instance t�reten yap�lar)

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBusiness();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//middleware k�sm� (request yap�ld���nda �al��an kontrol ve benzeri i�lemlerri yapt�ktan sonra, sonraki middleware leri tetikleyip i�lemleri ger�ekle�tiren k�s�m)

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
