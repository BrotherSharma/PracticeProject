using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;


namespace MVC.Repositories
{
    public class CommanRepositories
    {
        protected NpgsqlConnection conn;



        public CommanRepositories()
        {
                IConfiguration myConfig = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();


                conn = new NpgsqlConnection(myConfig.GetConnectionString("DefaultConnection"));
        }
    }
}
