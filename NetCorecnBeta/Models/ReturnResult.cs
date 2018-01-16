using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCorecnBeta.Models
{
    public class ReturnResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public string DownLoadUrl { get; set; }

        public string Version { get; set; }
    }
}
