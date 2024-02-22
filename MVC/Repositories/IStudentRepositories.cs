using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;


namespace MVC.Repositories
{
    public interface IStudentRepositories
    {
        //Declaring Methods in Interface
        tblStudent GetOne (int id);
         List<tblStudent> GetAll();

        void Insert (tblStudent stud);


        void Update(tblStudent stud);


        void  Delete (int id);
           
    }
}
