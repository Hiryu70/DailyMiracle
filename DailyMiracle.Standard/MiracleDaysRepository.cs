using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DailyMiracle.Standard
{
    public class MiracleDaysRepository : IMiracleDaysRepository
    {
        private readonly DatabaseContext _databaseContext;

        public MiracleDaysRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<IEnumerable<MiracleDay>> GetMiracleDaysAsync()
        {
            try
            {
                var miracleDays = await _databaseContext.MiracleDays.ToListAsync();
                return miracleDays;
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }

        public async Task<MiracleDay> GetMiracleDayByIdAsync(int id)
        {
            try
            {
                var miracleDay = await _databaseContext.MiracleDays.FindAsync(id);
                return miracleDay;
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }

        public async Task<bool> AddMiracleDayAsync(MiracleDay miracleDay)
        {
            try
            {
                var tracking = await _databaseContext.MiracleDays.AddAsync(miracleDay);
                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == EntityState.Added;
                return isAdded;
            }
            catch (Exception e)
            {

                LogError(e);
                return false;
            }
        }

        public async Task<bool> UpdateMiracleDayAsync(MiracleDay miracleDay)
        {
            try
            {
                var tracking = _databaseContext.Update(miracleDay);
                await _databaseContext.SaveChangesAsync();
                var isAdded = tracking.State == EntityState.Modified;
                return isAdded;
            }
            catch (Exception e)
            {
                LogError(e);
                return false;
            }
        }

        public async Task<bool> RemoveMiracleDayAsync(int id)
        {
            try
            {
                var miracleDay = await _databaseContext.MiracleDays.FindAsync(id);
                var tracking = _databaseContext.Remove(miracleDay);
                await _databaseContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }
            catch (Exception e)
            {
                LogError(e);
                return false;
            }
        }

        public async Task<IEnumerable<MiracleDay>> QueryMiracleDaysAsync(Func<MiracleDay, bool> predicate)
        {
            try
            {
                var miracleDays = _databaseContext.MiracleDays.Where(predicate);
                return miracleDays.ToList();
            }
            catch (Exception e)
            {
                LogError(e);
                return null;
            }
        }

        private static void LogError(Exception e)
        {
            string message = e.Message;
            if (e.InnerException != null)
            {
                message = $"{message}. InnerException: {e.InnerException.Message}";
            }
            Console.WriteLine(message);
        }
    }
}
