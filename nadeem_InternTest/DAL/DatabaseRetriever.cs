using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.ComponentModel;
using System;
using nadeem_InternTest.DAL.EntityFrameworkWithDatabase;

namespace nadeem_InternTest.DAL
{
    // This is database retriever that handles all database specfic tasks(i.e., invoking stored procedures in database)
    public class DatabaseRetriever : IDAL     //This implements IDAL as it follows DI/Ioc design pattern by Autofac
    {
        
        public List<Models.Customer> SearchCustomer(string forename = null, string surname = null, string postcode = null)
        {
            List<Models.Customer> results = new List<Models.Customer>();
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                IMultipleResults receivedResults = db.SearchCustomer(forename, surname, postcode);
                var customers = receivedResults.GetResult<EntityFrameworkWithDatabase.Customer>();
                foreach (EntityFrameworkWithDatabase.Customer customer in customers)
                {
                    Models.Customer cust = new Models.Customer(customer.ID, customer.Forename, customer.Surname, customer.Address, customer.Postcode, customer.Notes);
                    results.Add(cust);
                }
            }
            return results;
        }


        public List<Models.Customer> ShowAll()
        {
            List<Models.Customer> result=new List<Models.Customer>();
            using(DataClassesDataContext db=new DataClassesDataContext())
            {
                IMultipleResults x = db.SelectCustomer(null);
                var customers = x.GetResult<EntityFrameworkWithDatabase.Customer>().ToList();
                var veh = x.GetResult<EntityFrameworkWithDatabase.Vehicle>().ToList();
                var vehser = x.GetResult<EntityFrameworkWithDatabase.VehicleService>().ToList();
                foreach (EntityFrameworkWithDatabase.Customer customer in customers)
                {
                    Models.Customer cust = new Models.Customer(customer.ID, customer.Forename, customer.Surname, customer.Address, customer.Postcode, customer.Notes);
                    cust.Vehicles = EquipVehicles(veh, vehser, cust.Id);
                    result.Add(cust);
                }
            }
            return result;
        }


        public Models.Customer GetCustomerDetails(int CustomerId)
        {
            List<Models.Customer> result = new List<Models.Customer>();
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                IMultipleResults x = db.SelectCustomer(CustomerId);
                var customers = x.GetResult<EntityFrameworkWithDatabase.Customer>();
                var veh = x.GetResult<EntityFrameworkWithDatabase.Vehicle>();
                var vehser = x.GetResult<EntityFrameworkWithDatabase.VehicleService>();
                foreach (EntityFrameworkWithDatabase.Customer customer in customers)
                {
                    Models.Customer cust = new Models.Customer(customer.ID, customer.Forename, customer.Surname, customer.Address, customer.Postcode, customer.Notes);
                    cust.Vehicles = EquipVehicles(veh.ToList(), vehser.ToList(), cust.Id);
                    result.Add(cust);
                }
            }
            return result[0];
        }

        private List<Models.Vehicle> EquipVehicles(List<EntityFrameworkWithDatabase.Vehicle> availableVehicleList, List<EntityFrameworkWithDatabase.VehicleService> availableVehicleServiceList, int customerId)
        {
            List<Models.Vehicle> vehicleList = new List<Models.Vehicle>();
            foreach (EntityFrameworkWithDatabase.Vehicle vehicle in availableVehicleList)
            {
                if (vehicle.CustomerID == customerId)
                {
                    Models.Vehicle veh = new Models.Vehicle(vehicle.ID, vehicle.CustomerID, vehicle.Make, vehicle.Model, vehicle.Variation, vehicle.FuelType, vehicle.Year, vehicle.Colour);
                    veh.Services = EquipService(availableVehicleServiceList, veh.Id);
                    vehicleList.Add(veh);
                }
            }
            return vehicleList;
            
        }
        private List<Models.VehicleService> EquipService(List<EntityFrameworkWithDatabase.VehicleService> availableList, int vehicleId)
        {
            List<Models.VehicleService> vehicleServiceList = new List<Models.VehicleService>();
            foreach (EntityFrameworkWithDatabase.VehicleService vehicleService in availableList)
            {
                if (vehicleService.VehicleID == vehicleId)
                {
                    Models.VehicleService veh = new Models.VehicleService(vehicleService.ID, vehicleService.VehicleID, vehicleService.MechanicName, vehicleService.Notes, vehicleService.Price, vehicleService.ServiceDate?? DateTime.Now);
                    vehicleServiceList.Add(veh);
                }
            }
            return vehicleServiceList;

        }

        public bool SaveVehicleService(int VehicleId, string MechanicName, string Notes, decimal price, DateTime? serviceDate)
        {
            bool result = false;
            try
            {
                using (DataClassesDataContext db = new DataClassesDataContext())
                {
                    db.InsertServiceDetailProcedure(VehicleId, MechanicName, Notes, price, serviceDate);
                    result = true;
                }
            }
            catch (Exception c)
            {

            }
            return result;
        }
    }
}