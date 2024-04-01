using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SmartVendas.Infra.Data.Repositories.ReadOnly
{
    public class RepositoryBaseReadOnly
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["SmartVendas"].ConnectionString);
            }
        }
    }
}
