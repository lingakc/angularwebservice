using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;//This namespace can be used to convert data into json format.

namespace angularwebservice
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService] //uncomment this webservice to call from javascript.
    public class EmployeeService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllEmployees()
        {
            List<Employee> listEmployees = new List<Employee>();
            //string cs = ConfigurationManager.ConnectionStrings["wenconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection("Data Source=BWTECH-PC;database=linga;integrated security=true;"))
            {
                SqlCommand cmd = new SqlCommand("select *from tbl_Employee",con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                    listEmployees.Add(employee);

                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();// This class present in System.web.Script.Serialiation namespace.
            Context.Response.Write(js.Serialize(listEmployees));
        }
        [WebMethod]
        public void GetEmployee(int id)
        {
            Employee employee = new Employee();
            //string cs = ConfigurationManager.ConnectionStrings["wenconnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection("Data Source=BWTECH-PC;database=linga;integrated security=true;"))
            {
                SqlCommand cmd = new SqlCommand("select *from tbl_Employee", con);
                SqlParameter param = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = id
                };
                cmd.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   
                    employee.EmployeeId = Convert.ToInt32(rdr["EmployeeId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.City = rdr["City"].ToString();
                    employee.DepartmentId = Convert.ToInt32(rdr["DepartmentId"]);
                  

                }
            }
            JavaScriptSerializer js = new JavaScriptSerializer();// This class present in System.web.Script.Serialiation namespace.
            Context.Response.Write(js.Serialize(employee));
        }
    }
}
