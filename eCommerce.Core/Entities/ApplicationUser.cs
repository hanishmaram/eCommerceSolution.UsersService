
namespace eCommerce.Core.Entities;

public class ApplicationUser
{
    public Guid UserID { get; set; }
    public required string Email{ get; set; }
    public required string Password { get; set; }
    public required string PersonName { get; set; }
    public required string Gender { get; set; }
}
