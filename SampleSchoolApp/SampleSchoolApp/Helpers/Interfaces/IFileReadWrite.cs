using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleSchoolApp.Helpers.Interfaces
{
  public interface IFileReadWrite
    {
        Task<bool> WriteToFile(String Text);
        Task<string> ReadFromFile();
        Task<bool> ReadToFile(string serialized);
    }
}
