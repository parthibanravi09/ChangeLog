using ChangeLog.Model.Log;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChangeLog.Models
{
    public class HomeViewModel
    {
        public string PageHeader { get; set; }
        public List<ChangeLogModel> ChangeLogModels { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }
    }
}
