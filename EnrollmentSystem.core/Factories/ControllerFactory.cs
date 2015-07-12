using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnrollmentSystem.core.Abstracts;
using EnrollmentSystem.core.Controllers;

namespace EnrollmentSystem.core.Factories
{
    public class ControllerFactory
    {
        public static IStudentController CreateStudentController() 
        {
            return new StudentController();
        }
    }
}
