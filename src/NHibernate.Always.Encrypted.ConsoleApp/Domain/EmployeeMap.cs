using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class EmployeeMap : ClassMapping<Employee>
    {
        public EmployeeMap()
        {
            Id(e => e.Id);
            Property(p => p.SSN, p => p.Type(NHibernateUtil.AnsiString));
            Property(p => p.FirstName);
            Property(p => p.LastName);
            Property(p => p.MiddleName);
            Property(p => p.StreetAddress);
            Property(p => p.City);
            Property(p => p.State);
            Property(p => p.ZipCode);
        }
    }
}
