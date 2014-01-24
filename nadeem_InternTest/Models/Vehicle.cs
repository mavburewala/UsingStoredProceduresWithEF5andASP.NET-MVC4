using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nadeem_InternTest.Models
{
    public class Vehicle
    {
        public int Id {get;set;}
        public int CustomerId{get;set;}
        public string Make{get;set;}
        public string Model{get;set;}
        public string Variation{get;set;}
        public string FuelType{get;set;}
        public string Year{get;set;}
        public string Colour{get;set;}
        public List<VehicleService> Services{get;set;}
        public Vehicle(int Id,int CustomerId,string Make,string Model,string Variation,string FuelType,string Year,string Colour)
        {
            this.Id=Id;
            this.CustomerId=CustomerId;
            this.Make=Make;
            this.Model=Model;
            this.Variation=Variation;
            this.FuelType=FuelType;
            this.Year=Year;
            this.Colour=Colour;
            this.Services=new List<VehicleService>();
        }
    }
}