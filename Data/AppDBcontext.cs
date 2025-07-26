using Microsoft.EntityFrameworkCore;
using AppCrud.Models;

namespace AppCrud.Data
{
    public class AppDBcontext : DbContext
    {
        public AppDBcontext(DbContextOptions<AppDBcontext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para la entidad Empleado
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.FechaContratacion)
                    .IsRequired();

                entity.Property(e => e.Activo)
                    .HasDefaultValue(true);

                // Índice único para el email
                entity.HasIndex(e => e.Email)
                    .IsUnique();
            });

            // Datos iniciales (opcional)
            modelBuilder.Entity<Empleado>().HasData(
                new Empleado
                {
                    Id = 1,
                    Nombre = "Juan",
                    Apellido = "Pérez",
                    Email = "juan.perez@empresa.com",
                    Telefono = "987654321",
                    Cargo = "Desarrollador",
                    Salario = 3500.00m,
                    FechaContratacion = new DateTime(2023, 1, 15),
                    Activo = true
                },
                new Empleado
                {
                    Id = 2,
                    Nombre = "María",
                    Apellido = "García",
                    Email = "maria.garcia@empresa.com",
                    Telefono = "987654322",
                    Cargo = "Analista",
                    Salario = 3000.00m,
                    FechaContratacion = new DateTime(2023, 3, 10),
                    Activo = true
                }
            );
        }
    }
}