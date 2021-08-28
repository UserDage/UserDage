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
    
    public partial class Lets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lets()
        {
            this.PayInfo = new HashSet<PayInfo>();
            this.Repair = new HashSet<Repair>();
        }
    
        public int LetID { get; set; }
        public Nullable<int> HID { get; set; }
        public Nullable<int> CusID { get; set; }
        public Nullable<int> EmpID { get; set; }
        public Nullable<System.DateTime> LetBeginDate { get; set; }
        public Nullable<System.DateTime> ExpectEndDate { get; set; }
        public Nullable<System.DateTime> LetEndDate { get; set; }
        public Nullable<decimal> LetRent { get; set; }
        public Nullable<decimal> LetNet { get; set; }
        public Nullable<decimal> BeginElectric { get; set; }
        public Nullable<decimal> BeginWater { get; set; }
        public Nullable<decimal> EndElectric { get; set; }
        public Nullable<decimal> EndWater { get; set; }
        public Nullable<decimal> EndMoney { get; set; }
        public Nullable<System.DateTime> CurrentNetDate { get; set; }
        public Nullable<System.DateTime> CurrentRentDate { get; set; }
        public Nullable<int> CreateEmp { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> LetState { get; set; }
        public string LetMark { get; set; }
        public Nullable<decimal> LetElectric { get; set; }
        public Nullable<decimal> LetWater { get; set; }
    
        public virtual Customers Customers { get; set; }
        public virtual Employs Employs { get; set; }
        public virtual HouseInfo HouseInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayInfo> PayInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Repair> Repair { get; set; }
    }
}
