using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenterRoles.Models
{
    [Table("LeadTypes")]
    public class LeadType
    {
        [Key]
        public string Id { get; set; }
        [StringLength(128)]
        public string Name { get; set; }
    }
}