using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernate.Always.Encrypted.ConsoleApp.Domain
{
    public class ADONetSession
    {
        public static void SaveOrUpdate()
        {
            string connectionString = "Server=tcp:webjobber.database.windows.net,1433;Initial Catalog=employee_encrypt;Persist Security Info=False;User ID=webjobber;Password=JZJ57YYt3qu2QB7s;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Column Encryption Setting=enabled";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (System.Data.SqlClient.SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Patient] ([SSN], [FirstName], [LastName], [BirthDate]) VALUES (@SSN, @FirstName, @LastName, @BirthDate);";

                    SqlParameter paramSSN = cmd.CreateParameter();
                    paramSSN.ParameterName = @"@SSN";
                    paramSSN.DbType = DbType.AnsiStringFixedLength;
                    paramSSN.Direction = ParameterDirection.Input;
                    paramSSN.Value = "795-73-9838";
                    paramSSN.Size = 11;
                    cmd.Parameters.Add(paramSSN);

                    SqlParameter paramFirstName = cmd.CreateParameter();
                    paramFirstName.ParameterName = @"@FirstName";
                    paramFirstName.DbType = DbType.String;
                    paramFirstName.Direction = ParameterDirection.Input;
                    paramFirstName.Value = "Catherine";
                    paramFirstName.Size = 50;
                    cmd.Parameters.Add(paramFirstName);

                    SqlParameter paramLastName = cmd.CreateParameter();
                    paramLastName.ParameterName = @"@LastName";
                    paramLastName.DbType = DbType.String;
                    paramLastName.Direction = ParameterDirection.Input;
                    paramLastName.Value = "Abel";
                    paramLastName.Size = 50;
                    cmd.Parameters.Add(paramLastName);

                    SqlParameter paramBirthdate = cmd.CreateParameter();
                    paramBirthdate.ParameterName = @"@BirthDate";
                    paramBirthdate.SqlDbType = SqlDbType.Date;
                    paramBirthdate.Direction = ParameterDirection.Input;
                    paramBirthdate.Value = new DateTime(1996, 09, 10);
                    cmd.Parameters.Add(paramBirthdate);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
