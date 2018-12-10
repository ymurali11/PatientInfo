using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientSevice.Models;

namespace PatientSevice.DataMapper
{
   public interface IPatient
    {
        int SavePatientDetails(Patient _patient);
        List<Patient> GetPatientDetals();

    }
}
