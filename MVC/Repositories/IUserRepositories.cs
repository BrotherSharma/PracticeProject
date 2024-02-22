using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Models;


namespace WEBAPI.Repositories
{
    public interface IUseriRepositories
    {
        //Declaring Methods in Interface
        tbluser GetOne (int id);
    

        bool Register (tbluser user);


        void Update(tbluser user);


        tbluser  Login (tbluser user);
           
    }
}
