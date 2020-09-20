using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLog.Data
{
    public class ChangeLogs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
