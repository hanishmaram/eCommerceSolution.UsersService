using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;

namespace eCommerce.Core.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentException(nameof(userRepository));

    public async Task<AuthenticationResponse> Login(LoginRequest loginRequest)
    {
        var applicationUser = await _userRepository.GetUserByEmailAndPassword(loginRequest.Email
                                    , loginRequest.Password) ?? throw new Exception("User not Found");

        return new AuthenticationResponse(applicationUser.UserID
            , applicationUser.Email
            , applicationUser.PersonName
            , applicationUser.Gender
            , "Token"
            , true
            );
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest registerRequest)
    {
        var applicationUser = new ApplicationUser { 
            Email = registerRequest.Email,
            Gender = registerRequest.Gender.ToString(),
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName
        };
        
        var createdUser =  await _userRepository.AddUser(applicationUser) ?? throw new Exception("Unable to create user");

        return new AuthenticationResponse(createdUser.UserID
            , createdUser.Email
            , createdUser.PersonName
            , createdUser.Gender
            , "Token"
            , true);
    }
}
