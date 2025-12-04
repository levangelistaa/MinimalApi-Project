using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Database;

public class ContextDb : DbContext {

    private readonly IConfiguration _configurationAppSettings;
    public ContextDb(IConfiguration configurationAppSettings) {
        _configurationAppSettings = configurationAppSettings;
    }
    public DbSet<Admin> Administradores { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        var stringConexao = _configurationAppSettings.GetConnectionString("mysql")?.ToString();
        if (!optionsBuilder.IsConfigured) {
            if (!string.IsNullOrEmpty(stringConexao)) {
                optionsBuilder.UseMySql(
                    stringConexao,
                    ServerVersion.AutoDetect(stringConexao)
                );
            }
        }
    }
}