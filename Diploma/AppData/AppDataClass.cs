using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.AppData
{
    class AppDataClass
    {

        public static Entities context = new Entities();

        public static int VarCheckRole { get; set; }

        public static int VarId { get; set; }
    }
}
