using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using Npgsql;
using MVC.Repositories;



namespace MVC.Repositories
{
    public class UserRepositories : CommanRepositories, IUseriRepositories
    {
         public tbluser GetOne(int id)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM t_uertable1 WHERE c_userid = @c_userid";
            cmd.Parameters.AddWithValue("c_userid",id);
             NpgsqlDataReader sdr = cmd.ExecuteReader();
            var user = new tbluser();
            while (sdr.Read())
            {
                user.Id = Convert.ToInt32(sdr["c_userid"]);
                user.UserName = sdr["c_username"].ToString();
                user.EmailId = sdr["c_email"].ToString();
                user.Password = sdr["c_password"].ToString();
               
            }
             conn.Close();
            sdr.Close();
            return user;
        }


        public bool Register(tbluser user)
        {
           


            NpgsqlCommand cmd = new NpgsqlCommand();

            
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO t_user (c_username,c_emailid,c_password) VALUES(@c_username,@c_email,@c_password);";
            cmd.Parameters.AddWithValue("@c_username", user.UserName);
            cmd.Parameters.AddWithValue("@c_email", user.EmailId);
            cmd.Parameters.AddWithValue("@c_password", user.Password);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            try
            {
             cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                    return false;
            }
            finally
            {
            conn.Close();

            }
           
        }


        public tbluser Login(tbluser data)
        {


            NpgsqlCommand cmd = new NpgsqlCommand();


            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM t_user WHERE c_emailid=@c_emailid AND c_password = @c_password;";
            cmd.Parameters.AddWithValue("@c_emailid", data.EmailId);
            cmd.Parameters.AddWithValue("@c_password", data.Password);
            tbluser user = null;
            conn.Open();  
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());      
           
            if(dt.Rows.Count > 0)
            {
                user = (from DataRow dr in dt.Rows select new tbluser()
                {
                    
                    
                    EmailId = dr["c_emailid"].ToString(),
                    Password = dr["c_password"].ToString(),
                }).ToList().FirstOrDefault();
            }
           
            conn.Close();
            return user;
        }


        public void Update(tbluser user)
        {
            NpgsqlCommand cmd = new NpgsqlCommand();


            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Update t_usertable1 SET c_username=@c_username,c_gender=@c_gender,c_email=@c_email,c_password=@c_password WHERE c_userid=@c_userid ;";
             cmd.Parameters.AddWithValue("@c_userid", user.Id);
            cmd.Parameters.AddWithValue("@c_username", user.UserName);
            cmd.Parameters.AddWithValue("@c_email", user.EmailId);
            cmd.Parameters.AddWithValue("@c_password", user.Password);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }




    }
}
