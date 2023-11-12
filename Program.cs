using Microsoft.EntityFrameworkCore;
using IsComing.Data;
using IsComing.Grid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// register factory and configure the options
#region snippet1
builder.Services.AddDbContextFactory<ContactContext>(opt =>
    opt.UseSqlite($"Data Source={nameof(ContactContext.ContactsDb)}.db"));
#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
