using NHibernate.Always.Encrypted.ConsoleApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ISession session = NHibernateSession.OpenSession())
            {
                session.SaveOrUpdate(new Patient()
                {
                     BirthDate = DateTime.Now,
                     FirstName = "Michael",
                     City = "Dallas",
                     LastName = "Green",
                     MiddleName = "D",
                     SSN = "638-55-8787",
                     State = "TX",
                     StreetAddress = "4902 Hibiscus Dr",
                     ZipCode = "75521"
                });

                var employee = session.QueryOver<Patient>().Where(p => p.Id == 1).SingleOrDefault();
            }

            Console.Read();
        }
    }
}
