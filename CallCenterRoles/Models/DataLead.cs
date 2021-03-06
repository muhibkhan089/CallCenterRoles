﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CallCenterRoles.Models
{
    [Table("DataLeads")]
    public class DataLead
    {
        [Key]
        public int Id { get; set; }
        
        public int LeadId { get; set; }
        [ForeignKey("LeadId")]
        public virtual Lead Lead { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

    }
    public class MyLeadModel
    {
        public int dataLeadId { get; set; }
        public string dataFieldName { get; set; }
        public string dataFieldValue { get; set; }
    }
}