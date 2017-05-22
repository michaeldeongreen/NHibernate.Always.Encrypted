using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class Patient
    {
        public virtual int Id { get; set; }
        public virtual string SSN { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string StreetAddress { get; set; }
        public virtual string City { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string State { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual byte[] Contract { get; set; }
    }
}
