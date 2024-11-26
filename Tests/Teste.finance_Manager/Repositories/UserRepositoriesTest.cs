using finance_manager.Data;
using finance_manager.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace finance_manager.Tests.Teste.finance_Manager.Repositories
{
    public class UserRepositoriesTest
    {
         private async Task<AppDbContext> GetInMemoryDbContext()
         {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                     .UseInMemoryDatabase("TestDatabase")
                     .Options;

                var context = new AppDbContext(options);
                var InsertUserAsync = new User
                {
                    Email = "test@mail.com",
                    Name = "test",
                    Password = "test",
                };
                context.Users.Add(InsertUserAsync);

                await context.SaveChangesAsync();
                return context;
         }
        [Fact]
        public async Task CanAddUserToDatabase() 
        {
            
            var context = await GetInMemoryDbContext();

            var user = await context.Users.AddAsync(
                new User 
                { 
                    Email = "test@mail.com", 
                    Name="test", 
                    Password="testPassword"
                }
            );
            var addedUser = await context.Users.FindAsync(user.Entity.Id);
            
            Assert.NotNull(addedUser);
            Assert.Equal(addedUser.Name, user.Entity.Name);

        }
    }
}
