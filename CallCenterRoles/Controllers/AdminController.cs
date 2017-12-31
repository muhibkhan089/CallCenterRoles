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
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
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
            string[] roles = System.Web.Security.Roles.GetRolesForUser(User.Identity.Name);
            return View();
        }
        public ActionResult ViewAgents()
        {
            
            return View();
        }
        public ActionResult ViewLeads()
        {
            return View();
        }
        public ActionResult AddLeads()
        {
            return View();
        }
    }
}