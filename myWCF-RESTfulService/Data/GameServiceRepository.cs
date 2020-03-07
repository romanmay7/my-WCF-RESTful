using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using myWCF_RESTfulService.Data.Models;

namespace myWCF_RESTfulService.Data
{
    public partial class GameServiceRepository
    {
        private static readonly GameServiceRepository _instance;
        static string cs;
         static GameServiceRepository() 
        {
           _instance = new GameServiceRepository();
            //cs = ConfigurationManager.ConnectionStrings["myGamesDB"].ConnectionString;
            cs =@"Data Source=(localdb)\ProjectsV13;Initial Catalog=Games;Integrated Security=True;";


        }

        public static GameServiceRepository Instance
        {
            get
            {
                return _instance;
            }
        }

        public void Add(Game newGame)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("dbo.spAddNewGame", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add input parameters for the Stored Procedure and specify its value.
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Title";
                parameter.Value = newGame.Title;
                cmd.Parameters.Add(parameter);
  
                parameter.ParameterName = "@Genre";
                parameter.Value = newGame.Genre;
                cmd.Parameters.Add(parameter);

                parameter.ParameterName = "@Developer";
                parameter.Value = newGame.Developer;
                cmd.Parameters.Add(parameter);

                parameter.ParameterName = "@Publisher";
                parameter.Value = newGame.Publisher;
                cmd.Parameters.Add(parameter);  

                parameter.ParameterName = "@Year";
                parameter.Value = newGame.Year;
                cmd.Parameters.Add(parameter);
                try
                {
                    con.Open();
                    // Run the Stored Procedure.
                    cmd.ExecuteNonQuery();

                }
                catch {  }
                finally
                {
                    con.Close();
                }
            }

        }

        public void Delete (int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("dbo.spDeleteGame", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add input parameters for the Stored Procedure and specify its value.
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = id;
                cmd.Parameters.Add(parameter);

                try
                {
                    con.Open();
                    // Run the Stored Procedure.
                    cmd.ExecuteNonQuery();

                }
                catch { }
                finally
                {
                    con.Close();
                }
            }
        }

        public void Update (Game newGame)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("dbo.spUpdateGame", con);
                cmd.CommandType = CommandType.StoredProcedure;

                // Add input parameters for the Stored Procedure and specify its value.
                SqlParameter parameter = new SqlParameter();
                parameter.ParameterName = "@Id";
                parameter.Value = newGame.Id;
                cmd.Parameters.Add(parameter);

                parameter.ParameterName = "@Title";
                parameter.Value = newGame.Title;
                cmd.Parameters.Add(parameter);

                parameter.ParameterName = "@Genre";
                parameter.Value = newGame.Genre;
                cmd.Parameters.Add(parameter);

                parameter.ParameterName = "@Developer";
                parameter.Value = newGame.Developer;
                cmd.Parameters.Add(parameter);

                parameter.ParameterName = "@Publisher";
                parameter.Value = newGame.Publisher;
                cmd.Parameters.Add(parameter);

                try
                {
                    con.Open();
                    // Run the Stored Procedure.
                    cmd.ExecuteNonQuery();

                }
                catch { }
                finally
                {
                    con.Close();
                }
            }
        }

        public List<Game> GetList()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<Game> gameList = new List<Game>();
                SqlCommand cmd = new SqlCommand("dbo.spGetAllGames", con);
                cmd.CommandType = CommandType.StoredProcedure;


                try
                {
                    con.Open();

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);

              //Converting info from DataTable to List<Game>          
                        foreach (DataRow row in dt.Rows)
                        {
                            Game item = GetItem<Game>(row);
                            gameList.Add(item);
                        }
             //----------------------------------------------------
                    }                 

                }
                catch { }
                finally
                {
                    con.Close();
                }
                return gameList;
            }
        }



        //The following isfunctions in which if we pass a DataRow from DataTable and a user defined class. 
        //It will then return the Instance of that class . 
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
