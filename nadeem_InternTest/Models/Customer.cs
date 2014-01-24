using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nadeem_InternTest.Models
{
    public class Customer
    {
        public int Id   {get;set;} 
        public string Forename  {get;set;}
        public string Surname   {get;set;}
        public string Address   {get;set;}
        public string Postcode  {get;set;}
        public string Notes {get;set;}
        public List<Vehicle> Vehicles { get; set; }
        public Customer(int Id, string Forename, string Surname, string Address, string Postcode, string Notes)
        {
            this.Id = Id;
            this.Forename = Forename;
            this.Surname = Surname;
            this.Address = Address;
            this.Postcode = Postcode;
            this.Notes = Notes;
            this.Vehicles = new List<Vehicle>();
        }
    }
}