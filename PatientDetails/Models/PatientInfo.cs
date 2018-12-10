using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PatientDetails.Models
{
    public class Patient
    {
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public string DOB { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        public List<ContactInfo> PatientContact { get; set; }

    }

    public class ContactInfo
    {
        public string WorkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
    }

}