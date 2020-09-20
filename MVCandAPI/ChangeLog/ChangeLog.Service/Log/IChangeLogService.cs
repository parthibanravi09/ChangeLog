using ChangeLog.Model.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLog.Service.Log
{
    public interface IChangeLogService
    {
        public List<ChangeLogModel> Get();
        public void Add(ChangeLogModel changeLog);
        public void Update(ChangeLogModel changeLog);
        public void Delete(int id);
    }
}
