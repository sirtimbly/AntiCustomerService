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

namespace ServiceBlazerMVC4.Models
{
    public partial class Issue
    {
        public Issue()
        {
            this.Companies = new HashSet<Company>();
            this.Calls = new HashSet<Call>();
            this.Documents = new HashSet<Document>();
        }
    
        public int Id { get; set; }
        public System.DateTime Opened { get; set; }
        public Nullable<System.DateTime> Closed { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Resolution { get; set; }
        public Nullable<short> Outcome { get; set; }
    
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Call> Calls { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
    
}
