using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TPASTATUSCODE.BussLayer
{
    public class Responce
    {
        public string strErrorCode { get; set; }
        public string strErrorStatus { get; set; }

        public static void Clear()
        {
            throw new NotImplementedException();
        }
    }
}