using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLog.Data
{
    public class UserRole
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
