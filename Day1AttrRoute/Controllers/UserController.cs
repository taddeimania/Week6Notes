using Day1AttrRoute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Day1AttrRoute.Controllers
{
    [Authorize]
    public class UserController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("u/{userName}")]
        public ActionResult Detail(string userName)
        {
            ApplicationUser userInstance = db.Users.Where(u => u.UserName == userName).FirstOrDefault();
            string me = User.Identity.GetUserId();
            string target = userInstance.Id;
            bool isFriend = db.Friends
                .Where(
                    f => (f.RequestorId == me && f.TargetId == target) ||
                         (f.TargetId == me && f.RequestorId == target)
                ).Any();
            ViewBag.isFriend = isFriend;
            return View(userInstance);
        }

        [HttpPost]
        [Route("u/{userName}")]
        public ActionResult AddFriend(string userName)
        {
            // Whatever happens!
            string me = User.Identity.GetUserId();
            string target = db.Users.Where(u => u.UserName == userName).FirstOrDefault().Id;
            Friend relationship = new Friend
            {
                RequestorId = me,
                TargetId = target
            };
            db.Friends.Add(relationship);
            db.SaveChanges();
            return RedirectToAction("Detail");
        }
    }
}