using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using nadeem_InternTest.DAL;

namespace nadeem_InternTest.Controllers
{
    //this is Web API controller that is being called via ajax call in application
    public class VehicleServiceController : ApiController
    {
        // it adds service for particular vehicle
        public JObject Add(string Service)
        {
            IDAL _dal = new DatabaseRetriever();
            JObject newservice=(JObject)JsonConvert.DeserializeObject(Service);
            JObject errors = new JObject();
            JObject _result = new JObject();
            if (string.IsNullOrEmpty(newservice["vehicleid"].ToString()))
                errors.Add("VehicleID", "VehicleId is required");
            if (string.IsNullOrEmpty(newservice["mechanicname"].ToString()))
                errors.Add("MechanicName", "Mechanic Name is Required");
            if (string.IsNullOrEmpty(newservice["money"].ToString()))
                errors.Add("Money", "Money is required");

            if (errors.Count > 0)
            {
                _result.Add("success",false);
                _result.Add("errors", errors);
            }
            else
            {
                try
                {
                    int VehicleId = int.Parse(newservice["vehicleid"].ToString());
                    string MechanicName = newservice["mechanicname"].ToString();
                    string Notes = null;
                    if (!string.IsNullOrEmpty(newservice["notes"].ToString())) 
                        Notes = newservice["notes"].ToString();
                    decimal Money = decimal.Parse(newservice["money"].ToString());
                    DateTime? date=null;
                    if (!string.IsNullOrEmpty(newservice["date"].ToString()))
                    {
                        newservice["date"] = newservice["date"].ToString().Replace("T", " ");
                        date = DateTime.Parse(newservice["date"].ToString());
                    }
                       

                    if (_dal.SaveVehicleService(VehicleId, MechanicName, Notes,
                        Money, date))
                    {
                        _result.Add("success", true);
                        _result.Add("errors", null);
                    }
                    else
                    {
                        _result.Add("success", false);
                        errors.Add("Database", "Database couldn't insert the record");
                        _result.Add("errors", errors);
                    }


                }
                catch (Exception c)
                {
                    _result.Add("success", false);
                    errors.Add("Input-Conversion", "There is something wrong with inputs' format");
                    errors.Add("Exception", c.Message);
                    _result.Add("errors", errors);
                }
            }
            return _result;
        }
    }
}
