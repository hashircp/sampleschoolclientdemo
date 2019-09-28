using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SampleSchoolApp.Services
{
    public interface ISchoolService
    {
        IEnumerable GetSchools();
        void ValidateSchoolInfo()
    }
}
