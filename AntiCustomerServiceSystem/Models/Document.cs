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
    public partial class Document
    {
        public int Id { get; set; }
        public string URI { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Issue Issue { get; set; }
    }
    
}
