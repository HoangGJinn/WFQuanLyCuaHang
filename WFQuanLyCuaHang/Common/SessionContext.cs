using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFQuanLyCuaHang.Common
{
    public static class SessionContext
    {
        public static string ConnectionString { get; set; }
        public static string CurrentUsername { get; set; }
        public static string CurrentUserType { get; set; }
    }

}
