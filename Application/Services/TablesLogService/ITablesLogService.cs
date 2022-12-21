namespace Application.Services.TablesLogService
{
    public interface ITablesLogService
    {
        public Task<string> CreateTablesLog(int userId, int itemId, string tableName, string itemName);
        public Task<string> UpdateTablesLog(int userId, int itemId, string tableName, string itemName);
    }
}
