using ProjectManagement.Domain.Entities;

namespace Softwash.Domain.Entities;

public class User : AuditDeleteableEntity
{
    public string? FirstName { get; set; }
    public long? ShopifyUserId { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Image { get; set; }
    public Login? Login { get; set; }

    public ICollection<Project> Projects { get; set; } = new List<Project>();

}
