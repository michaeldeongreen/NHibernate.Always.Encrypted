using NHibernate.Driver;
using NHibernate.SqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class SizeAwareSqlClientDriver : SqlClientDriver
    {
        protected override void InitializeParameter(IDbDataParameter dbParam, string name, SqlType sqlType)
        {
            base.InitializeParameter(dbParam, name, sqlType);

            if (sqlType.LengthDefined)
            {
                dbParam.Size = sqlType.Length;
            }
        }
    }
}
