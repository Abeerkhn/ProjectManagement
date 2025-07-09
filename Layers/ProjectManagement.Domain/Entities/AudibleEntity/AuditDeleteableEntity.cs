namespace Softwash.Domain.Entities.AudibleEntity;

public class AuditDeleteableEntity : AuditEntity, IDeleteableEntity
{
    public bool IsDeleted { get; set; }
}
