//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CLDVPOEPART3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car_Returns
    {
        public string CarNo { get; set; }
        public string Inspector_Name { get; set; }
        public string Driver_Name { get; set; }
        public System.DateTime End_Date { get; set; }
        public int Elapsed_Date { get; set; }
        public int Fine { get; set; }
        public int RentalID { get; set; }
    
        public virtual Car Car { get; set; }
    }
}
