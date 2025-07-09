namespace Softwash.Application.Commons;

public class StatusDTO
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
}
public class UserFavouriteDeleteDTO
{
    public long EntityId { get; set; }

    public long shopifyUserId { get; set; }
    public bool IsDeleted { get; set; }
}

public class StatusUpdateDTO   //for active in-active
{
    public long Id { get; set; }
    public bool IsActive { get; set; }
}
public class BlockDTO
{
    public long Id { get; set; }
    public bool IsBlocked { get; set; }
}
