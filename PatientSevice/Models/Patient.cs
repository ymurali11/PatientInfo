﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;



namespace PatientSevice.Models
{
    public class Patient
    {
                public string FirstName { get; set; }

        
        public string LastName { get; set; }

        
        public string DOB { get; set; }

        
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

