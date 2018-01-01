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
            return View();
        }
        public ActionResult ViewProject()
        {
            return View();
        }
        public ActionResult AddProject()
        {
            return View();
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
        public ActionResult ViewLeads()
        {
            return View();
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
    }
}