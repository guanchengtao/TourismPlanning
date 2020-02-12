using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.IDAL
{
   public partial interface IDbSession
    {
        int Savechanges();
        Task<int> SaveChangesAsync();
    }
}
