using Newtonsoft.Json;
using System.Diagnostics;

namespace CustomJsonDeserializer
{
  class Program
  {
    static void Main(string[] args)
    {
      var employee = new Employee { firstName = "flouflis", lastName = "skountouflis", salary = 100 };
      var president = new President { firstName = "lakis", lastName = "lalakis", votes = 20 };

      var employeeJson = JsonConvert.SerializeObject(employee);
      var presidentJson = JsonConvert.SerializeObject(president);

      Debug.WriteLine(employeeJson);
      Debug.WriteLine(presidentJson);

      var deserilized1 = JsonConvert.DeserializeObject<Person>(employeeJson, new PersonConverter());
      var deserilized2 = JsonConvert.DeserializeObject<Person>(presidentJson, new PersonConverter());

      Debug.WriteLine(deserilized1.GetType().FullName);
      Debug.WriteLine(deserilized2.GetType().FullName);
    }
  }
}
