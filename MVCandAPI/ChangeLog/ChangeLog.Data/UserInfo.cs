using System;
using System.Collections.Generic;
using System.Text;

namespace ChangeLog.Data
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
