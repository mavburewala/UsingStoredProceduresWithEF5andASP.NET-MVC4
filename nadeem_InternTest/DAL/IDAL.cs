using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nadeem_InternTest.Models;

namespace nadeem_InternTest.DAL
{
    public interface IDAL     //An interface! To follow DI/Ioc design pattern by Autofac
    {
        List<Customer> SearchCustomer(string forename=null,string lastname=null,string postcode=null);
       bool SaveVehicleService(int VehicleId,string MechanicName,string Notes,decimal price,DateTime? serviceDate);
        Customer GetCustomerDetails(int CustomerId);
        List<Customer> ShowAll();

    }
}
