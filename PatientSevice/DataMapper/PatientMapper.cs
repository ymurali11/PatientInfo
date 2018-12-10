using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using PatientSevice.Models;
using System.Configuration;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Xml;

namespace PatientSevice.DataMapper
{
    public class PatientMapper : IPatient
    {
        public const string PROC_GET_PATIENTS = "usp_GetPatientDetails";
        public const string PROC_SAVE_PATIENTS = "usp_SavePatientDetails";

        public List<Patient> GetPatientDetals()
        {
            List<Patient> lstPatient = new List<Patient>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PatientDB"].ToString()))

            {
                SqlCommand cmdPatient = new SqlCommand();
                cmdPatient.Connection = conn;
                cmdPatient.CommandType = System.Data.CommandType.StoredProcedure;
                cmdPatient.CommandText = PROC_GET_PATIENTS;

                try
                {
                    conn.Open();

                    using (SqlDataReader patientReader = cmdPatient.ExecuteReader())
                    {
                        while (patientReader.Read())
                        {
                            lstPatient.Add(GetObjectFromXML(patientReader[0].ToString()));
                        }
                    }
                }

                finally
                {
                    conn.Close();
                }

            }

                return lstPatient;
        }

        public int SavePatientDetails(Patient _patientInfo)
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PatientDB"].ToString()))

            {
                SqlCommand cmdPatient = new SqlCommand();
                cmdPatient.Connection = conn;
                cmdPatient.CommandType = System.Data.CommandType.StoredProcedure;
                cmdPatient.CommandText=PROC_SAVE_PATIENTS;
                cmdPatient.Parameters.Add(new SqlParameter("@patient_details", System.Data.SqlDbType.Xml));
                cmdPatient.Parameters["@patient_details"].Value = GetXmlFromObject(_patientInfo);

                try
                {
                    conn.Open();
                   return cmdPatient.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }

                

            }

        public string GetXmlFromObject(object _patient)
        {
           StringWriter sw = new StringWriter();
            XmlTextWriter xWriter = new XmlTextWriter(sw);

            try
            {
                XmlSerializer xSerializer = new XmlSerializer(_patient.GetType());
                xSerializer.Serialize(xWriter, _patient);
                return sw.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                xWriter.Close();
                sw.Close();
            }
        }

        public Patient GetObjectFromXML(string patientXML)
        {
            Patient _patient = null; ;
            XmlSerializer xSerializer = new XmlSerializer(typeof(Patient));

            using (TextReader tReader = new StringReader(patientXML))
            {
               _patient=(Patient) xSerializer.Deserialize(tReader);
            }

            return _patient;
        }
    }


}