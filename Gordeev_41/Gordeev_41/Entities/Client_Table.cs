//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gordeev_41.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client_Table
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientSecondName { get; set; }
        public string ClientThirdName { get; set; }
        public string ClientAddress { get; set; }
        public string ClientNumber { get; set; }
        public System.DateTime ClientDateOfBirth { get; set; }
        public int RoleId { get; set; }
        public string ClientLogin { get; set; }
        public string ClientPassword { get; set; }
    
        public virtual Role Role { get; set; }
    }
}