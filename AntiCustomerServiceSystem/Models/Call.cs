//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace AntiCustomerServiceSystem.Models
{
    public partial class Call
    {
        public Call()
        {
            this.FollowUps = new HashSet<FollowUp>();
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public string ServiceRep { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string Promises { get; set; }
        public string Resolution { get; set; }
    
        public virtual Issue Issue { get; set; }
        public virtual ICollection<FollowUp> FollowUps { get; set; }
    }
    
}
