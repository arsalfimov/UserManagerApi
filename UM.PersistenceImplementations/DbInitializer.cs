using Microsoft.EntityFrameworkCore;
using UM.Domain;

namespace UM.PersistenceImplementations;
public static class DbInitializer
{
    public static void Initialize(ApplicationDbContext context)
    {
        context.Database.Migrate();

        if (!context.Users.Any())
        {
            var usersToAdd = new List<User>
            {
                new User { Id = Guid.NewGuid(), Name = "John", Age = 30, Email = "john@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Admin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Alice", Age = 25, Email = "alice@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.User }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Bob", Age = 28, Email = "bob@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Emma", Age = 22, Email = "emma@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Admin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "David", Age = 35, Email = "david@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.SuperAdmin },
                        new Role { Name = UserRole.Admin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Ella", Age = 29, Email = "ella@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Michael", Age = 31, Email = "michael@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Olivia", Age = 27, Email = "olivia@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "William", Age = 32, Email = "william@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Sophia", Age = 26, Email = "sophia@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "James", Age = 29, Email = "james@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Ava", Age = 33, Email = "ava@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Benjamin", Age = 28, Email = "benjamin@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Mia", Age = 30, Email = "mia@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.Support }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Ethan", Age = 24, Email = "ethan@example.com",
                    Roles = new List <Role>
                    {
                        new Role { Name = UserRole.User }
                    }},
                new User { Id = Guid.NewGuid(), Name = "Charlotte", Age = 27, Email = "charlotte@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.SuperAdmin },
                        new Role { Name = UserRole.Admin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Daniel", Age = 35, Email = "daniel@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Liam", Age = 31, Email = "liam@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.Admin },
                    } },
                new User { Id = Guid.NewGuid(), Name = "Grace", Age = 28, Email = "grace@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Oliver", Age = 26, Email = "oliver@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Admin }

                    } },
                new User { Id = Guid.NewGuid(), Name = "Evelyn", Age = 29, Email = "evelyn@example.com" },
                new User { Id = Guid.NewGuid(), Name = "Alexander", Age = 34, Email = "alexander@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Amelia", Age = 30, Email = "amelia@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.Admin },
                    } },
                new User { Id = Guid.NewGuid(), Name = "Henry", Age = 25, Email = "henry@example.com" },
                new User { Id = Guid.NewGuid(), Name = "Abigail", Age = 28, Email = "abigail@example.com" ,
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support },
                    } },
                new User { Id = Guid.NewGuid(), Name = "Sebastian", Age = 31, Email = "sebastian@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Aria", Age = 24, Email = "aria@example.com" },
                new User { Id = Guid.NewGuid(), Name = "Lucas", Age = 29, Email = "lucas@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Support },
                    } },
                new User { Id = Guid.NewGuid(), Name = "Scarlett", Age = 33, Email = "scarlett@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "Jack", Age = 28, Email = "jack@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                    } },
                new User { Id = Guid.NewGuid(), Name = "Luna", Age = 30, Email = "luna@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.Admin },
                    } },
                new User { Id = Guid.NewGuid(), Name = "Michael", Age = 27, Email = "michael@example.com" },
                new User { Id = Guid.NewGuid(), Name = "Nora", Age = 35, Email = "nora@example.com",
                    Roles = new List<Role>
                    {
                        new Role { Name = UserRole.User },
                        new Role { Name = UserRole.Support },
                        new Role { Name = UserRole.Admin },
                        new Role { Name = UserRole.SuperAdmin }
                    } },
                new User { Id = Guid.NewGuid(), Name = "William", Age = 32, Email = "william@example.com" }
            };

            context.Users.AddRange(usersToAdd);
            context.SaveChanges();
        }
    }
}