using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nadeem_InternTest.Models
{
    public class VehicleService
    {
        public int Id{get;set;}
        public int VehicleID {get;set;}
        public string MechanicName{get;set;}
        public string Notes{get;set;}
        public decimal Money{get;set;}
        public DateTime Date_Time{get;set;}
        public VehicleService(int Id,int VehicleId,string MechanicName,string Notes,decimal Money,DateTime date_Time)
        {
            this.Id = Id;
            this.VehicleID = VehicleID;
            this.MechanicName = MechanicName;
            this.Notes = Notes;
            this.Money = Money;
            this.Date_Time = date_Time;
        }
    }
}