using CallCenterRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace CallCenterRoles.Controllers
{
    [Authorize(Roles = "Agent")]
    public class AgentController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Agent
        public ActionResult Index()
        {
            ViewBag.UserMsg = "Call Succeeded";
            return View();
        }
        [HttpPost]
        public ActionResult InsuranceLead(string id)
        {
            int leadId = 0;
            string check = null;
            try
            {
                if (ModelState.IsValid)
                {
                    Lead data = new Lead

                    {
                        LeadTypesId = 1,
                        UserId = id
                    };
                    db.Leads.Add(data);
                    db.SaveChanges();
                    leadId = data.Id;

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            DataLead dataLead = new DataLead();
            //ViewBag.LeadId = data.Id;
            List<string> list = new List<string>();
            foreach (string item in Request.Form.Keys)
            {
                //ViewBag.Name = Request["gender"];
                list.Add(item);
            }
            int listCount = list.Count() - 2;
            for (int i = 0; i < listCount; i++)
            {
                if (i == 0)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Name";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 1)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Phone";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 2)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Email";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 3)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Age";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 4)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Income";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 5)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Address";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 6)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Gender";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if ((i > 6 && i % 2 != 0) && Request[list[i]] != "")
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = Request[list[i]];
                    check = Request[list[i]];
                }
                else if ((i > 6 && i % 2 == 0) && check != null)
                {
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }


            }

            return RedirectToAction("InsuranceLead");
        }
        [HttpPost]
        public ActionResult SeoLead(string id)
        {
            int leadId = 0;
            string check = null;
            try
            {
                if (ModelState.IsValid)
                {
                    Lead data = new Lead

                    {
                        LeadTypesId = 2,
                        UserId = id
                    };
                    db.Leads.Add(data);
                    db.SaveChanges();
                    leadId = data.Id;

                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            DataLead dataLead = new DataLead();
            //ViewBag.LeadId = data.Id;
            List<string> list = new List<string>();
            foreach (string item in Request.Form.Keys)
            {
                //ViewBag.Name = Request["gender"];
                list.Add(item);
            }
            int listCount = list.Count() - 2;
            for (int i = 0; i < listCount; i++)
            {
                if (i == 0)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Name";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 1)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Phone";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 2)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Email";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 3)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Website";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 4)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Url";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
                else if (i == 5)
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = "Keyword";
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }

                else if ((i > 5 && i % 2 == 0) && Request[list[i]] != "")
                {
                    dataLead.LeadId = leadId;
                    dataLead.FieldName = Request[list[i]];
                    check = Request[list[i]];
                }
                else if ((i > 5 && i % 2 != 0) && check != null)
                {
                    dataLead.FieldValue = Request[list[i]];
                    db.DataLeads.Add(dataLead);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("SeoLead");
        }

        public ActionResult SeoLead()
        {
            var agentId = User.Identity.GetUserId();
            List<MyLeadModel> model = new List<MyLeadModel>();
            var person = (from p in db.DataLeads
                          join e in db.Leads
                          on p.LeadId equals e.Id
                          where (e.UserId == agentId && e.LeadTypesId == 2)
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
        public ActionResult InsuranceLead()
        {
            
            var agentId = User.Identity.GetUserId();
            List<MyLeadModel> model = new List<MyLeadModel>();
            var person = (from p in db.DataLeads
                          join e in db.Leads
                          on p.LeadId equals e.Id
                          where (e.UserId == agentId && e.LeadTypesId == 1)
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
        public ActionResult DetailLead(int id)
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
    }
}