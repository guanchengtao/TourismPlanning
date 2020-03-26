using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.Model
{
    public class PublicInformationDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public string SubTime { get; set; }
        public string SubUnit { get; set; }
        public int BrowseTime { get; set; }
        public string Author { get; set; }
        public string Remark { get; set; }
    }
}
