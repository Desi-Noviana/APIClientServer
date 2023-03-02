using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Principal;

namespace API.Contexts;

public class MyContexts : DbContext
{
    public MyContexts(DbContextOptions<MyContexts> options) : base(options)
    {
    }

    // Introduce the model to the database that eventually become an entity
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Profilling> Profilings { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<University> Universities { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //Cara untuk menambahkan data role secara default
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin"
            },
            new Role
            {
                Id = 2,
                Name = "User"
            });

        // Membuat atribute menjadi unique
        modelBuilder.Entity<Employee>().HasIndex(e => new
        {
            e.Email,
            e.PhoneNumber
        }).IsUnique();

        // Relasi one Employee ke one Account 
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Account)
            .WithOne(a => a.Employee)
            .HasForeignKey<Account>(fk => fk.EmployeeNIK);

        // Relasi ke many employee ke one manager
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager) 
            .WithMany(e => e.Employees)
            .HasForeignKey(fk => fk.ManagerId)//karena kediri sendiri jadi tidak memerlukan type <Employee>
            .OnDelete(DeleteBehavior.NoAction);
            
    }
}
