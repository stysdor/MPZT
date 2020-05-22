using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPZT.Infrustructure.Communication
{
    public class ServiceResponce
    {
        public bool Success { get; set; }
        public string Errors { get; set; }

        public ServiceResponce()
        {
            Success = true;
        }
    }
}
