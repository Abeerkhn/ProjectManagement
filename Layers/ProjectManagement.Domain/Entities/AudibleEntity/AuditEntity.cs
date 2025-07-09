namespace Softwash.Domain.Entities.AudibleEntity;

public class AuditEntity : IAuditEntity, IBaseEntity
{
    public long Id { get; set; }
    public DateTime? CreatedDate { get; set; }
    public long? CreatedById { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedById { get; set; }
}
