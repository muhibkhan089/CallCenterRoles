using CallCenterRoles.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCenterRoles.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        // GET: User
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            List<MyLeadModel> model = new List<MyLeadModel>();
            var lead = (from p in db.DataLeads
                          join e in db.UserLeads
                          on p.LeadId equals e.LeadId
                          where (e.UserId == userId )
                          select new
                          {
                              dataFieldId = p.LeadId,
                              dataFieldName = p.FieldName,
                              dataFieldValue = p.FieldValue
                          }).ToList();

            foreach (var item in lead)
            {
                model.Add(new MyLeadModel()
                {
                    dataLeadId = item.dataFieldId,
                    dataFieldName = item.dataFieldName,
                    dataFieldValue = item.dataFieldValue
                });
            }
            return View(model);
        }
    }
}