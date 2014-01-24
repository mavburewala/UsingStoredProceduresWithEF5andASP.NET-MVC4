
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

namespace nadeem_InternTest.DAL.EntityFrameworkWithDatabase
{
    public partial  class DataClassesDataContext
    {
        [Function(Name = "SelectCustomerProcedure")]
        [ResultType(typeof(EntityFrameworkWithDatabase.Customer))]
        [ResultType(typeof(EntityFrameworkWithDatabase.Vehicle))]
        [ResultType(typeof(EntityFrameworkWithDatabase.VehicleService))]
        public IMultipleResults SelectCustomer(int? customerid)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), customerid);
            return (IMultipleResults)result.ReturnValue;
        }
        [Function(Name = "SearchCustomerProcedure")]
        [ResultType(typeof(EntityFrameworkWithDatabase.Customer))]
        public IMultipleResults SearchCustomer(string forename,string surname,string postcode)
        {
            string[] param=new string[3];
            param[0] = forename;
            param[1] = surname;
            param[2] = postcode;
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), param);
            return (IMultipleResults)result.ReturnValue;
        }
    }
}