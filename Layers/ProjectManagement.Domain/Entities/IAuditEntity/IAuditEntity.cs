namespace Softwash.Domain.Entities.AuditEntity;

public interface IAuditEntity
{
    public DateTime? CreatedDate { get; set; }
    public long? CreatedById { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifiedById { get; set; }

}
