//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vnet.Api.Poc.Data.Entities.Jnl
{
    using System;
    using System.Collections.Generic;
    
    public partial class CartSaved
    {
        public int CartSavedID { get; set; }
        public int UserID { get; set; }
        public string SavedName { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ModDate { get; set; }
        public Nullable<System.DateTime> ExpiredOnDate { get; set; }
        public Nullable<System.DateTime> OrderedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
