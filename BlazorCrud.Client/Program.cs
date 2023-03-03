using BlazorCrud.Client;
using BlazorCrud.Client.Interfaces;
using BlazorCrud.Client.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5271") });

builder.Services.AddScoped<IDepartamentService, DepartamentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddSweetAlert2();



await builder.Build().RunAsync();
