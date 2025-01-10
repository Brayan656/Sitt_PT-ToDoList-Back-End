using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ToDoList.Models.DB
{
    public class ToDoContext : DbContext
    {
        private readonly string _connectionString;

        public ToDoContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString, sqliteOptionsAction: x =>
            {
                x.MigrationsAssembly(Assembly.GetAssembly(typeof(ToDoContext)).FullName);
            });
        }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Modern_Spanish_CI_AI");

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.ToTable("Tareas");

                entity.HasKey(e => e.IdTarea);
                entity.Property(e => e.IdTarea).ValueGeneratedOnAdd();
                
                entity.Property(e=>e.Titulo).IsRequired();
                
                entity.Property(e => e.FechaCreacion)
               .HasDefaultValueSql("(getdate())")
               .HasColumnType("datetime");

                

            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estados");

                entity.HasKey(e => e.IdEstado);
                entity.Property(e => e.IdEstado).ValueGeneratedOnAdd();

                entity.Property(e => e.estado).IsUnicode(false);
            });

        }

    }
}
