using ChangeLog.Data;
using ChangeLog.Model.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChangeLog.Service.Log
{
    public class ChangeLogService : IChangeLogService
    {
        private readonly ChangeLogDbContext dbContext;

        public ChangeLogService()
        {
            dbContext = new ChangeLogDbContext();
        }

        public void Add(ChangeLogModel changeLog)
        {
            var changeLogData = new ChangeLogs()
            {
                Content = changeLog.Content,
                Title = changeLog.Title,
                Type = changeLog.Type,
                IsDeleted = false,
                LastUpdated = DateTime.UtcNow
            };

            dbContext.ChangeLogs.Add(changeLogData);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var chnageLog = dbContext.ChangeLogs.Where(log => log.Id == id).FirstOrDefault();
            chnageLog.IsDeleted = true;
            chnageLog.LastUpdated = DateTime.UtcNow;
            dbContext.ChangeLogs.Update(chnageLog);
            dbContext.SaveChanges();
        }

        public List<ChangeLogModel> Get()
        {
            List<ChangeLogModel> list = new List<ChangeLogModel>();
            int iIdx = 1;
            foreach ( var changeLog in dbContext.ChangeLogs.Where(log=> log.IsDeleted == false).ToList())
            {
                list.Add(new ChangeLogModel() {
                    No = iIdx++,
                    Id = changeLog.Id,
                    Content = changeLog.Content,
                    Title = changeLog.Title,
                    Type = changeLog.Type,
                    Updated = changeLog.LastUpdated
                });
            }

            return list;
        }

        public void Update(ChangeLogModel changeLog)
        {
            var changeLogData = new ChangeLogs()
            {
                Content = changeLog.Content,
                Title = changeLog.Title,
                Type = changeLog.Type,
                LastUpdated = DateTime.UtcNow,
                Id = changeLog.Id,
            };

            dbContext.ChangeLogs.Update(changeLogData);
            dbContext.SaveChanges();
        }
    }
}
