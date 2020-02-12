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
    
    public partial class PlantInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlantInfo()
        {
            this.PlantImage = new HashSet<PlantImage>();
            this.UserComment = new HashSet<UserComment>();
        }
    
        public int Id { get; set; }
        public string PlantName { get; set; }
        public string PlantDetail { get; set; }
        public string JingDu { get; set; }
        public string WeiDu { get; set; }
        public string Xiaoqu { get; set; }
        public System.DateTime SubTime { get; set; }
        public int DelFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlantImage> PlantImage { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserComment> UserComment { get; set; }
    }
}
