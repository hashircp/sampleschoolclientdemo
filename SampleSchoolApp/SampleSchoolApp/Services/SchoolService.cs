using SampleSchoolApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SampleSchoolApp.Services
{
    class SchoolService: ISchoolService
    {
        public IEnumerable GetSchools()
        {
            return new List<SchoolModel>
        {
            new SchoolModel { SchoolName = "FEMS", Address = "Lebnon Street" },
            new SchoolModel { SchoolName = "AL Rebieh", Address = "Wall India Ten" },
        };
        }

    }
}
