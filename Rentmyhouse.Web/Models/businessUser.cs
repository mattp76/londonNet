//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rentmyhouse.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class businessUser
    {
        public long id { get; set; }
        public string strBusinessUsername { get; set; }
        public string strBusinessPassword { get; set; }
        public string strBusinessEmail { get; set; }
        public Nullable<System.DateTime> strDate { get; set; }
        public string strStatus { get; set; }
        public Nullable<System.DateTime> strLast { get; set; }
        public string strIso { get; set; }
        public string strCountry { get; set; }
    }
}