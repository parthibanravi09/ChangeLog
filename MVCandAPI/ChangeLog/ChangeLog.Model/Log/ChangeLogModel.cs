using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeLog.Model.Log
{
    public class ChangeLogModel
    {
        public int No { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Updated { get; set; }
    }
}
