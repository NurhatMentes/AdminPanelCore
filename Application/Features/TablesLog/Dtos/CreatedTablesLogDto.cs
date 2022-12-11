﻿namespace Application.Features.TablesLog.Dtos
{
    public class CreatedTablesLogDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int ItemId { get; set; }
        public string TableName { get; set; }
        public string ItemName { get; set; }
        public string Process { get; set; }
    }
}
