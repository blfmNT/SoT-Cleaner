using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HWID_Changer
{
    internal class Utils
    {
        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                      .IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static char GetSystemDrive()
        {
            return Path.GetPathRoot(Environment.SystemDirectory)[0];
        }
    }
}
