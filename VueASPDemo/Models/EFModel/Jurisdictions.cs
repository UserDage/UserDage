//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace VueASPDemo.Models.EFModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Jurisdictions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jurisdictions()
        {
            this.JurisdicDuty = new HashSet<JurisdicDuty>();
        }
    
        public int JurID { get; set; }
        public string JurName { get; set; }
        public string JurValue { get; set; }
        public Nullable<int> JurState { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JurisdicDuty> JurisdicDuty { get; set; }
    }
}
