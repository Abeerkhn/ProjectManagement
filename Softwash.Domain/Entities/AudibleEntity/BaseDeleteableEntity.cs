namespace Softwash.Domain.Entities.AudibleEntity;

public class BaseDeleteableEntity : IBaseEntity, IDeleteableEntity
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
}
