using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDAU.GCT.OA.Model
{
    public class TouristPlanningDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public string Location { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string PlanLeader { get; set; }
        public string PlanUnit { get; set; }
        public string PlanTarget { get; set; }
        public string PlanYears { get; set; }
        public string PlanArea { get; set; }
        public int MessageCount { get; set; }
        public string SubTime { get; set; }
        public string Remark { get; set; }
        public string PlanImage { get; set; }
        public int DelFlag { get; set; }
        public int BrowseTime { get; set; }
    }
}
