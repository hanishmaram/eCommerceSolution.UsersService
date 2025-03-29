using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public Task<ApplicationUser> AddUser(ApplicationUser user)
    {
        user.UserID = Guid.NewGuid();

        return Task.FromResult(user);
    }

    public Task<ApplicationUser> GetUserByEmailAndPassword(string email, string password)
    {
        return Task.FromResult(
         new ApplicationUser
         {
             UserID = Guid.NewGuid(),
             Email = email,
             Password = password,
             PersonName = "Person Name",
             Gender = GenderOptions.Male.ToString()
         });
    }
}
