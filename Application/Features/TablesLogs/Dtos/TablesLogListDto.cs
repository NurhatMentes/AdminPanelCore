namespace Application.Features.TablesLogs.Dtos;

public class TablesLogListDto
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public int ItemId { get; set; }
    public string TableName { get; set; }
    public string ItemName { get; set; }
    public string Process { get; set; }
}