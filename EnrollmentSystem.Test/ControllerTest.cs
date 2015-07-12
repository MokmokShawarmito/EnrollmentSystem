using System;
using System.Linq;
using System.Collections.Generic;
using EnrollmentSystem.core.Abstracts;
using EnrollmentSystem.core.Factories;
using EnrollmentSystem.core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnrollmentSystem.Test
{
    [TestClass]
    public class ControllerTest
    {
        IStudentController controller = ControllerFactory.CreateStudentController();

        [TestMethod]
        public void GetByID()
        {
            //arrange
            int id = 2;
            Student result = null;
            
            //act
            result = controller.GetByID(id);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            //arrange
            Boolean ifZero = true;
            IEnumerable<Student> result = new List<Student>();

            //act
            result = controller.GetAll();
            if (result.Count() > 0)
                ifZero = false;
            //assert
            Assert.IsFalse(ifZero);
        }

        [TestMethod]
        public void Add()
        {
            //arrange
            Boolean isSuccess = true;
            Student newStudent = new Student();
            newStudent.Name = "Harold Paluca";
            newStudent.IsActive = false;

            //act
            isSuccess = controller.Add(newStudent);
            
            //assert
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void Update()
        {
            //arrange
            Boolean isSuccess = true;
            Student newStudent = new Student();
            newStudent.ID = 2;
            newStudent.Name = "Benjie Estrella";
            newStudent.IsActive = true;

            //act
            isSuccess = controller.Update(newStudent);

            //assert
            Assert.IsTrue(isSuccess);
        }

        [TestMethod]
        public void Delete()
        {
            //arrange
            Boolean isSuccess = true;
            int id = 4;

            //act
            isSuccess = controller.Delete(id);

            //assert
            Assert.IsTrue(isSuccess);
        }
    }
}
