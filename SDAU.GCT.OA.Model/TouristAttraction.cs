//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace SDAU.GCT.OA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TouristAttraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Introduce { get; set; }
        public string Location { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public Nullable<int> MessageCount { get; set; }
        public Nullable<System.DateTime> SubTime { get; set; }
        public string Remark { get; set; }
        public string Image { get; set; }
        public int DelFlag { get; set; }
    }
}
