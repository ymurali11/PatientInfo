using Newtonsoft.Json;
using PatientDetails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PatientDetails.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient 

            //Using HttpClient calling the insert Patients method.
        HttpClient httpClient = new HttpClient();
        public ActionResult CreatePatient(string model,string contactList)
        {
           if(model ==null ||model==String.Empty)
            return View();

            else
            {
                Patient patientDetails = new JavaScriptSerializer().Deserialize<Patient>(model);
                patientDetails.PatientContact = new JavaScriptSerializer().Deserialize<List<ContactInfo>>(contactList);
                var content = new StringContent(JsonConvert.SerializeObject(patientDetails));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                httpClient.PostAsync("http://localhost:52084/api/patient/SavePatients", content);
                return View();
            }
        }

        //[HttpPost]
        //public ActionResult InsertPatient(string model,string contactList)
        //{
            
        //}
    }
}