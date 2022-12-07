using Core.Persistence.Repositories;

namespace Domain.Entities;

public class TablesLog : Entity
{
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public string TableName { get; set; }
    public string ItemName { get; set; }
    public string Process { get; set; }
    public DateTime LogDate { get; set; }

    public virtual ExtendedUser User { get; set; }
}