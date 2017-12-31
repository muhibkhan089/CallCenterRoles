using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenterRoles.Models
{
    [Table("Leads")]
    public class Lead
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public string LeadTypesId { get; set; }
        [ForeignKey("LeadTypesId")]
        public virtual LeadType LeadType { get; set; }

    }
}