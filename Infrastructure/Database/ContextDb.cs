using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;
using MinimalAPI.Domain.Entities;

namespace MinimalApi.Infrastructure.Database;

public class ContextDb : DbContext {

    private readonly IConfiguration _configurationAppSettings;
    public ContextDb(IConfiguration configurationAppSettings) {
        _configurationAppSettings = configurationAppSettings;
    }
    public DbSet<Admin> Administradores { get; set; } = default!;

    public DbSet<Vehicle> Veiculos { get; set; } = default!;

    //Método para criação de um Administrador inicial
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Admin>().HasData(
            new Admin {
                Id = 1,
                Email = "administrador@gmail.com",
                Senha = "123456",
                Perfil = "Admin"
            }
            );
    }

    //Configurando a conexão com o banco de dados da minha máquina local
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