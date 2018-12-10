using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PatientSevice.Controllers;
using PatientSevice.DataMapper;
using System.Web.Http;
using System.Net.Http;
using PatientSevice.Models;
using System.Collections.Generic;

namespace APITestProject
{

    [TestClass]
    public class PatientTest
    {
        
        [TestMethod]
        public void GetPatientsTest()
        {
            var mockService = new Mock<IPatient>();
            var patientController = new PatientController(mockService.Object);
            patientController.Configuration = new HttpConfiguration();
            patientController.Request = new HttpRequestMessage();

            List<Patient> lstPatients = new List<Patient>();
            Patient patTest = new Patient();
            patTest.FirstName = "Test";
            patTest.SurName = "Y";
            patTest.Gender = "M";
            lstPatients.Add(patTest);

            mockService.Setup(S => S.GetPatientDetals()).Returns(new List<Patient>());
            var response = patientController.GetPatients();
            Assert.IsTrue(response.TryGetContentValue<List<Patient>>(out lstPatients));




        }
    }
}
