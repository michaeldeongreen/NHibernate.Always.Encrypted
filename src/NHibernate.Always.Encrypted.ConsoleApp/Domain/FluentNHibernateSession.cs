using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.SqlAzure;
using NHibernate.Tool.hbm2ddl;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class FluentNHibernateSession
    {
        private static ISessionFactory _fluentNHibernateSessionFactory;
        private static ISessionFactory FluentNHibernateSessionFactory
        {
            get
            {
                if (_fluentNHibernateSessionFactory == null)
                {
                    string connectionString = "Server=tcp:webjobber.database.windows.net,1433;Initial Catalog=employee_encrypt;Persist Security Info=False;User ID=webjobber;Password=JZJ57YYt3qu2QB7s;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Column Encryption Setting=enabled";
                    Configuration configuration = null;
                    _fluentNHibernateSessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ShowSql().ConnectionString(connectionString).Driver<SqlAzureClientDriver>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Patient>())
                        .ExposeConfiguration(cfg =>
                        {
                            configuration = cfg;
                            cfg.SetProperty(Environment.CollectionTypeFactoryClass, typeof(List<>).AssemblyQualifiedName);
                            cfg.SetProperty(Environment.PrepareSql, false.ToString());
                            cfg.SetProperty(Environment.TransactionStrategy, "NHibernate.Transaction.AdoNetTransactionFactory");
                            cfg.SetProperty(Environment.ShowSql, "true");
                        })
                        .BuildSessionFactory();
                }
                return _fluentNHibernateSessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return FluentNHibernateSessionFactory.OpenSession();
        }
    }
}
