using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMapp.App.Models
{
    public class UserSetting
    {
        public string UserName { get; set; } = string.Empty;
        public string Group { get; set; }
        public int NotifyTimeMin { get; set; }

    }
}
