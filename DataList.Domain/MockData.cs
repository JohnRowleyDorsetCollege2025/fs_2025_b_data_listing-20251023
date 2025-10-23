using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataList.Domain
{
    public static class MockData
    {
        public static List<Patient> GetPatients(int count)
        {
            List<Patient> patients = new List<Patient>();

            var faker = new Faker<Patient>()
            .RuleFor(p => p.Id, f => Guid.NewGuid().ToString())
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName));

            for (int i = 0; i < count; i++)
            {

                patients.Add(faker.Generate());
            }


            return patients;

        }
    }
}
