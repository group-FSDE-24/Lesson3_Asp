var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();


// Custom middleware elave etmek isteyirikse asagidaki yollar ile elave ede bilerik

// 1. app.Use()         => middleware elave edirsen, ozunden sonrakinida taniyir

// 2. app.Run()         => en son middlewaredir, ozunden sonra hec 1 middleware isletmir

// 3. app.Map()         => hansisa 1 controllere gore isleyen middleware-dir. 

// 4. app.MapWhen()     => her hansi 1 serte gore isleyir


// /////////////////////////////////////////////////


#region UseMiddlewareExample

// Example use

// app.Use(async (context, next) =>
// {
//     Console.Out.WriteLine("Use middleware-i isledi app1");
//     await next();
//     Console.Out.WriteLine("Use middleware-i sonlandi app1");
// });

// app.Use(async (context, next) =>
// {
//     Console.Out.WriteLine("Use middleware-i isledi app2");
//     await next();
//     Console.Out.WriteLine("Use middleware-i sonlandi app2");
// });

#endregion

#region RunMiddlewareExample

// app.Run( async (context) =>
// {
//     Console.Out.WriteLine("Run middleware-i isledi");
// });

// // Islemeyecek
//app.Use(async (context, next) =>
//{
//    Console.Out.WriteLine("Use middleware-i isledi app2");
//    await next();
//    Console.Out.WriteLine("Use middleware-i sonlandi app2");
//});

#endregion

#region MapMiddlewareExample

// app.Map("/test", app =>
// {
//     app.Use(async (context, next) =>
//     {
//         Console.Out.WriteLine("Map middleware-i isledi");
//         await next();
//         Console.Out.WriteLine("Map middleware-i sonlandi");
//     });
// });

#endregion

#region MapWhenMiddlewareExample

// app.MapWhen(
//     context => context.Request.Path == "/admin",
//     adminApp =>
//     {
//         adminApp.Run(async context =>
//         {
//             await context.Response.WriteAsync("Admin sehifesi");
//         });
//     });

#endregion


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
