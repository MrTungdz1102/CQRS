using Blazored.LocalStorage;
using Blazored.Toast;
using CQRS.BlazorUI;
using CQRS.BlazorUI.Handler;
using CQRS.BlazorUI.InterfaceContracts;
using CQRS.BlazorUI.Provider;
using CQRS.BlazorUI.Services;
using CQRS.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7108")).AddHttpMessageHandler<JwtAuthorizationMessageHandler>();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
// package microsoft.extensions.http

builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();
builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

await builder.Build().RunAsync();
