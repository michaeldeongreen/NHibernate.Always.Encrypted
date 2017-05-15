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
    public class NHibernateSession
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    string connectionString = "Server=tcp:webjobber.database.windows.net,1433;Initial Catalog=employee_encrypt;Persist Security Info=False;User ID=webjobber;Password=JZJ57YYt3qu2QB7s;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                    Configuration configuration = null;
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(connectionString).Driver<SqlAzureClientDriver>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Patient>())
                        .ExposeConfiguration(cfg =>
                        {
                            configuration = cfg;
                            cfg.SetProperty(Environment.CollectionTypeFactoryClass, typeof(List<>).AssemblyQualifiedName);
                            cfg.SetProperty(Environment.PrepareSql, false.ToString());
                            cfg.SetProperty(Environment.TransactionStrategy, "NHibernate.Transaction.AdoNetTransactionFactory");
                            cfg.SetProperty(Environment.ShowSql, "false");
                        })
                        .BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
