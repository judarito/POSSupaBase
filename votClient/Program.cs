using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using votClient;
using votClient.HttpMessageHandler;
//using votClient.Services.Lideres;
using votClient.Services.Login;
using votClient.Services.Puestos;
using votClient.Services.ResumenVotosSer;
using votClient.Services.Votantes;
using votClient.Shared.Services;
using CommonBase.Services.Lideres;

const string ApiUrlBase = "https://jricardo0822-001-site1.ftempurl.com/api/";
//const string ApiUrlBase = "https://vot20231005162706.azurewebsites.net/api/";
//const string ApiUrlBase = "https://localhost:7010/api/";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(ApiUrlBase) });
builder.Services.AddScoped<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped(s =>
{
    var accessTokenHandler = s.GetRequiredService<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
    accessTokenHandler.InnerHandler = new HttpClientHandler();
    var uriHelper = s.GetRequiredService<NavigationManager>();
   
    return new HttpClient(accessTokenHandler)
    {
        BaseAddress = new Uri(ApiUrlBase)
    };
});
builder.Services.AddScoped<TokenServerAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<TokenServerAuthenticationStateProvider>());
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<SpinnerService>();
builder.Services.AddScoped<ILideresService, LideresService>();
builder.Services.AddScoped<IVotantesService, VotantesService>();
builder.Services.AddScoped<IPuestosService, PuestosService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IResumenVotosService, ResumenVotosService>();

await builder.Build().RunAsync();
