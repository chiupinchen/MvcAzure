using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAzure.Models
{
    public class PersonListViewModel
    {

        public string PersonName { get; set; }
        public int PersonAge { get; set; }
        public string TopDegreeName { get; set; }
        public float TopDegreeGPA { get; set; }

    }
}