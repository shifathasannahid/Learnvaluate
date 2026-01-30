using Microsoft.EntityFrameworkCore;
using LearnValuate.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21)) // Assuming MySQL 8
    ));

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Auto-migration / DB Fix
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        var connection = context.Database.GetDbConnection();
        connection.Open();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT COUNT(*) FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'users' AND COLUMN_NAME = 'role';";
        var result = Convert.ToInt64(command.ExecuteScalar());
        
        if (result == 0)
        {
            using var alterCommand = connection.CreateCommand();
            alterCommand.CommandText = "ALTER TABLE users ADD COLUMN role VARCHAR(20) DEFAULT 'Student';";
            alterCommand.ExecuteNonQuery();
        }
        
        using var checkEnrollments = connection.CreateCommand();
        checkEnrollments.CommandText = "SELECT COUNT(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'enrollments';";
        var hasEnrollments = Convert.ToInt64(checkEnrollments.ExecuteScalar());
        if (hasEnrollments == 0)
        {
            using var createEnrollments = connection.CreateCommand();
            createEnrollments.CommandText = @"
                CREATE TABLE enrollments (
                    enrollment_id INT AUTO_INCREMENT PRIMARY KEY,
                    user_id INT NOT NULL,
                    course_id INT NOT NULL,
                    enrollment_date DATETIME NOT NULL,
                    CONSTRAINT fk_enrollments_user FOREIGN KEY (user_id) REFERENCES users(id),
                    CONSTRAINT fk_enrollments_course FOREIGN KEY (course_id) REFERENCES courses(id)
                ) ENGINE=InnoDB;";
            createEnrollments.ExecuteNonQuery();
        }
        connection.Close();
    }
    catch (Exception ex)
    {
        // Log error or ignore if DB not accessible
        Console.WriteLine($"DB Fix Error: {ex.Message}");
    }
}

app.Run();
