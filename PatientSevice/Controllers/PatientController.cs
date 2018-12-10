using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientSevice.DataMapper;
using PatientSevice.Filters;
using PatientSevice.Models;

namespace PatientSevice.Controllers
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {

        public IPatient patientInfo;

        public PatientController()
        {
            patientInfo = new PatientMapper();
        }

        // Below constructor used of mock service. When request comes from Test project below controller will execute.
        public PatientController(IPatient mockPatient)
        {
            patientInfo = mockPatient;
        }



        //Exception filter used on each action to log errors at global level.

        [HttpPost]
        [PatientInfoExceptionFilter]
        public HttpResponseMessage SavePatients(Patient _patientDetails)
        {
            Patient patientDet = new Patient();

            int result=patientInfo.SavePatientDetails(_patientDetails);


            if (result ==0)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Patient Details Not Found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, "Patient Details Saved");
        }

        [HttpGet]

        public HttpResponseMessage GetPatients()
        {
            List<Patient> lstPatients = new List<Patient>();
            lstPatients = patientInfo.GetPatientDetals();

            if(lstPatients==null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Patient Details Not Found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, lstPatients);
        }
    }


   
}