using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Domain.Entities;

public partial class TablesLog : Entity
{
    public int TablesLogsId { get; set; }
    public int UserId { get; set; }
    public int ItemId { get; set; }
    public string TableName { get; set; }
    public string ItemName { get; set; }
    public string Process { get; set; }
    public System.DateTime LogDate { get; set; }

    public virtual ExtendedUser Users { get; set; }
}