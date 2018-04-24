using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReviewSpring18.Models;

namespace BookReviewSpring18.Controllers
{
    public class RegisterController : Controller
    {
        BookReviewDbEntities db = new BookReviewDbEntities(); //Reference
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ReviewerUserName, ReviewerFirstName," +
            "ReviewerLastName, ReviewerEmail, ReviewPlainPassword")]Reviewer r) // Bind going to bind all fields from the stored procedure to new instants of class r
              //Reviewer here is a existing class in Models 
        {
            Message m = new Message();
            int result = db.usp_NewReviewer(r.ReviewerUserName, r.ReviewerFirstName,
            r.ReviewerLastName, r.ReviewerEmail, r.ReviewPlainPassword);

            if (result != -1)
            {
                m.MessageText = "Welcome, " + r.ReviewerUserName;
            }

            else
            {
                m.MessageText = "Something Went Error";

            }

            return View("Result", m);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }




    }
}