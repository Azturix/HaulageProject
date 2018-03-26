using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HypCoreLibrary.Controller.Alpha
{
    /// <summary>
    /// Master controller of the system.
    /// </summary>
    public class Alpha60
    {


        public Alpha60()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
          
        }



    }

}
