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
                var employee = session.QueryOver<Patient>().Where(p => p.Id == 1).SingleOrDefault();
            }

            Console.Read();
        }
    }
}
