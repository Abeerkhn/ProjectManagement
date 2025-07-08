namespace Softwash.Domain.Entities.AuditEntity;

public interface IDeleteableEntity
{
    public bool IsDeleted { get; set; }
}
