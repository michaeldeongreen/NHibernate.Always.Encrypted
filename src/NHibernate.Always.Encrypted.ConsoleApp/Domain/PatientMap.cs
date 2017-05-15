using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(p => p.Id).UnsavedValue(0);
            Map(p => p.SSN).Not.Nullable();
            Map(p => p.FirstName).Nullable();
            Map(p => p.LastName).Nullable();
            Map(p => p.MiddleName).Nullable();
            Map(p => p.StreetAddress).Nullable();
            Map(p => p.City).Nullable();
            Map(p => p.State).Nullable();
            Map(p => p.ZipCode).Nullable();
            Map(p => p.BirthDate).Not.Nullable();
        }
    }
}
