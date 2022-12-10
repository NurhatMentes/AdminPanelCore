using Core.Persistence.Repositories;

namespace Domain.Entities;

public class TablesLog : Entity
{
    public int? UserId { get; set; }
    public int ItemId { get; set; }
    public string TableName { get; set; }
    public string ItemName { get; set; }
    public string Process { get; set; }

    public virtual ExtendedUser User { get; set; }

    public TablesLog(int id, DateTime creationTime, int? userId, int itemId, string tableName, string itemName, string process) : base(id, creationTime)
    {
        UserId = userId;
        ItemId = itemId;
        TableName = tableName;
        ItemName = itemName;
        Process = process;
    }

    public TablesLog()
    {
        
    }

}