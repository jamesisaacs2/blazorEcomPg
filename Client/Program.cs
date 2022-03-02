global using BlazorEcomApp.Shared;
using BlazorEcomApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Microsoft.AspNetCore.ResponseCompression;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//add services to container
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var app = builder.Build();

//configure HTTP request pipeline
/*if (app.Environment.IsDevelopment())
{
	app.UseWebAssemblyDebugging();
}
else
{
	app.UseExceptionHandler("/Error");
	//default HSTS value is 30 days.  May want to change for prod env.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
*/

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
