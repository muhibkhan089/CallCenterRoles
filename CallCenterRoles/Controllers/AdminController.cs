using CallCenterRoles.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallCenterRoles.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {
            CountModel model = new CountModel()
            
            {
                totalUsers = db.Users.Count(),
                totalClients = db.Users.Where(u =>
            u.Roles.Join(db.Roles, usrRole => usrRole.RoleId,
            role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("User"))).Count(),
                totalAgents = db.Users.Where(u =>
            u.Roles.Join(db.Roles, usrRole => usrRole.RoleId,
            role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("Agent"))).Count(),
                insuranceLeads = db.Leads.Count(a => a.LeadTypesId == 1),
                seoLeads = db.Leads.Count(a => a.LeadTypesId == 2),
                totalLeads=db.Leads.Count()
            };
            
            return View(model);
        }
        public ActionResult ViewUsers()
        {
            var usersInRole = db.Users.Where(u =>
            u.Roles.Join(db.Roles, usrRole => usrRole.RoleId,
            role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("User"))).ToList();

            return View(usersInRole);
        }
        public ActionResult ViewAgents()
        {
            var usersInRole = db.Users.Where(u =>
            u.Roles.Join(db.Roles, usrRole => usrRole.RoleId,
            role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("Agent"))).ToList();
            return View(usersInRole);
        }
        public ActionResult ViewLeads(int id)
        {
            List<MyLeadModel> model = new List<MyLeadModel>();
            var person = (from p in db.DataLeads
                          where (p.LeadId == id)
                          select new
                          {
                              dataFieldId = p.LeadId,
                              dataFieldName = p.FieldName,
                              dataFieldValue = p.FieldValue
                          }).ToList();
            foreach (var item in person)
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
        public ActionResult AddLeads()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            var data = db.Users.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(ApplicationUser user)
        {
            var record = db.Users.SingleOrDefault(m => m.Id == user.Id);
            record.FullName = user.FullName;
            record.Email = user.Email;
            record.UserName = user.UserName;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var data = db.Users.SingleOrDefault(m => m.Id == id);
            db.Users.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult InsuranceLead(string id)
        {
            ViewBag.Id = id;
            //var agentId = User.Identity.GetUserId();
            List<MyLeadModel> model = new List<MyLeadModel>();
            var person = (from p in db.DataLeads
                          join e in db.Leads
                          on p.LeadId equals e.Id
                          where (e.LeadTypesId == 1)
                          select new
                          {
                              dataFieldId = p.LeadId,
                              dataFieldName = p.FieldName,
                              dataFieldValue = p.FieldValue
                          }).ToList();

            bool check = true;
            foreach (var item in person)
            {
                if (check)
                    ViewBag.count = item.dataFieldId;
                model.Add(new MyLeadModel()
                {
                    dataLeadId = item.dataFieldId,
                    dataFieldName = item.dataFieldName,
                    dataFieldValue = item.dataFieldValue
                });
                check = false;
            }
            return View(model);
        }
        public ActionResult SeoLead(string id)
        {
            ViewBag.Id = id;
            List<MyLeadModel> model = new List<MyLeadModel>();
            var person = (from p in db.DataLeads
                          join e in db.Leads
                          on p.LeadId equals e.Id
                          where (e.LeadTypesId == 2)
                          select new
                          {
                              dataFieldId = p.LeadId,
                              dataFieldName = p.FieldName,
                              dataFieldValue = p.FieldValue
                          }).ToList();

            bool check = true;
            foreach (var item in person)
            {
                if (check)
                    ViewBag.count = item.dataFieldId;
                model.Add(new MyLeadModel()
                {
                    dataLeadId = item.dataFieldId,
                    dataFieldName = item.dataFieldName,
                    dataFieldValue = item.dataFieldValue
                });
                check = false;
            }
            return View(model);
        }
        public ActionResult AssignLead()
        {
            var usersInRole = db.Users.Where(u =>
            u.Roles.Join(db.Roles, usrRole => usrRole.RoleId,
            role => role.Id, (usrRole, role) => role).Any(r => r.Name.Equals("User"))).ToList();
            return View(usersInRole);
        }
        public ActionResult AssignLeadToUser(int id, string userId)
        {
            var role = new UserLead() { LeadId = id,UserId=userId };
            db.UserLeads.Add(role);
            db.SaveChanges();
            return RedirectToAction("AssignLead");
        }
        public ActionResult EditLead(int leadId)
        {

            List<MyLeadModel> model = new List<MyLeadModel>();
            var person = (from p in db.DataLeads
                          where (p.LeadId == leadId)
                          select new
                          {
                              dataFieldId = p.LeadId,
                              dataFieldName = p.FieldName,
                              dataFieldValue = p.FieldValue
                          }).ToList();
            foreach (var item in person)
            {
                
                model.Add(new MyLeadModel()
                {
                    dataLeadId = item.dataFieldId,
                    dataFieldName = item.dataFieldName,
                    dataFieldValue = item.dataFieldValue
                });
            }
            ViewBag.LeadId = leadId;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateLead()
        {
            int leadId = int.Parse(Request["LeadId"]);
            DataLead model = new DataLead();
            List<string> list = new List<string>();
            foreach (string item in Request.Form.Keys)
            {
                list.Add(item);
            }
            
            
            return RedirectToAction("Index");
        }
        public ActionResult DeleteLead(int id)
        {
            //db.DataLeads.Remove(db.DataLeads.Find(id));

            return RedirectToAction("Index");
        }
    }
}