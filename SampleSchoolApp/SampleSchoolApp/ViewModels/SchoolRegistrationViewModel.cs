using SampleSchoolApp.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SampleSchoolApp.ViewModels
{
    class SchoolRegistrationViewModel
    {
        private readonly ISchoolService _schoolService;
        public IEnumerable School { get; set; }
        public SchoolRegistrationViewModel(ISchoolService schoolService)
        {
            _schoolService = schoolService;// new SchoolService();
            GetSchoolsDetails();
        }

        public void GetSchoolsDetails()
        {
            School = _schoolService.GetSchools();
        }

      
    }
}
