using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebMvc2.Models;
using System.Data;

namespace WebMvc2.service
{
    public class Employeeservice
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;



        public IList<EmployeeModel> GetEmployeeList() {


            IList<EmployeeModel> getEmpList = new List<EmployeeModel>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employeeviewstore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmpList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                _ds = new DataSet();
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        EmployeeModel obj = new EmployeeModel();
                        obj.Emp_ID = Convert.ToInt32(_ds.Tables[0].Rows[i]["Emp_ID"]);
                        obj.FirstName = Convert.ToString(_ds.Tables[0].Rows[i]["FirstName"]);
                        obj.LastName = Convert.ToString(_ds.Tables[0].Rows[i]["LastName"]);
                        obj.EMP_DOB = Convert.ToDateTime(_ds.Tables[0].Rows[i]["EMP_DOB"]);
                        obj.EmailId = Convert.ToString(_ds.Tables[0].Rows[i]["RoleID"]);

                        getEmpList.Add(obj);






                    }
                }



            }



            return getEmpList;


        } 
            
        




        public void insertEmployee(EmployeeModel model)


        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employeeviewstore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddEmployee");
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@EMP_DOB", model.EMP_DOB);
                cmd.Parameters.AddWithValue("@EmailId", model.EmailId);
                cmd.Parameters.AddWithValue("@RoleID", model.EMP_DOB);
                cmd.ExecuteNonQuery();



            }
                
        }


        public EmployeeModel GetEditById(int Id)
        {
            var model = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employeeviewstore", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetEmployeeById");
                object Emp_ID = null;
                cmd.Parameters.AddWithValue("@EmpId", Emp_ID);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if(_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {

                    model.Emp_ID = Convert.ToInt32(_ds.Tables[0].Rows[0]["Emp_ID"]);
                    model.FirstName = Convert.ToString(_ds.Tables[0].Rows[0]["FirstName"]);
                    model.LastName = Convert.ToString(_ds.Tables[0].Rows[0]["LastName"]);
                    model.EMP_DOB = Convert.ToDateTime(_ds.Tables[0].Rows[0]["EMP_DOB"]);
                    model.EmailId = Convert.ToString(_ds.Tables[0].Rows[0]["EmailId"]);
                    model.RoleID = Convert.ToInt32(_ds.Tables[0].Rows[0]["RoleID"]);
                }


            }





                return model;


        }

       public void UpdateEmp(EmployeeModel model)
        {
            using(SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Employeeviewstore");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdateEmployee");
                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@EMP_DOB", model.EMP_DOB);
                cmd.Parameters.AddWithValue("@EmailId", model.EmailId);
                cmd.Parameters.AddWithValue("@RoleID", model.RoleID);
                cmd.Parameters.AddWithValue("@EmpId", model.Emp_ID);
                cmd.ExecuteNonQuery();




            }
        }

        public void DeleteEmp(int Emp_ID)
        {
            using (SqlConnection con = new SqlConnection(connect))

            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteEmployee");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mode", "DeleteEmployee");
            cmd.Parameters.AddWithValue("@EmpId", Emp_ID);
            cmd.ExecuteNonQuery();


            }

        }

    }




