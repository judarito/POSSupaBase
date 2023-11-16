using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;
using votClient;
using votClient.HttpMessageHandler;
//using votClient.Services.Lideres;
//using votClient.Services.Login;
//using votClient.Services.Puestos;
using CommonBase.Services.ResumenVotosSer;
//using votClient.Services.Votantes;
using CommonBase.Shared.Services;
using CommonBase.Services.Lideres;
using CommonBase.Services.Votantes;
using CommonBase.Services.Puestos;
using CommonBase.Services.Login;
using votClient.Providers;
using CommonBase.Services.AuthService;
using CommonBase.Services.DatabaseService;

const string ApiUrlBase = "https://jricardo0822-001-site1.ftempurl.com/api/";
//const string ApiUrlBase = "https://vot20231005162706.azurewebsites.net/api/";
//const string ApiUrlBase = "https://localhost:7010/api/";

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(ApiUrlBase) });
builder.Services.AddScoped<BlazorDisplaySpinnerAutomaticallyHttpMessageHandler>();
builder.Services.AddBlazoredSessionStorage();
// ---------- BLAZOR AUTH
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>(
    provider => new CustomAuthStateProvider(
        provider.GetRequiredService<Supabase.Client>(),
        provider.GetRequiredService<ILogger<CustomAuthStateProvider>>()
    )
)
    ;
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



// ---------- SUPABASE
var url = "https://pylvavifkbhxqgubnksg.supabase.co";
var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InB5bHZhdmlma2JoeHFndWJua3NnIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MDAwNTQwMDYsImV4cCI6MjAxNTYzMDAwNn0.VEMSDcQ-095_GZmSAMge5_Wxv9bNr6a25TZeKt4Awfk";

builder.Services.AddScoped<Supabase.Client>(
    provider => new Supabase.Client(
        url,
        key,
        new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
            SessionHandler = new CustomSupabaseSessionHandler(
                provider.GetRequiredService<ISessionStorageService>(),
                provider.GetRequiredService<ILogger<CustomSupabaseSessionHandler>>()
            )
        }
    )
);

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<SpinnerService>();
//builder.Services.AddScoped<ILideresService, LideresService>();
//builder.Services.AddScoped<IVotantesService, VotantesService>();
//builder.Services.AddScoped<IPuestosService, PuestosService>();
builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddScoped<IResumenVotosService, ResumenVotosService>();

await builder.Build().RunAsync();
