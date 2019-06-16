using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DailyMiracle
{
    public interface IMiracleDaysRepository
    {
        Task<IEnumerable<MiracleDay>> GetMiracleDaysAsync();

        Task<MiracleDay> GetMiracleDayByIdAsync(int id);

        Task<bool> AddMiracleDayAsync(MiracleDay miracleDay);

        Task<bool> UpdateMiracleDayAsync(MiracleDay miracleDay);

        Task<bool> RemoveMiracleDayAsync(int id);

        Task<IEnumerable<MiracleDay>> QueryMiracleDaysAsync(Func<MiracleDay, bool> predicate);
    } 
}