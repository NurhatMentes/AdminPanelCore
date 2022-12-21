using Domain.Entities;
using Application.Services.Repositories;
using AutoMapper;
using Application.Features.TablesLogs.Dtos;

namespace Application.Services.TablesLogService
{
    public class TablesLogManager: ITablesLogService
    {
       private readonly ITablesLogRepository _logRepository;
       private readonly IUserRepository _userRepository;
       private readonly IMapper _mapper;

        public TablesLogManager(ITablesLogRepository logRepository, IMapper mapper, IUserRepository userRepository)
        {
            _logRepository = logRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<string> CreateTablesLog(int userId, int itemId, string tableName, string itemName)
        {
            var userName = _userRepository.Get(u => u.Id == userId);
            TablesLog tablesLog = new TablesLog()
            {
                UserId = userId,
                ItemId = itemId,
                TableName = tableName,
                ItemName = itemName,
                Process = "'" + itemName + "' " + userName.FirstName + " " + userName.LastName + " " + "tarafından eklendi."
            };

            TablesLog created = await _logRepository.AddAsync(tablesLog);
            CreatedTablesLogDto createdDto = _mapper.Map<CreatedTablesLogDto>(created);
            return "";
        }

        public async Task<string> UpdateTablesLog(int userId, int itemId, string tableName, string itemName)
        {
            var userName = _userRepository.Get(u => u.Id == userId);
            TablesLog tablesLog = new TablesLog()
            {
                UserId = userId,
                ItemId = itemId,
                TableName = tableName,
                ItemName = itemName,
                Process = "'" + itemName + "' " + userName.FirstName + " " + userName.LastName + " " + "tarafından Güncellendi."
            };

            TablesLog created = await _logRepository.AddAsync(tablesLog);
            CreatedTablesLogDto createdDto = _mapper.Map<CreatedTablesLogDto>(created);
            return "";
        }
    }
}
