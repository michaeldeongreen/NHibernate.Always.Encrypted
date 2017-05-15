using NHibernate.Always.Encrypted.ConsoleApp.Domain;
using NHibernate.Type;
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
            //638-55-8787 michael
            //380-55-8787 joanna

            /*ADO*/
            //ADONetSession.SaveOrUpdate();

            /*Fluent NHibernate*/
            /*
            using (ISession session = FluentNHibernateSession.OpenSession())
            {
                session.SaveOrUpdate(new Patient()
                {
                     BirthDate = DateTime.Now,
                     FirstName = "Joanna",
                     City = "Seattle",
                     LastName = "Walsh",
                     MiddleName = "S.",
                     SSN = "380-55-8787",
                     State = "WA",
                     StreetAddress = "1101 Chase Av.",
                     ZipCode = "85231"
                });

                //var employee = session.QueryOver<Patient>().Where(p => p.SSN == "638-55-8787").SingleOrDefault();
            }*/

            /*NHibernate*/
            using (ISession session = NHibernateSession.OpenSession())
            {

                /*
                session.CreateSQLQuery("EXECUTE dbo.sp_add_employee :SSN, :FirstName, :LastName, :MiddleName, :StreetAddress, :City, :ZipCode, :State")
                    .SetParameter("SSN", "380-55-8787", TypeFactory.GetAnsiStringType(11))
                    .SetParameter("FirstName", "Joanna", TypeFactory.GetStringType(50))
                    .SetParameter("LastName", "Walsh", TypeFactory.GetStringType(50))
                    .SetParameter("MiddleName", "S.", TypeFactory.GetStringType(50))
                    .SetParameter("StreetAddress", "1101 Chase Ave.", TypeFactory.GetStringType(50))
                    .SetParameter("City", "Seattle", TypeFactory.GetStringType(50))
                    .SetParameter("ZipCode", "85231", TypeFactory.GetStringType(5))
                    .SetParameter("State", "WA", TypeFactory.GetStringType(2))
                    .ExecuteUpdate()
                ;
                */
                /*
                using (var trans = session.BeginTransaction())
                {
                    
                    session.SaveOrUpdate(new Employee()
                    {
                        FirstName = "Joanna",
                        City = "Seattle",
                        LastName = "Walsh",
                        MiddleName = "S.",
                        SSN = "380-55-8787",
                        State = "WA",
                        StreetAddress = "1101 Chase Av.",
                        ZipCode = "85231"
                    });

                    trans.Commit();
                }*/
            }

            Console.Read();
        }
    }
}
