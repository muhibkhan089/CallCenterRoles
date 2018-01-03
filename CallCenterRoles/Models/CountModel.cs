using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CallCenterRoles.Models
{
    public class CountModel
    {
        public int totalLeads { get; set; }
        public int totalUsers { get; set; }
        public int totalAgents { get; set; }
        public int totalClients { get; set; }
        public int seoLeads { get; set; }
        public int insuranceLeads { get; set; }
    }
}