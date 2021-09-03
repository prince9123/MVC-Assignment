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
    public class ProjectService
    {
        public string connect = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        private SqlDataAdapter _adapter;
        private DataSet _ds;



        public IList<ProjectModel> GetProijectList()
        {


            IList<ProjectModel> getProList = new List<ProjectModel>();
            _ds = new DataSet();

            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectVieworInsrert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProjectList");
                _adapter = new SqlDataAdapter(cmd);
                _adapter.Fill(_ds);
                _ds = new DataSet();
                if (_ds.Tables.Count > 0)
                {
                    for (int i = 0; i < _ds.Tables[0].Rows.Count; i++)
                    {
                        ProjectModel obj = new ProjectModel();
                        obj.Proid = Convert.ToInt32(_ds.Tables[0].Rows[i]["Proid"]);
                        obj.Project_name = Convert.ToString(_ds.Tables[0].Rows[i]["Project_name"]);
                        obj.StartDate = Convert.ToDateTime(_ds.Tables[0].Rows[i]["StartDate"]);
                        obj.EndDate = Convert.ToDateTime(_ds.Tables[0].Rows[i]["EndDate"]);
                        obj.Budget = Convert.ToString(_ds.Tables[0].Rows[i]["Budget"]);

                        getProList.Add(obj);






                    }
                }



            }



            return getProList;


        }






        public void InsertProject(ProjectModel model)


        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectVieworInsrert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "AddProject");
                cmd.Parameters.AddWithValue("@Project_name", model.Project_name);
                cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                cmd.Parameters.AddWithValue("@EndDtae", model.EndDate);
                cmd.Parameters.AddWithValue("@Budget", model.Budget);
                cmd.ExecuteNonQuery();



            }

        }


        public ProjectModel GetEditByProid(int Proid)
        {
            var model = new ProjectModel();
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectVieworInsrert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "GetProjectByProid");
               // object Proid  = null;
                cmd.Parameters.AddWithValue("@em_Proid", Proid);
                _adapter = new SqlDataAdapter(cmd);
                _ds = new DataSet();
                _adapter.Fill(_ds);
                if (_ds.Tables.Count > 0 && _ds.Tables[0].Rows.Count > 0)
                {

                    model.Proid = Convert.ToInt32(_ds.Tables[0].Rows[0]["Proid"]);
                    model.Project_name = Convert.ToString(_ds.Tables[0].Rows[0]["Project_name"]);
                    model.StartDate = Convert.ToDateTime(_ds.Tables[0].Rows[0]["StartDate"]);
                    model.EndDate = Convert.ToDateTime(_ds.Tables[0].Rows[0]["EndDate"]);
                    model.Budget = Convert.ToString(_ds.Tables[0].Rows[0]["Budget"]);
                }


            }

            return model;


        }

        public void UpdatePro(ProjectModel model)
        {
            using (SqlConnection con = new SqlConnection(connect))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ProjectVieworInsrert");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mode", "UpdatePro");
                cmd.Parameters.AddWithValue("@Project_name", model.Project_name);
                cmd.Parameters.AddWithValue("@StartDate", model.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", model.EndDate);
                cmd.Parameters.AddWithValue("@Budget", model.Budget);
                cmd.Parameters.AddWithValue("@EmpId", model.Proid);
                cmd.ExecuteNonQuery();




            }
        }

        public void DeletePro(int em_Proid)
        {
            using (SqlConnection con = new SqlConnection(connect))

                con.Open();
            SqlCommand cmd = new SqlCommand("DeleteProject");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mode", "DeleteProject");
            cmd.Parameters.AddWithValue("@Proid", em_Proid);
            cmd.ExecuteNonQuery();


        }

    }

}



