var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Время жизни сессии
});

// Добавляем сервисы для контроллеров с представлениями
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Конфигурация конвейера обработки HTTP-запросов
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Включаем сессии
app.UseSession();

app.UseRouting();
app.UseAuthorization();

// Настройка маршрутов
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "userProfile",
    pattern: "User/Profile/{id?}",
    defaults: new { controller = "User", action = "Profile" });

app.Run();
