using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class NHibernateSession
    {
        private static ISessionFactory _nHibernateSessionFactory;
        private static ISessionFactory NHibernateSessionFactory
        {
            get
            {
                if (_nHibernateSessionFactory == null)
                {
                    var configuration = new Configuration();

                    configuration.SetProperty("connection.driver_class",
                                              "NHibernate.Always.Encrypted.ConsoleApp.Domain.SizeAwareSqlClientDriver, NHibernate.Always.Encrypted.ConsoleApp");

                    configuration.DataBaseIntegration(db =>
                    {
                        db.Dialect<MsSql2012Dialect>();
                        db.ConnectionString =
                            "Server=tcp:webjobber.database.windows.net,1433;Initial Catalog=employee_encrypt;Persist Security Info=False;User ID=webjobber;Password=JZJ57YYt3qu2QB7s;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Column Encryption Setting=enabled";
                    });

                    configuration.AddDeserializedMapping(CompileHbmMappings(), "NHSchema");
                    _nHibernateSessionFactory = configuration.BuildSessionFactory();
                }
                return _nHibernateSessionFactory;
            }
        }

        private static HbmMapping CompileHbmMappings()
        {
            var mapper = new ModelMapper();

            mapper.AddMappings(Assembly.GetAssembly(typeof(Employee))
                                       .GetExportedTypes());

            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
        public static ISession OpenSession()
        {
            return NHibernateSessionFactory.OpenSession();
        }
    }
}
