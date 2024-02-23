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
        tblstudent GetOne (int id);
         List<tblstudent> GetAll();

         List<tblCourse> GetCourseNames();

        void Insert (tblstudent stud);


        void Update(tblstudent stud);


        void  Delete (int id);
           
    }
}
