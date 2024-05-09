var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region 1) Run() method example
// app.Run(async (context) =>
// {
//     // short-circuits the http request pipeline and returns the response for each request to the server
//     await context.Response.WriteAsync("Hello from the short circuiter!");
//     Console.WriteLine("Hello from the short circuiter!");
// });
#endregion

#region 2) Use() method example
// app.Use(async (context, next) =>
// {
//     Console.WriteLine("Hello from the Use Middleware!");

//     // Do work that can write to the Response.
//     await next.Invoke(); // Go to the next middleware
//     // Do logging or other work that doesn't write to the Response.
//     Console.WriteLine("Bye bye from the Use Middleware!");
// });
// app.Run(async context =>
// {
//     Console.WriteLine("Hello from the short-circuiter!");
//     await context.Response.WriteAsync("Hello from the short-circuiter!");
// });

// Extra Note: "Visual Studio keymap extension is added."
#endregion

#region 3) Map() method example
// // Use Map middleware to route different paths to different handlers
// app.Map("/hello", HandleHelloRequest);
// app.Map("/goodbye", HandleGoodbyeRequest);

// // Define request handling methods
// static void HandleHelloRequest(IApplicationBuilder app)
// {
//     app.Use(async (context, next) =>
//     {
//         await context.Response.WriteAsync("Hello, World!");
//         Console.WriteLine("Hello!");
//         await next.Invoke(); // Go to the next middleware
//         Console.WriteLine("Continuing...");
//     });
// }

// static void HandleGoodbyeRequest(IApplicationBuilder app)
// {
//     app.Run(async context =>
//     {
//         await context.Response.WriteAsync("Goodbye, World!");
//         Console.WriteLine("Ended.");
//     });
// }
#endregion

#region 4) MapWhen() method example
// Use MapWhen middleware to conditionally handle GET requests
app.MapWhen(context => context.Request.Method == "GET", HandleGetRequests);

// Define request handling method for GET requests
static void HandleGetRequests(IApplicationBuilder app)
{
    app.Use(async (context, next) =>
    {
        // Custom logic for handling GET requests
        Console.WriteLine("Handling GET requests...");
        await next.Invoke();
    });
}
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();