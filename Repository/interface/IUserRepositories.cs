using finance_manager.Model;

namespace finance_manager.Repository
{
    public interface IUserRepositories
    {
       public Task<Guid> AddUserToDatabase(User user);
    }
}
