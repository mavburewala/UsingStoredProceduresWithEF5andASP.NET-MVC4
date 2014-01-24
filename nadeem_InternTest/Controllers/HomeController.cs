using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using nadeem_InternTest.DAL;

namespace nadeem_InternTest.Controllers
{
    public class HomeController : Controller
    {
        private IDAL _dal;

        public HomeController(IDAL dal)
        {
            _dal = dal;
        }
        public ActionResult Index()
        {
            return View();
        }

        //POST for searching Customer based on forename, surname or postcode
        [HttpPost]
        public ActionResult Index(string forename,string surname,string postcode)
        {
            if(string.IsNullOrEmpty(forename)) forename=null;
            if(string.IsNullOrEmpty(surname)) surname=null;
            if(string.IsNullOrEmpty(postcode)) postcode=null;
            List<Models.Customer> results = _dal.SearchCustomer(forename, surname, postcode);
            return View(results);
        }

        // It serves 2 purposes    1.if it gets no parameter, it lists all customers with their details
        //                         2. Incase it gets customerid as parameter, it shows details of that customer
        public ActionResult ShowCustomerDetails(int? customerId)
        {
            List<Models.Customer> results=new List<Models.Customer>();
            if (customerId!=null)
                results.Add(_dal.GetCustomerDetails(int.Parse(customerId.ToString())));
            else
                results = _dal.ShowAll();
            return View(results);
        }


        // it facilates to add new service for customer's car
        public ActionResult AddService()
        {
            return View();
        }

        
    }
   
}
